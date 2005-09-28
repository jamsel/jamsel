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

import java.util.HashMap;
import java.util.Map;

/**
 * Class to represent a <tt>String</tt> literal. Immutable.
 * 
 * @author Jawaid Hakim.
 */
final class LiteralString implements IExpressionString
{
	/**
	 * Factory.
	 * 
	 * @param literal
	 *            Literal.
	 * @return Instance.
	 */
	public static synchronized LiteralString valueOf(final String literal)
	{
		LiteralString instance = (LiteralString) idMap_.get(literal);
		if (instance == null)
		{
			instance = new LiteralString(literal);
			idMap_.put(literal, instance);
		}
		return instance;
	}

	/**
	 * Ctor.
	 * 
	 * @param literal
	 *            String literal.
	 */
	public LiteralString(final String literal)
	{
		literal_ = literal;
	}

	public Object eval(final Map identifiers)
	{
		return literal_;
	}

	public Object eval(final IValueProvider provider, final Object corr)
	{
		return literal_;
	}

	public String toString()
	{
		return literal_;
	}

	private final String literal_;

	private static Map idMap_ = new HashMap();
}
