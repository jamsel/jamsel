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
 * Abstract base class for arithmetic expression evaluation operators.
 * 
 * @author Jawaid Hakim.
 */
abstract class ArithCompareOpImpl
{
	/**
	 * Ctor.
	 * 
	 * @param operator
	 *            Operator.
	 */
	private ArithCompareOpImpl(final String operator)
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
	 * = operator.
	 */
	public static final ArithCompareOpImpl EQ = new ArithCompareOpImpl(" = ")
	{
		public Object eval(final Map identifiers, final IExpression lhs,
				final IExpression rhs)
		{
			Object oLhs = lhs.eval(identifiers);
			if (oLhs == null)
				return Result.RESULT_UNKNOWN;
			else if (!(oLhs instanceof NumericValue))
				return Result.RESULT_FALSE;
			NumericValue nLhs = (NumericValue) oLhs;

			Object oRhs = rhs.eval(identifiers);
			if (oRhs == null)
				return Result.RESULT_UNKNOWN;
			else if (!(oRhs instanceof NumericValue))
				return Result.RESULT_FALSE;
			NumericValue nRhs = (NumericValue) oRhs;

			return (nLhs.doubleValue() == nRhs.doubleValue()) ? Result.RESULT_TRUE
					: Result.RESULT_FALSE;
		}

		public Object eval(final IValueProvider provider, final Object corr,
				final IExpression lhs, final IExpression rhs)
		{
			Object oLhs = lhs.eval(provider, corr);
			if (oLhs == null)
				return Result.RESULT_UNKNOWN;
			else if (!(oLhs instanceof NumericValue))
				return Result.RESULT_FALSE;
			NumericValue nLhs = (NumericValue) oLhs;

			Object oRhs = rhs.eval(provider, corr);
			if (oRhs == null)
				return Result.RESULT_UNKNOWN;
			else if (!(oRhs instanceof NumericValue))
				return Result.RESULT_FALSE;
			NumericValue nRhs = (NumericValue) oRhs;

			return (nLhs.doubleValue() == nRhs.doubleValue()) ? Result.RESULT_TRUE
					: Result.RESULT_FALSE;
		}
	};

	/**
	 * > operator.
	 */
	public static final ArithCompareOpImpl GT = new ArithCompareOpImpl(" > ")
	{
		public Object eval(final Map identifiers, final IExpression lhs,
				final IExpression rhs)
		{
			Object oLhs = lhs.eval(identifiers);
			if (oLhs == null)
				return Result.RESULT_UNKNOWN;
			else if (!(oLhs instanceof NumericValue))
				return Result.RESULT_FALSE;
			NumericValue nLhs = (NumericValue) oLhs;

			Object oRhs = rhs.eval(identifiers);
			if (oRhs == null)
				return Result.RESULT_UNKNOWN;
			else if (!(oRhs instanceof NumericValue))
				return Result.RESULT_FALSE;
			NumericValue nRhs = (NumericValue) oRhs;

			return (nLhs.doubleValue() > nRhs.doubleValue()) ? Result.RESULT_TRUE
					: Result.RESULT_FALSE;
		}

		public Object eval(final IValueProvider provider, final Object corr,
				final IExpression lhs, final IExpression rhs)
		{
			Object oLhs = lhs.eval(provider, corr);
			if (oLhs == null)
				return Result.RESULT_UNKNOWN;
			else if (!(oLhs instanceof NumericValue))
				return Result.RESULT_FALSE;
			NumericValue nLhs = (NumericValue) oLhs;

			Object oRhs = rhs.eval(provider, corr);
			if (oRhs == null)
				return Result.RESULT_UNKNOWN;
			else if (!(oRhs instanceof NumericValue))
				return Result.RESULT_FALSE;
			NumericValue nRhs = (NumericValue) oRhs;

			return (nLhs.doubleValue() > nRhs.doubleValue()) ? Result.RESULT_TRUE
					: Result.RESULT_FALSE;
		}
	};

	/**
	 * >= operator.
	 */
	public static final ArithCompareOpImpl GE = new ArithCompareOpImpl(" >= ")
	{
		public Object eval(final Map identifiers, final IExpression lhs,
				final IExpression rhs)
		{
			Object oLhs = lhs.eval(identifiers);
			if (oLhs == null)
				return Result.RESULT_UNKNOWN;
			else if (!(oLhs instanceof NumericValue))
				return Result.RESULT_FALSE;
			NumericValue nLhs = (NumericValue) oLhs;

			Object oRhs = rhs.eval(identifiers);
			if (oRhs == null)
				return Result.RESULT_UNKNOWN;
			else if (!(oRhs instanceof NumericValue))
				return Result.RESULT_FALSE;
			NumericValue nRhs = (NumericValue) oRhs;

			return (nLhs.doubleValue() >= nRhs.doubleValue()) ? Result.RESULT_TRUE
					: Result.RESULT_FALSE;
		}

		public Object eval(final IValueProvider provider, final Object corr,
				final IExpression lhs, final IExpression rhs)
		{
			Object oLhs = lhs.eval(provider, corr);
			if (oLhs == null)
				return Result.RESULT_UNKNOWN;
			else if (!(oLhs instanceof NumericValue))
				return Result.RESULT_FALSE;
			NumericValue nLhs = (NumericValue) oLhs;

			Object oRhs = rhs.eval(provider, corr);
			if (oRhs == null)
				return Result.RESULT_UNKNOWN;
			else if (!(oRhs instanceof NumericValue))
				return Result.RESULT_FALSE;
			NumericValue nRhs = (NumericValue) oRhs;

			return (nLhs.doubleValue() >= nRhs.doubleValue()) ? Result.RESULT_TRUE
					: Result.RESULT_FALSE;
		}
	};

	/**
	 * < operator.
	 */
	public static final ArithCompareOpImpl LT = new ArithCompareOpImpl(" < ")
	{
		public Object eval(final Map identifiers, final IExpression lhs,
				final IExpression rhs)
		{
			Object oLhs = lhs.eval(identifiers);
			if (oLhs == null)
				return Result.RESULT_UNKNOWN;
			else if (!(oLhs instanceof NumericValue))
				return Result.RESULT_FALSE;
			NumericValue nLhs = (NumericValue) oLhs;

			Object oRhs = rhs.eval(identifiers);
			if (oRhs == null)
				return Result.RESULT_UNKNOWN;
			else if (!(oRhs instanceof NumericValue))
				return Result.RESULT_FALSE;
			NumericValue nRhs = (NumericValue) oRhs;

			return (nLhs.doubleValue() < nRhs.doubleValue()) ? Result.RESULT_TRUE
					: Result.RESULT_FALSE;
		}

		public Object eval(final IValueProvider provider, final Object corr,
				final IExpression lhs, final IExpression rhs)
		{
			Object oLhs = lhs.eval(provider, corr);
			if (oLhs == null)
				return Result.RESULT_UNKNOWN;
			else if (!(oLhs instanceof NumericValue))
				return Result.RESULT_FALSE;
			NumericValue nLhs = (NumericValue) oLhs;

			Object oRhs = rhs.eval(provider, corr);
			if (oRhs == null)
				return Result.RESULT_UNKNOWN;
			else if (!(oRhs instanceof NumericValue))
				return Result.RESULT_FALSE;
			NumericValue nRhs = (NumericValue) oRhs;

			return (nLhs.doubleValue() < nRhs.doubleValue()) ? Result.RESULT_TRUE
					: Result.RESULT_FALSE;
		}
	};

	/**
	 * <= operator.
	 */
	public static final ArithCompareOpImpl LE = new ArithCompareOpImpl(" <= ")
	{
		public Object eval(final Map identifiers, final IExpression lhs,
				final IExpression rhs)
		{
			Object oLhs = lhs.eval(identifiers);
			if (oLhs == null)
				return Result.RESULT_UNKNOWN;
			else if (!(oLhs instanceof NumericValue))
				return Result.RESULT_FALSE;
			NumericValue nLhs = (NumericValue) oLhs;

			Object oRhs = rhs.eval(identifiers);
			if (oRhs == null)
				return Result.RESULT_UNKNOWN;
			else if (!(oRhs instanceof NumericValue))
				return Result.RESULT_FALSE;
			NumericValue nRhs = (NumericValue) oRhs;

			return (nLhs.doubleValue() <= nRhs.doubleValue()) ? Result.RESULT_TRUE
					: Result.RESULT_FALSE;
		}

		public Object eval(final IValueProvider provider, final Object corr,
				final IExpression lhs, final IExpression rhs)
		{
			Object oLhs = lhs.eval(provider, corr);
			if (oLhs == null)
				return Result.RESULT_UNKNOWN;
			else if (!(oLhs instanceof NumericValue))
				return Result.RESULT_FALSE;
			NumericValue nLhs = (NumericValue) oLhs;

			Object oRhs = rhs.eval(provider, corr);
			if (oRhs == null)
				return Result.RESULT_UNKNOWN;
			else if (!(oRhs instanceof NumericValue))
				return Result.RESULT_FALSE;
			NumericValue nRhs = (NumericValue) oRhs;

			return (nLhs.doubleValue() <= nRhs.doubleValue()) ? Result.RESULT_TRUE
					: Result.RESULT_FALSE;
		}
	};

	private final String operator_;
}
