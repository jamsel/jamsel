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

package com.codestreet.selector.rv;

import java.util.StringTokenizer;

import com.codestreet.selector.parser.IValueProvider;
import com.codestreet.selector.parser.Identifier;
import com.codestreet.selector.parser.NumericValue;
import com.tibco.tibrv.TibrvException;
import com.tibco.tibrv.TibrvMsg;
import com.tibco.tibrv.TibrvMsgField;

/**
 * /** Value provider for TIBCO/Rendezvous. This implementation allows values to
 * be extracted from <tt>Rendezvous</tt> messages using a <tt>dot</tt>
 * notation.
 * <p>
 * For example, <tt>.order.quantity</tt> would access the <tt>quantity</tt>
 * field of the nested sub-message field <tt>order</tt>, if it exists. If the
 * field does not exist, it returns <tt>null</tt>.
 * <p>
 * The reason for requiring a leading <tt>dot</tt> before field names -
 * includign top level fields - is to provide comptibility between the
 * <tt>Rendezvous</tt> and <tt>JMS</tt> value provides.
 * 
 * @author Jawaid Hakim.
 * 
 * @author Jawaid Hakim.
 */
public class ValueProvider implements IValueProvider
{
	/**
	 * Factory method.
	 * 
	 * @param msg
	 *            Message to extract values from.
	 * @return Instance.
	 */
	public static ValueProvider valueOf(final TibrvMsg msg)
	{
		return new ValueProvider(msg);
	}

	/**
	 * Ctor.
	 * 
	 * @param msg
	 *            <tt>Message</tt> from which values will be extracted.
	 *            expressions.
	 *            <p>
	 *            For example, <tt>trade.quantity</tt> would select the
	 *            <tt>quantity</tt> field of the nested sub-message field
	 *            <tt>trade</tt> if it exists. Otherwise, it selects nothing (<tt>null</tt>).
	 */
	private ValueProvider(final TibrvMsg msg)
	{
		msg_ = msg;
	}

	/**
	 * Get the value for the specified identifier.
	 * 
	 * @param identifier
	 *            Field identifier.
	 * @param correlation
	 *            Application correlation data. May be <tt>null</tt>.
	 * @return Value of the specified identifier. Returns <tt>null</tt> if the
	 *         value of the identifier is not found.
	 */
	public Object getValue(final Object identifier, final Object correlation)
	{
		try
		{
			return getValueFromDot(msg_, (Identifier) identifier);
		}
		catch (TibrvException ex)
		{
			throw new IllegalArgumentException(ex.toString());
		}
	}

	private static Object getValueFromDot(final TibrvMsg msg, final Identifier identifier)
			throws TibrvException
	{
		TibrvMsg workMsg = msg;
		
		TibrvMsgField fld = null;
		String id = identifier.getIdentifier();

		// Skip over leading '.' if any
		int ind = id.indexOf('.');
		if (ind == 0)
		{
			id = id.substring(1);
			ind = id.indexOf('.');
		}
		if (ind < 0)
		{
			fld = workMsg.getField(id);
		}
		else
		{
			for (StringTokenizer strTok = new StringTokenizer(id, ".", false); strTok
					.hasMoreTokens();)
			{
				if (fld != null)
					workMsg = (TibrvMsg) fld.data;
				String fldName = strTok.nextToken();
				fld = workMsg.getField(fldName);
			}
		}

		if (fld != null)
		{
			/**
			 * Wrap numeric values in NumericValue instance
			 */
			if ((fld.data instanceof Integer))
				return new NumericValue((Integer) fld.data);

			if ((fld.data instanceof Float))
				return new NumericValue((Float) fld.data);

			if ((fld.data instanceof Double))
				return new NumericValue((Double) fld.data);

			if ((fld.data instanceof Long))
				return new NumericValue((Long) fld.data);

			if ((fld.data instanceof Short))
				return new NumericValue((Short) fld.data);

			if ((fld.data instanceof Byte))
				return new NumericValue((Byte) fld.data);

			return fld.data;
		}

		return null;
	}

	private final TibrvMsg msg_;
}
