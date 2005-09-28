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

using System;
namespace CodeStreet.Selector.Parser
{
	
	/// <summary> Class to encapsulate numeric values.<p>
	/// This class allows easier conversion to <tt>C#</tt> using the JLCA tool from Microsoft since there 
	/// is no <tt>Number</tt> class in <tt>C#</tt>.
	/// </summary>
	/// <author>  jawaid.hakim
	/// </author>
	public class NumericValue
	{
		/// <summary> Ctor.</summary>
		/// <param name="value">Value.
		/// </param>
		public NumericValue(System.Object value_Renamed)
		{
			value_ = value_Renamed;
		}

		/// <summary> Ctor.</summary>
		/// <param name="value">Value.
		/// </param>
		public NumericValue(System.Double value_Renamed)
		{
			value_ = value_Renamed;
		}
		
		/// <summary> Ctor.</summary>
		/// <param name="value">Value.
		/// </param>
		public NumericValue(System.Single value_Renamed)
		{
			value_ = value_Renamed;
		}
		
		/// <summary> Ctor.</summary>
		/// <param name="value">Value.
		/// </param>
		public NumericValue(System.Int64 value_Renamed)
		{
			value_ = value_Renamed;
		}
		
		/// <summary> Ctor.</summary>
		/// <param name="value">Value.
		/// </param>
		public NumericValue(System.Int32 value_Renamed)
		{
			value_ = value_Renamed;
		}
		
		/// <summary> Ctor.</summary>
		/// <param name="value">Value.
		/// </param>
		public NumericValue(System.Byte value_Renamed)
		{
			value_ = value_Renamed;
		}
		
		/// <summary> Ctor.</summary>
		/// <param name="value">Value.
		/// </param>
		public NumericValue(System.Int16 value_Renamed)
		{
			value_ = value_Renamed;
		}
		
		/// <summary> Ctor.</summary>
		/// <param name="value">Value.
		/// </param>
		public NumericValue(System.Decimal value_Renamed)
		{
			value_ = value_Renamed;
		}

		/// <summary> Get <tt>double</tt> value.</summary>
		/// <returns> Double value.
		/// </returns>
		public virtual double doubleValue()
		{
			return Convert.ToDouble(value_);
		}
		
		private System.Object value_;
	}
}