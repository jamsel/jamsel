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

import java.math.BigDecimal;

/**
 * Class to encapsulate numeric values.
 * <p>
 * This class allows easier conversion to <tt>C#</tt> using the JLCA tool from
 * Microsoft since there is no <tt>Number</tt> class in <tt>C#</tt>.
 * 
 * @author jawaid.hakim
 */
public class NumericValue
{
	/**
	 * Ctor.
	 * 
	 * @param value
	 *            Value.
	 */
	public NumericValue(final Double value)
	{
		value_ = value;
	}

	/**
	 * Ctor.
	 * 
	 * @param value
	 *            Value.
	 */
	public NumericValue(final Float value)
	{
		value_ = value;
	}

	/**
	 * Ctor.
	 * 
	 * @param value
	 *            Value.
	 */
	public NumericValue(final Long value)
	{
		value_ = value;
	}

	/**
	 * Ctor.
	 * 
	 * @param value
	 *            Value.
	 */
	public NumericValue(final Integer value)
	{
		value_ = value;
	}

	/**
	 * Ctor.
	 * 
	 * @param value
	 *            Value.
	 */
	public NumericValue(final Byte value)
	{
		value_ = value;
	}

	/**
	 * Ctor.
	 * 
	 * @param value
	 *            Value.
	 */
	public NumericValue(final Short value)
	{
		value_ = value;
	}

	/**
	 * Ctor.
	 * 
	 * @param value
	 *            Value.
	 */
	public NumericValue(final BigDecimal value)
	{
		value_ = value;
	}

	/**
	 * Get <tt>double</tt> value.
	 * 
	 * @return Double value.
	 */
	public double doubleValue()
	{
		return ((Number) value_).doubleValue();
	}

	private Object value_;
}
