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
 * Typesafe enumeration of valid conditional operators.
 * 
 * @author Jawaid Hakim.
 */
abstract class ConditionalOpImpl
{
	/**
	 * Ctor.
	 * 
	 * @param operator
	 *            Operator.
	 */
	private ConditionalOpImpl(final String operator)
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
	 * AND operator.
	 */
	public static final ConditionalOpImpl AND = new ConditionalOpImpl(" AND ")
	{
		public Object eval(final Map identifiers, final IExpression lhs,
				final IExpression rhs)
		{
			Result bLhs = (Result) lhs.eval(identifiers);
			// Short circuit evaulation if LHS is FALSE or UNKNOWN
			if (bLhs == Result.RESULT_FALSE)
				return Result.RESULT_FALSE;
			else if (bLhs == Result.RESULT_UNKNOWN)
				return Result.RESULT_UNKNOWN;

			return (Result) rhs.eval(identifiers);
		}

		public Object eval(final IValueProvider provider, final Object corr,
				final IExpression lhs, final IExpression rhs)
		{
			Result bLhs = (Result) lhs.eval(provider, corr);
			// Short circuit evaulation if LHS is FALSE or UNKNOWN
			if (bLhs == Result.RESULT_FALSE)
				return Result.RESULT_FALSE;
			else if (bLhs == Result.RESULT_UNKNOWN)
				return Result.RESULT_UNKNOWN;

			return (Result) rhs.eval(provider, corr);
		}
	};

	/**
	 * OR operator.
	 */
	public static final ConditionalOpImpl OR = new ConditionalOpImpl(" OR ")
	{
		public Object eval(final Map identifiers, final IExpression lhs,
				final IExpression rhs)
		{
			Result bLhs = (Result) lhs.eval(identifiers);
			// Short circuit evaulation if LHS is TRUE
			if (bLhs == Result.RESULT_TRUE)
				return Result.RESULT_TRUE;

			Result bRhs = (Result) rhs.eval(identifiers);
			if (bRhs == Result.RESULT_TRUE)
				return Result.RESULT_TRUE;
			else if (bLhs == Result.RESULT_UNKNOWN
					|| bRhs == Result.RESULT_UNKNOWN)
				return Result.RESULT_UNKNOWN;
			else
				return Result.RESULT_FALSE;
		}

		public Object eval(final IValueProvider provider, final Object corr,
				final IExpression lhs, final IExpression rhs)
		{
			Result bLhs = (Result) lhs.eval(provider, corr);
			// Short circuit evaulation if LHS is TRUE
			if (bLhs == Result.RESULT_TRUE)
				return Result.RESULT_TRUE;

			Result bRhs = (Result) rhs.eval(provider, corr);
			if (bRhs == Result.RESULT_TRUE)
				return Result.RESULT_TRUE;
			else if (bLhs == Result.RESULT_UNKNOWN
					|| bRhs == Result.RESULT_UNKNOWN)
				return Result.RESULT_UNKNOWN;
			else
				return Result.RESULT_FALSE;
		}
	};

	/**
	 * NOT operator.
	 */
	public static final ConditionalOpImpl NOT = new ConditionalOpImpl(" NOT ")
	{
		public Object eval(final Map identifiers, final IExpression lhs,
				final IExpression rhs)
		{
			Result bRhs = (Result) rhs.eval(identifiers);
			if (bRhs == Result.RESULT_TRUE)
				return Result.RESULT_FALSE;
			else if (bRhs == Result.RESULT_FALSE)
				return Result.RESULT_TRUE;
			else
				return Result.RESULT_UNKNOWN;
		}

		public Object eval(final IValueProvider provider, final Object corr,
				final IExpression lhs, final IExpression rhs)
		{
			Result bRhs = (Result) rhs.eval(provider, corr);
			if (bRhs == Result.RESULT_TRUE)
				return Result.RESULT_FALSE;
			else if (bRhs == Result.RESULT_FALSE)
				return Result.RESULT_TRUE;
			else
				return Result.RESULT_UNKNOWN;
		}
	};

	private final String operator_;
}
