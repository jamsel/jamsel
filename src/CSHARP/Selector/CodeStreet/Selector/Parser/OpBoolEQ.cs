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
	
	/// <summary> Class to represent the <tt>bool</tt> equality operator. Immutable.</summary>
	/// <author>  Jawaid Hakim.
	/// </author>
	class OpBoolEQ : IExpressionBool
	{
		/// <summary> Ctor.</summary>
		/// <param name="lhs">LHS of the equality.
		/// </param>
		/// <param name="rhs">RHS of the equality.
		/// </param>
		public OpBoolEQ(IExpression lhs, IExpression rhs)
		{
			lhs_ = lhs;
			rhs_ = rhs;
		}
		
		public virtual System.Object eval(System.Collections.IDictionary identifiers)
		{
			System.Object oLhs = lhs_.eval(identifiers);
			if (!(oLhs is System.Boolean))
				return Result.RESULT_UNKNOWN;
			bool lhs = ((System.Boolean) oLhs);
			
			System.Object oRhs = rhs_.eval(identifiers);
			if (!(oRhs is System.Boolean))
				return Result.RESULT_UNKNOWN;
			bool rhs = ((System.Boolean) oRhs);
			
			if (lhs == rhs)
				return Result.RESULT_TRUE;
			else
				return Result.RESULT_FALSE;
		}
		
		public virtual System.Object eval(IValueProvider provider, System.Object corr)
		{
			System.Object oLhs = lhs_.eval(provider, corr);
			if (!(oLhs is System.Boolean))
				return Result.RESULT_UNKNOWN;
			bool lhs = ((System.Boolean) oLhs);
			
			System.Object oRhs = rhs_.eval(provider, corr);
			if (!(oRhs is System.Boolean))
				return Result.RESULT_UNKNOWN;
			bool rhs = ((System.Boolean) oRhs);
			
			if (lhs == rhs)
				return Result.RESULT_TRUE;
			else
				return Result.RESULT_FALSE;
		}
		
		public override System.String ToString()
		{
			//UPGRADE_TODO: The equivalent in .NET for method 'java.lang.Object.toString' may return a different value. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1043"'
			return lhs_.ToString() + " = " + rhs_.ToString();
		}
		
		//UPGRADE_NOTE: Final was removed from the declaration of 'lhs_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private IExpression lhs_;
		//UPGRADE_NOTE: Final was removed from the declaration of 'rhs_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private IExpression rhs_;
	}
}