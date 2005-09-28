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
	
	/// <summary> Class to represent <tt>set</tt> membership operator. Immutable.</summary>
	/// <author>  Jawaid Hakim.
	/// </author>
	class OpIN : IExpressionString
	{
		/// <summary> Ctor.</summary>
		/// <param name="lhs">Data to check for.
		/// </param>
		/// <param name="rhs">Membership set.
		/// </param>
		public OpIN(IExpression lhs, SupportClass.SetSupport rhs)
		{
			lhs_ = lhs;
			rhs_ = rhs;
		}
		
		public virtual System.Object eval(System.Collections.IDictionary identifiers)
		{
			System.Object oLhs = lhs_.eval(identifiers);
			if (!(oLhs is System.String))
				return Result.RESULT_UNKNOWN;
			
			return (rhs_.Contains(oLhs))?Result.RESULT_TRUE:Result.RESULT_FALSE;
		}
		
		public virtual System.Object eval(IValueProvider provider, System.Object corr)
		{
			System.Object oLhs = lhs_.eval(provider, corr);
			if (!(oLhs is System.String))
				return Result.RESULT_UNKNOWN;
			
			return (rhs_.Contains(oLhs))?Result.RESULT_TRUE:Result.RESULT_FALSE;
		}
		
		public override System.String ToString()
		{
			//UPGRADE_TODO: The equivalent in .NET for method 'java.lang.Object.toString' may return a different value. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1043"'
			System.Text.StringBuilder buf = new System.Text.StringBuilder(lhs_.ToString());
			buf.Append(" IN (");
			bool first = true;
			//UPGRADE_TODO: Method 'java.util.Iterator.hasNext' was converted to 'System.Collections.IEnumerator.MoveNext' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javautilIteratorhasNext"'
			for (System.Collections.IEnumerator iter = rhs_.GetEnumerator(); iter.MoveNext(); )
			{
				if (!first)
					buf.Append(',');
				//UPGRADE_TODO: Method 'java.util.Iterator.next' was converted to 'System.Collections.IEnumerator.Current' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javautilIteratornext"'
				buf.Append('\'').Append(iter.Current).Append('\'');
				first = false;
			}
			buf.Append(')');
			return buf.ToString();
		}
		
		//UPGRADE_NOTE: Final was removed from the declaration of 'lhs_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private IExpression lhs_;
		//UPGRADE_NOTE: Final was removed from the declaration of 'rhs_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private SupportClass.SetSupport rhs_;
	}
}