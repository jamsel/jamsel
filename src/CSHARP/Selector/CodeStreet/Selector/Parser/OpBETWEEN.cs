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
	
	/// <summary> Class to represent the <tt>BETWEEN</tt> operator. Immutable.</summary>
	/// <author>  Jawaid Hakim.
	/// </author>
	class OpBETWEEN : IExpressionNumeric
	{
		/// <summary> Ctor.</summary>
		/// <param name="val">Test value.
		/// </param>
		/// <param name="lower">Lower limit (inclusive).
		/// </param>
		/// <param name="upper">Upper limit (inclusive).
		/// </param>
		public OpBETWEEN(IExpression val, IExpression lower, IExpression upper)
		{
			val_ = val;
			lower_ = lower;
			upper_ = upper;
		}
		
		public virtual System.Object eval(System.Collections.IDictionary identifiers)
		{
			System.Object oVal = val_.eval(identifiers);
			System.Object oLower = lower_.eval(identifiers);
			System.Object oUpper = lower_.eval(identifiers);
			
			return eval(oVal, oLower, oUpper);
		}
		
		/// <summary> Evaluate the expression.</summary>
		/// <param name="provider">Value provider. During the evaluation of the selector a callback
		/// is made to the value provider to get identifier values.
		/// </param>
		/// <param name="corr">Correlation data. This data is as-is passed to the provider.
		/// </param>
		/// <returns> Returns the result of the expression evaluation.
		/// </returns>
		public virtual System.Object eval(IValueProvider provider, System.Object corr)
		{
			System.Object oVal = val_.eval(provider, corr);
			System.Object oLower = lower_.eval(provider, corr);
			System.Object oUpper = lower_.eval(provider, corr);
			
			return eval(oVal, oLower, oUpper);
		}
		
		private System.Object eval(System.Object oVal, System.Object oLower, System.Object oUpper)
		{
			
			if (!(oVal is NumericValue) || !(oLower is NumericValue) || !(oUpper is NumericValue))
				return Result.RESULT_UNKNOWN;
			
			double val = ((NumericValue) oVal).doubleValue();
			
			double lower = ((NumericValue) oLower).doubleValue();
			if (val < lower)
				return Result.RESULT_FALSE;
			
			double upper = ((NumericValue) oUpper).doubleValue();
			return (val <= upper)?Result.RESULT_TRUE:Result.RESULT_FALSE;
		}
		
		public override System.String ToString()
		{
			//UPGRADE_TODO: The equivalent in .NET for method 'java.lang.Object.toString' may return a different value. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1043"'
			System.Text.StringBuilder buf = new System.Text.StringBuilder(val_.ToString() + " BETWEEN ");
			//UPGRADE_TODO: The equivalent in .NET for method 'java.lang.Object.toString' may return a different value. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1043"'
			buf.Append(lower_.ToString()).Append(" AND ").Append(upper_.ToString());
			return buf.ToString();
		}
		
		//UPGRADE_NOTE: Final was removed from the declaration of 'val_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private IExpression val_;
		//UPGRADE_NOTE: Final was removed from the declaration of 'lower_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private IExpression lower_;
		//UPGRADE_NOTE: Final was removed from the declaration of 'upper_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private IExpression upper_;
	}
}