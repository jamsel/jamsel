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
 * Class to represent the <tt>bool</tt> equality operator. Immutable.
 * 
 * @author Jawaid Hakim.
 */
class OpBoolEQ implements IExpressionBool
{
	/**
	 * Ctor.
	 * 
	 * @param lhs
	 *            LHS of the equality.
	 * @param rhs
	 *            RHS of the equality.
	 */
	public OpBoolEQ(final IExpression lhs, final IExpression rhs)
	{
		lhs_ = lhs;
		rhs_ = rhs;
	}

	public Object eval(final Map identifiers)
	{
		Object oLhs = lhs_.eval(identifiers);
		if (!(oLhs instanceof Boolean))
			return Result.RESULT_UNKNOWN;
		boolean lhs = ((Boolean) oLhs).booleanValue();

		Object oRhs = rhs_.eval(identifiers);
		if (!(oRhs instanceof Boolean))
			return Result.RESULT_UNKNOWN;
		boolean rhs = ((Boolean) oRhs).booleanValue();

		if (lhs == rhs)
			return Result.RESULT_TRUE;
		else
			return Result.RESULT_FALSE;
	}

	public Object eval(final IValueProvider provider, final Object corr)
	{
		Object oLhs = lhs_.eval(provider, corr);
		if (!(oLhs instanceof Boolean))
			return Result.RESULT_UNKNOWN;
		boolean lhs = ((Boolean) oLhs).booleanValue();

		Object oRhs = rhs_.eval(provider, corr);
		if (!(oRhs instanceof Boolean))
			return Result.RESULT_UNKNOWN;
		boolean rhs = ((Boolean) oRhs).booleanValue();

		if (lhs == rhs)
			return Result.RESULT_TRUE;
		else
			return Result.RESULT_FALSE;
	}

	public String toString()
	{
		return lhs_.toString() + " = " + rhs_.toString();
	}

	private final IExpression lhs_;

	private final IExpression rhs_;

}
