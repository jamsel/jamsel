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

package com.codestreet.selector.parser;

import java.util.Arrays;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

/**
 * Class to represent an identifier. Thread safe class may be freely used across
 * threads. Identifiers can either be JMS header fields, or JMS
 * provider-specific properties, or application properties.
 * <p>
 * The following JMS header fields are supported: <tt>JMSDeliveryMode</tt>,
 * <tt>JMSPriority</tt>, <tt>JMSMessageID</tt>, <tt>JMSTimestamp</tt>,
 * <tt>JMSCorrelationID, 
 * and <tt>JMSType</tt>. In addition, the header fields <tt>JMSRedelivered</tt> and 
 * <tt>JMSExpiration</tt> are also supported. These additional fields are relevant only 
 * for the receiving application and not for the sender.<p>
 * Support is provided for <tt>nested</tt> fields. Nested fields are referenced using a <tt>dot</tt>
 * notation. For example, <tt>order.quantity</tt> would select the <tt>quantity</tt> field of 
 * the nested sub-message field <tt>order</tt> if it exists. Otherwise, it selects nothing 
 * (<tt>null</tt>).
 * @author Jawaid Hakim.
 */
public final class Identifier implements IExpression
{
	/**
	 * Factory.
	 * 
	 * @param id
	 *            Identifier name.
	 * @return Instance.
	 * @throws IllegalArgumentException
	 *             Invalid identifier name.
	 */
	public static synchronized Identifier valueOf(final String id)
	{
		if (reservedNamesSet_.contains(id))
			throw new IllegalArgumentException(
					"Identifier name cannot be a reserved name: " + id);

		Identifier instance = (Identifier) idMap_.get(id);
		if (instance == null)
		{
			instance = new Identifier(id);
			idMap_.put(id, instance);
		}
		return instance;
	}

	/**
	 * Ctor.
	 * 
	 * @param id
	 *            Identifier name.
	 */
	private Identifier(final String id)
	{
		id_ = id;
		jmsHeader_ = jmsHeadersSet_.contains(id);
	}

	/**
	 * Get identifier name.
	 * 
	 * @return Identifier name.
	 */
	public String getIdentifier()
	{
		return id_;
	}

	/**
	 * Check if this is a JMS header property.
	 * 
	 * @return <tt>true</tt> if this identifier is a JMS header property.
	 *         Otherwise, returns <tt>false</tt>.
	 */
	public boolean isJMSHeader()
	{
		return jmsHeader_;
	}

	public Object eval(final Map identifiers)
	{
		return getValue(identifiers);
	}

	public Object eval(final IValueProvider provider, final Object corr)
	{
		return provider.getValue(this, corr);
	}

	Object getValue(final Map identifiers)
	{
		return identifiers.get(id_);
	}

	public String toString()
	{
		return id_;
	}

	private final String id_;

	private final boolean jmsHeader_;

	private static Set jmsHeadersSet_;

	private static Set reservedNamesSet_;

	private static Map idMap_ = new HashMap();

	static
	{
		// Valid JMS header fields
		String[] jmsHeaders_ = { "JMSDeliveryMode", "JMSPriority",
				"JMSMessageID", "JMSTimestamp", "JMSCorrelationID", "JMSType",
				// Extension to the JMS Spec. 1.1
				"JMSRedelivered", "JMSExpiration" };
		jmsHeadersSet_ = new HashSet(Arrays.asList(jmsHeaders_));

		// Reserved words - not allowed as identifier names
		String[] reservedNames_ = { "NULL", "TRUE", "FALSE", "NULL", "NOT",
				"AND", "OR", "BETWEEN", "LIKE", "IN", "IS", "ESCAPE" };
		reservedNamesSet_ = new HashSet(Arrays.asList(reservedNames_));
	}
}
