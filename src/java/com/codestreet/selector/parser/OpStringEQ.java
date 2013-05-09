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

import java.util.Map;

/**
 * Class to represent the <tt>String</tt> equality operator. Immutable.
 * 
 * @author Jawaid Hakim.
 */
class OpStringEQ implements IExpressionString
{
	/**
	 * Ctor.
	 * 
	 * @param lhs
	 *            LHS.
	 * @param rhs
	 *            RHS.
	 */
	public OpStringEQ(final IExpression lhs, final IExpression rhs)
	{
		lhs_ = lhs;
		rhs_ = rhs;
	}

	public Object eval(final Map identifiers)
	{
		Object oLhs = lhs_.eval(identifiers);
		Object oRhs = rhs_.eval(identifiers);

		return eval(oLhs, oRhs);
	}

	public Object eval(final IValueProvider provider, final Object corr)
	{
		Object oLhs = lhs_.eval(provider, corr);
		Object oRhs = rhs_.eval(provider, corr);

		return eval(oLhs, oRhs);
	}

	private Object eval(final Object oLhs, final Object oRhs)
	{
		if (!(oLhs instanceof String))
			return Result.RESULT_UNKNOWN;

		if (!(oRhs instanceof String))
			return Result.RESULT_UNKNOWN;

		return (oLhs.equals(oRhs)) ? Result.RESULT_TRUE : Result.RESULT_FALSE;
	}

	private final IExpression lhs_;

	private final IExpression rhs_;

}
