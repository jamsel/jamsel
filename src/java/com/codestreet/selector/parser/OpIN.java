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

import java.util.Iterator;
import java.util.Map;
import java.util.Set;

/**
 * Class to represent <tt>set</tt> membership operator. Immutable.
 * 
 * @author Jawaid Hakim.
 */
class OpIN implements IExpressionString
{
	/**
	 * Ctor.
	 * 
	 * @param lhs
	 *            Data to check for.
	 * @param rhs
	 *            Membership set.
	 */
	public OpIN(final IExpression lhs, final Set rhs)
	{
		lhs_ = lhs;
		rhs_ = rhs;
	}

	public Object eval(final Map identifiers)
	{
		Object oLhs = lhs_.eval(identifiers);
		if (!(oLhs instanceof String))
			return Result.RESULT_UNKNOWN;

		return (rhs_.contains(oLhs)) ? Result.RESULT_TRUE : Result.RESULT_FALSE;
	}

	public Object eval(final IValueProvider provider, final Object corr)
	{
		Object oLhs = lhs_.eval(provider, corr);
		if (!(oLhs instanceof String))
			return Result.RESULT_UNKNOWN;

		return (rhs_.contains(oLhs)) ? Result.RESULT_TRUE : Result.RESULT_FALSE;
	}

	public String toString()
	{
		StringBuffer buf = new StringBuffer(lhs_.toString());
		buf.append(" IN (");
		boolean first = true;
		for (Iterator iter = rhs_.iterator(); iter.hasNext();)
		{
			if (!first)
				buf.append(',');
			buf.append('\'').append(iter.next()).append('\'');
			first = false;
		}
		buf.append(')');
		return buf.toString();
	}

	private final IExpression lhs_;

	private final Set rhs_;
}
