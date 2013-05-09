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

package com.codestreet.selector;

import java.util.Map;

import com.codestreet.selector.parser.IValueProvider;
import com.codestreet.selector.parser.Result;

/**
 * Interface implemented by selectors.
 * 
 * @author Jawaid Hakim.
 */
public interface ISelector
{
	/**
	 * Evaluate the selector.
	 * 
	 * @param identifiers
	 *            Value for each non-null identifier in the selector.
	 * @return Returns <tt>true</tt> if the data passes the selector.
	 *         Otherwise, returns <tt>false</tt>.
	 * @see #getIdentifiers()
	 */
	Result eval(final Map identifiers);

	/**
	 * Evaluate the selector.
	 * 
	 * @param provider
	 *            Value provider. During evaluation of the selector callbacks
	 *            are made on the value provider to get identifier values.
	 * @param corr
	 *            Correlation data. Passed as-is to the value provider.
	 * @return Result evaluating the selector.
	 */
	Result eval(final IValueProvider provider, final Object corr);

	/**
	 * Get identifiers used by the selector. The key into the <tt>Map</tt> is
	 * the name of the identifier and the value is an instance of
	 * <tt>Identifier</tt>.
	 * 
	 * @return Readonly <tt>Map</tt> of identifiers that are used within the
	 *         selector.
	 * @throws UnsupportedOperationException
	 * @see #eval(Map)
	 */
	Map getIdentifiers();

	/**
	 * Get the selector.
	 * 
	 * @return Selector.
	 */
	String getSelector();
}
