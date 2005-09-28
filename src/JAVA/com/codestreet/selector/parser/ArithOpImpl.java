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
 * Typesafe enumeration of valid arithmetic operators.
 * 
 * @author Jawaid Hakim.
 */
abstract class ArithOpImpl
{
	/**
	 * Ctor.
	 * 
	 * @param operator
	 *            Operator.
	 */
	private ArithOpImpl(final String operator)
	{
		operator_ = operator;
	}

	public String toString()
	{
		return operator_;
	}

	public abstract Object eval(final Map identifiers, final IExpression lhs,
			final IExpression rhs);

	public abstract Object eval(final IValueProvider provider,
			final Object corr, final IExpression lhs, final IExpression rhs);

	/**
	 * + operator.
	 */
	public static final ArithOpImpl PLUS = new ArithOpImpl("+")
	{
		public Object eval(final Map identifiers, final IExpression lhs,
				final IExpression rhs)
		{
			Object oLhs = lhs.eval(identifiers);
			if (!(oLhs instanceof Number))
				return Result.RESULT_UNKNOWN;
			Number lhsVal = (Number) oLhs;

			Object oRhs = rhs.eval(identifiers);
			if (!(oRhs instanceof Number))
				return Result.RESULT_UNKNOWN;
			Number rhsVal = (Number) oRhs;

			return new Double(lhsVal.doubleValue() + rhsVal.doubleValue());
		}

		public Object eval(final IValueProvider provider, final Object corr,
				final IExpression lhs, final IExpression rhs)
		{
			Object oLhs = lhs.eval(provider, corr);
			if (!(oLhs instanceof NumericValue))
				return Result.RESULT_UNKNOWN;
			NumericValue lhsVal = (NumericValue) oLhs;

			Object oRhs = rhs.eval(provider, corr);
			if (!(oRhs instanceof NumericValue))
				return Result.RESULT_UNKNOWN;
			NumericValue rhsVal = (NumericValue) oRhs;

			return new Double(lhsVal.doubleValue() + rhsVal.doubleValue());
		}
	};

	/**
	 * - operator.
	 */
	public static final ArithOpImpl MINUS = new ArithOpImpl("-")
	{
		public Object eval(final Map identifiers, final IExpression lhs,
				final IExpression rhs)
		{
			Object oLhs = lhs.eval(identifiers);
			if (!(oLhs instanceof NumericValue))
				return Result.RESULT_UNKNOWN;
			NumericValue lhsVal = (NumericValue) oLhs;

			Object oRhs = rhs.eval(identifiers);
			if (!(oRhs instanceof NumericValue))
				return Result.RESULT_UNKNOWN;
			NumericValue rhsVal = (NumericValue) oRhs;

			return new Double(lhsVal.doubleValue() - rhsVal.doubleValue());
		}

		public Object eval(final IValueProvider provider, final Object corr,
				final IExpression lhs, final IExpression rhs)
		{
			Object oLhs = lhs.eval(provider, corr);
			if (!(oLhs instanceof NumericValue))
				return Result.RESULT_UNKNOWN;
			NumericValue lhsVal = (NumericValue) oLhs;

			Object oRhs = rhs.eval(provider, corr);
			if (!(oRhs instanceof NumericValue))
				return Result.RESULT_UNKNOWN;
			NumericValue rhsVal = (NumericValue) oRhs;

			return new Double(lhsVal.doubleValue() - rhsVal.doubleValue());
		}
	};

	/**
	 * * operator.
	 */
	public static final ArithOpImpl MULT = new ArithOpImpl("*")
	{
		public Object eval(final Map identifiers, final IExpression lhs,
				final IExpression rhs)
		{
			Object oLhs = lhs.eval(identifiers);
			if (!(oLhs instanceof NumericValue))
				return Result.RESULT_UNKNOWN;
			NumericValue lhsVal = (NumericValue) oLhs;

			Object oRhs = rhs.eval(identifiers);
			if (!(oRhs instanceof NumericValue))
				return Result.RESULT_UNKNOWN;
			NumericValue rhsVal = (NumericValue) oRhs;

			return new Double(lhsVal.doubleValue() * rhsVal.doubleValue());
		}

		public Object eval(final IValueProvider provider, final Object corr,
				final IExpression lhs, final IExpression rhs)
		{
			Object oLhs = lhs.eval(provider, corr);
			if (!(oLhs instanceof NumericValue))
				return Result.RESULT_UNKNOWN;
			NumericValue lhsVal = (NumericValue) oLhs;

			Object oRhs = rhs.eval(provider, corr);
			if (!(oRhs instanceof NumericValue))
				return Result.RESULT_UNKNOWN;
			NumericValue rhsVal = (NumericValue) oRhs;

			return new Double(lhsVal.doubleValue() * rhsVal.doubleValue());
		}
	};

	/**
	 * / operator.
	 */
	public static final ArithOpImpl DIV = new ArithOpImpl("/")
	{
		public Object eval(final Map identifiers, final IExpression lhs,
				final IExpression rhs)
		{
			Object oLhs = lhs.eval(identifiers);
			if (!(oLhs instanceof NumericValue))
				return Result.RESULT_UNKNOWN;
			NumericValue lhsVal = (NumericValue) oLhs;

			Object oRhs = rhs.eval(identifiers);
			if (!(oRhs instanceof NumericValue))
				return Result.RESULT_UNKNOWN;
			NumericValue rhsVal = (NumericValue) oRhs;

			return new Double(lhsVal.doubleValue() / rhsVal.doubleValue());
		}

		public Object eval(final IValueProvider provider, final Object corr,
				final IExpression lhs, final IExpression rhs)
		{
			Object oLhs = lhs.eval(provider, corr);
			if (!(oLhs instanceof NumericValue))
				return Result.RESULT_UNKNOWN;
			NumericValue lhsVal = (NumericValue) oLhs;

			Object oRhs = rhs.eval(provider, corr);
			if (!(oRhs instanceof NumericValue))
				return Result.RESULT_UNKNOWN;
			NumericValue rhsVal = (NumericValue) oRhs;

			return new Double(lhsVal.doubleValue() / rhsVal.doubleValue());
		}
	};

	/**
	 * unary - operator.
	 */
	public static final ArithOpImpl NEG = new ArithOpImpl("-")
	{
		public Object eval(final Map identifiers, final IExpression lhs,
				final IExpression rhs)
		{
			Object oRhs = rhs.eval(identifiers);
			if (!(oRhs instanceof NumericValue))
				return Result.RESULT_UNKNOWN;
			NumericValue rhsVal = (NumericValue) oRhs;

			return new Double(-rhsVal.doubleValue());
		}

		public Object eval(final IValueProvider provider, final Object corr,
				final IExpression lhs, final IExpression rhs)
		{
			Object oRhs = rhs.eval(provider, corr);
			if (!(oRhs instanceof NumericValue))
				return Result.RESULT_UNKNOWN;
			NumericValue rhsVal = (NumericValue) oRhs;

			return new Double(-rhsVal.doubleValue());
		}
	};

	private final String operator_;
}
