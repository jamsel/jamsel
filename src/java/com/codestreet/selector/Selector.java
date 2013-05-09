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

import com.codestreet.selector.parser.IExpression;
import com.codestreet.selector.parser.IValueProvider;
import com.codestreet.selector.parser.InvalidSelectorException;
import com.codestreet.selector.parser.Result;
import com.codestreet.selector.parser.SelectorParser;
import com.codestreet.selector.parser.SelectorParser.SelectorParseState;

/**
 * Thread safe Selector implementation.
 * 
 * @author Jawaid Hakim.
 */
public class Selector implements ISelector
{
	/**
	 * Factory.
	 * 
	 * @param selector
	 *            Selector.
	 * @return Selector instance.
	 * @throws NullPointerException
	 * @see #getInstance(String, boolean)
	 */
	public static Selector getInstance(final String selector)
			throws InvalidSelectorException
	{
		return getInstance(selector, false);
	}

	/**
	 * Factory.
	 * 
	 * @param selector
	 *            Selector.
	 * @param trace
	 *            Parser outputs trace if <tt>true</tt> .
	 * @return Selector instance.
	 * @throws NullPointerException
	 * @throws com.codestreet.selector.parser.InvalidSelectorException
	 * @see #getInstance(String)
	 */
	public static Selector getInstance(final String selector,
			final boolean trace) throws InvalidSelectorException
	{
		if (selector == null)
			throw new NullPointerException("NULL selector");

		SelectorParseState exp = SelectorParser.doParse(selector, trace);
		return new Selector(selector, exp.getRoot(), exp.getIdentifiers());
	}

	/**
	 * Ctor.
	 * 
	 * @param selector
	 *            Selector.
	 * @param root
	 *            Root expression of the parsed selector.
	 * @param identifiers
	 *            Identifiers used by the selector. The key into the
	 *            <tt>Map</tt> is name of the identifier and the value is an
	 *            instance of <tt>Identifier</tt>.
	 */
	private Selector(final String selector, final IExpression root,
			final Map identifiers)
	{
		selector_ = selector;
		root_ = root;
		identifiers_ = java.util.Collections.unmodifiableMap(identifiers);
	}

	/**
	 * Evaluate the selector.
	 * 
	 * @param identifiers
	 *            Value for each non-null identifier in the selector.
	 * @return Result of evaluating the selector.
	 * @see #getIdentifiers()
	 */
	public Result eval(final Map identifiers)
	{
		return (Result) root_.eval(identifiers);
	}

	/**
	 * Evaluate the selector.
	 * 
	 * @param provider
	 *            Value provider. During evaluation of the selector callbacks
	 *            are made on the value provider to get identifier values.
	 * @param corr
	 *            Correlation data. Passed as-is to the value provider.
	 * @return Result of evaluating the selector.
	 */
	public Result eval(final IValueProvider provider, final Object corr)
	{
		return (Result) root_.eval(provider, corr);
	}

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
	public Map getIdentifiers()
	{
		return identifiers_;
	}

	/**
	 * Get the selector.
	 * 
	 * @return Selector.
	 */
	public String getSelector()
	{
		return selector_;
	}

	/**
	 * Get selector parse tree.
	 * 
	 * @return Selector parse tree.
	 */
	public String toString()
	{
		return selector_;
	}

	private final IExpression root_;

	private final Map identifiers_;

	private final String selector_;
}
