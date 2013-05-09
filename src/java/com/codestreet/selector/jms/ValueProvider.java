/**
 * Copyright 2003, 2004, 2005. CodeStreet LLC.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

package com.codestreet.selector.jms;

import java.util.StringTokenizer;

import javax.jms.JMSException;
import javax.jms.MapMessage;
import javax.jms.Message;

import com.codestreet.selector.parser.IValueProvider;
import com.codestreet.selector.parser.Identifier;
import com.codestreet.selector.parser.NumericValue;

/**
 * Value provider for JMS. As an extension to the JMS specification, this
 * implementation allows values to be extracted from <tt>JMS</tt> message
 * <tt>body</tt> using a <tt>dot</tt> notation.
 * <p>
 * The <tt>dot</tt> notation provides reference to message body fields. For
 * example, <tt>.order.quantity</tt> would access the <tt>quantity</tt>
 * field of the nested sub-message field <tt>order</tt>, if it exists. If the
 * field does not exist, it returns <tt>null</tt>.
 * 
 * @author Jawaid Hakim.
 */
public class ValueProvider implements IValueProvider
{
	/**
	 * Factory.
	 * 
	 * @param msg
	 *            Message to extract values from.
	 * @return Instance.
	 */
	public static IValueProvider valueOf(final Message msg)
	{
		return new ValueProvider(msg);
	}

	/**
	 * Ctor.
	 * 
	 * @param msg
	 *            <tt>Message</tt> from which to extract values.
	 *            <p>
	 *            For example, <tt>order.quantity</tt> would select the
	 *            <tt>quantity</tt> field of the nested sub-message field
	 *            <tt>order</tt> if it exists. If the field does not exist, it
	 *            returns <tt>null</tt>.
	 * @see #getValue(com.codestreet.selector.parser.Identifier, Object)
	 */
	private ValueProvider(final Message msg)
	{
		msg_ = msg;
	}

	/**
	 * Get the value of the specified identifier.
	 * 
	 * @param identifier
	 *            Field identifier.
	 * @param correlation
	 *            Application correlation data. May be <tt>null</tt>.
	 * @return Value of the specified identifier. Returns <tt>null</tt> if
	 *         value of the specified identifier is not found.
	 */
	public Object getValue(final Object identifier, final Object correlation)
	{
		try
		{
			/**
			 * Wrap numeric values in NumericValue instance
			 */
			Object value = (getValue(msg_, (Identifier) identifier));
			if ((value instanceof Integer))
				return new NumericValue((Integer) value);

			if ((value instanceof Float))
				return new NumericValue((Float) value);

			if ((value instanceof Double))
				return new NumericValue((Double) value);

			if ((value instanceof Long))
				return new NumericValue((Long) value);

			if ((value instanceof Short))
				return new NumericValue((Short) value);

			if ((value instanceof Byte))
				return new NumericValue((Byte) value);

			return value;
		}
		catch (JMSException ex)
		{
			throw new IllegalArgumentException(ex.toString());
		}
	}

	private static Object getValue(final Message msg,
			final Identifier identifier) throws JMSException
	{
		Message workMsg = msg;
		if (identifier.isJMSHeader())
			return getHeaderValue(workMsg, identifier);

		String fldName = identifier.getIdentifier();

		// Leading '.' is there to indicate that this identifier references a
		// nested
		// message field (not a property)
		int ind = fldName.indexOf('.');
		if (ind >= 0)
		{
			// Skip over leading '.' if any
			if (ind == 0)
				fldName = fldName.substring(1);

			for (StringTokenizer strTok = new StringTokenizer(identifier
					.getIdentifier(), ".", false); strTok.hasMoreTokens();)
			{
				if (!(workMsg instanceof MapMessage))
					return null;

				MapMessage mapMsg = (MapMessage) workMsg;

				fldName = strTok.nextToken();
				Object nestedMsg = mapMsg.getObject(fldName);
				if (strTok.hasMoreTokens())
				{
					if (!(nestedMsg instanceof MapMessage))
						return null;

					workMsg = (Message) nestedMsg;
				}
				else
					return nestedMsg;
			}
		}

		// Must be a property
		if (workMsg.propertyExists(fldName))
		{
			return workMsg.getObjectProperty(fldName);
		}
		return null;
	}

	private static Object getHeaderValue(final Message msg,
			final Identifier identifier) throws JMSException
	{
		String prop = identifier.getIdentifier();
		if (prop.equals("JMSMessageID"))
			return msg.getJMSMessageID();
		else if (prop.equals("JMSPriority"))
			return new Integer(msg.getJMSPriority());
		else if (prop.equals("JMSTimestamp"))
			return new Long(msg.getJMSTimestamp());
		else if (prop.equals("JMSCorrelationID"))
			return msg.getJMSCorrelationID();
		else if (prop.equals("JMSDeliveryMode"))
			return new Integer(msg.getJMSDeliveryMode());
		else if (prop.equals("JMSRedelivered"))
			return new Boolean(msg.getJMSRedelivered());
		else if (prop.equals("JMSType"))
			return msg.getJMSType();
		else if (prop.equals("JMSExpiration"))
			return new Long(msg.getJMSExpiration());

		throw new java.lang.IllegalStateException(
				"Invalid JMS property referenced: " + prop);
	}

	private final Message msg_;
}
