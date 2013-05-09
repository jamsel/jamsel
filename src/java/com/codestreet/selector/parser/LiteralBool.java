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
 * Class to represent <tt>immutable</tt> <tt>Bool</tt> literals.
 * 
 * @author Jawaid Hakim.
 */
final class LiteralBool implements IExpressionBool
{
	/**
	 * Factory.
	 * 
	 * @param literal
	 *            Literal. Must be either <tt>true</tt>, or <tt>TRUE</tt>,
	 *            or <tt>True</tt>, or <tt>false</tt>, or <tt>FALSE</tt>,
	 *            or <tt<False</tt>.
	 * @return Instance.
	 * @throws java.lang.IllegalArgumentException
	 *             Invalid literal.
	 */
	public static synchronized LiteralBool valueOf(final String literal)
	{
		LiteralBool ret = (LiteralBool) idMap_.get(literal);
		if (ret == null)
			throw new IllegalArgumentException("Invalid literal: " + literal);
		return ret;
	}

	/**
	 * Ctor.
	 * 
	 * @param literal
	 *            Literal.
	 */
	private LiteralBool(final String literal)
	{
		literal_ = Boolean.valueOf(literal);
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
		return literal_.toString();
	}

	private final Boolean literal_;

	private static Map idMap_ = new HashMap();

	static
	{
		LiteralBool literal = new LiteralBool("true");
		idMap_.put("true", literal);
		idMap_.put("TRUE", literal);
		idMap_.put("True", literal);

		literal = new LiteralBool("false");
		idMap_.put("false", literal);
		idMap_.put("FALSE", literal);
		idMap_.put("False", literal);
	}
}