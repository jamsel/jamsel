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
	
	/// <summary> Class to represent the <tt>String</tt> equality operator. Immutable.</summary>
	/// <author>  Jawaid Hakim.
	/// </author>
	class OpStringEQ : IExpressionString
	{
		/// <summary> Ctor.</summary>
		/// <param name="lhs">LHS.
		/// </param>
		/// <param name="rhs">RHS.
		/// </param>
		public OpStringEQ(IExpression lhs, IExpression rhs)
		{
			lhs_ = lhs;
			rhs_ = rhs;
		}
		
		public virtual System.Object eval(System.Collections.IDictionary identifiers)
		{
			System.Object oLhs = lhs_.eval(identifiers);
			System.Object oRhs = rhs_.eval(identifiers);
			
			return eval(oLhs, oRhs);
		}
		
		public virtual System.Object eval(IValueProvider provider, System.Object corr)
		{
			System.Object oLhs = lhs_.eval(provider, corr);
			System.Object oRhs = rhs_.eval(provider, corr);
			
			return eval(oLhs, oRhs);
		}
		
		private System.Object eval(System.Object oLhs, System.Object oRhs)
		{
			if (!(oLhs is System.String))
				return Result.RESULT_UNKNOWN;
			
			if (!(oRhs is System.String))
				return Result.RESULT_UNKNOWN;
			
			return (oLhs.Equals(oRhs))?Result.RESULT_TRUE:Result.RESULT_FALSE;
		}
		
		//UPGRADE_NOTE: Final was removed from the declaration of 'lhs_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private IExpression lhs_;
		//UPGRADE_NOTE: Final was removed from the declaration of 'rhs_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private IExpression rhs_;
	}
}