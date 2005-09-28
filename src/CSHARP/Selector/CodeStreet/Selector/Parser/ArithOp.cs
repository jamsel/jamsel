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
	
	/// <summary> Class to implement arithmetic operators.</summary>
	/// <author>  Jawaid Hakim.
	/// </author>
	class ArithOp : IExpression
	{
		/// <summary> Ctor.</summary>
		/// <param name="op">Arithmetic operator.
		/// </param>
		/// <param name="lhs">LHS.
		/// </param>
		/// <param name="rhs">RHS.
		/// </param>
		public ArithOp(ArithOpImpl op, IExpression lhs, IExpression rhs)
		{
			op_ = op;
			lhs_ = lhs;
			rhs_ = rhs;
		}
		
		public virtual System.Object eval(System.Collections.IDictionary identifiers)
		{
			return op_.eval(identifiers, lhs_, rhs_);
		}
		
		public virtual System.Object eval(IValueProvider provider, System.Object corr)
		{
			return op_.eval(provider, corr, lhs_, rhs_);
		}
		
		public override System.String ToString()
		{
			//UPGRADE_TODO: The equivalent in .NET for method 'java.lang.Object.toString' may return a different value. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1043"'
			return lhs_.ToString() + op_.ToString() + rhs_.ToString();
		}
		
		//UPGRADE_NOTE: Final was removed from the declaration of 'lhs_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private IExpression lhs_;
		//UPGRADE_NOTE: Final was removed from the declaration of 'rhs_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private IExpression rhs_;
		//UPGRADE_NOTE: Final was removed from the declaration of 'op_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private ArithOpImpl op_;
	}
}