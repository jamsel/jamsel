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
 * Class to represent the <tt>BETWEEN</tt> operator. Immutable.
 * 
 * @author Jawaid Hakim.
 */
class OpBETWEEN implements IExpressionNumeric
{
	/**
	 * Ctor.
	 * 
	 * @param val
	 *            Test value.
	 * @param lower
	 *            Lower limit (inclusive).
	 * @param upper
	 *            Upper limit (inclusive).
	 */
	public OpBETWEEN(final IExpression val, final IExpression lower,
			final IExpression upper)
	{
		val_ = val;
		lower_ = lower;
		upper_ = upper;
	}

	public Object eval(final Map identifiers)
	{
		Object oVal = val_.eval(identifiers);
		Object oLower = lower_.eval(identifiers);
		Object oUpper = lower_.eval(identifiers);

		return eval(oVal, oLower, oUpper);
	}

	/**
	 * Evaluate the expression.
	 * 
	 * @param provider
	 *            Value provider. During the evaluation of the selector a
	 *            callback is made to the value provider to get identifier
	 *            values.
	 * @param corr
	 *            Correlation data. This data is as-is passed to the provider.
	 * @return Returns the result of the expression evaluation.
	 */
	public Object eval(final IValueProvider provider, final Object corr)
	{
		Object oVal = val_.eval(provider, corr);
		Object oLower = lower_.eval(provider, corr);
		Object oUpper = lower_.eval(provider, corr);

		return eval(oVal, oLower, oUpper);
	}

	private Object eval(final Object oVal, final Object oLower,
			final Object oUpper)
	{

		if (!(oVal instanceof NumericValue)
				|| !(oLower instanceof NumericValue)
				|| !(oUpper instanceof NumericValue))
			return Result.RESULT_UNKNOWN;

		double val = ((NumericValue) oVal).doubleValue();

		double lower = ((NumericValue) oLower).doubleValue();
		if (val < lower)
			return Result.RESULT_FALSE;

		double upper = ((NumericValue) oUpper).doubleValue();
		return (val <= upper) ? Result.RESULT_TRUE : Result.RESULT_FALSE;
	}

	public String toString()
	{
		StringBuffer buf = new StringBuffer(val_.toString() + " BETWEEN ");
		buf.append(lower_.toString()).append(" AND ").append(upper_.toString());
		return buf.toString();
	}

	private final IExpression val_;

	private final IExpression lower_;

	private final IExpression upper_;
}
