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

/**
 * Value provider interface. A value provider allows an application to provide
 * identifier values on demand. As a selector is evaluated, callbacks are made
 * on the value provider when an identifier's value is needed.
 * 
 * @author Jawaid Hakim.
 * @see com.codestreet.selector.Selector
 */
public interface IValueProvider
{
	/**
	 * Get value of specified identifier.
	 * 
	 * @param identifier
	 *            Identifier.
	 * @param correlation
	 *            Correlation data. May be <tt>null</tt>.
	 * @return Value of specified identifier. Returns <tt>null</tt> if
	 *         identifier is not found. Numeric values - <tt>Integer</tt>,
	 *         <tt>Short</tt>, <tt>Long</tt>, <tt>Float</tt>,
	 *         <tt>Double</tt>, and <tt>Byte</tt> - MUST be wrapped in an
	 *         instance of <tt>NumericValue</tt>.
	 * @see NumericValue
	 */
	Object getValue(final Object identifier, final Object correlation);
}
