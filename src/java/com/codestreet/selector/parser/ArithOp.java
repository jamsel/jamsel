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
 * Class to implement arithmetic operators.
 * 
 * @author Jawaid Hakim.
 */
class ArithOp implements IExpression
{
	/**
	 * Ctor.
	 * 
	 * @param op
	 *            Arithmetic operator.
	 * @param lhs
	 *            LHS.
	 * @param rhs
	 *            RHS.
	 */
	public ArithOp(final ArithOpImpl op, final IExpression lhs,
			final IExpression rhs)
	{
		op_ = op;
		lhs_ = lhs;
		rhs_ = rhs;
	}

	public Object eval(final Map identifiers)
	{
		return op_.eval(identifiers, lhs_, rhs_);
	}

	public Object eval(final IValueProvider provider, final Object corr)
	{
		return op_.eval(provider, corr, lhs_, rhs_);
	}

	public String toString()
	{
		return lhs_.toString() + op_.toString() + rhs_.toString();
	}

	private final IExpression lhs_;

	private final IExpression rhs_;

	private final ArithOpImpl op_;
}
