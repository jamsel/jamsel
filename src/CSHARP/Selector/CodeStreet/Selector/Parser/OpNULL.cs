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
	
	/// <summary> Class to represent the <tt>null</tt> operator. This operator checks whether
	/// the value of an identifier is <tt>null</tt>. Immutable.
	/// </summary>
	/// <author>  Jawaids Hakim.
	/// </author>
	class OpNULL : IExpression
	{
		/// <summary> Ctor.</summary>
		/// <param name="id">Identifer.
		/// </param>
		public OpNULL(IExpression id)
		{
			id_ = id;
		}
		
		public virtual System.Object eval(System.Collections.IDictionary identifiers)
		{
			return (id_.eval(identifiers) == null)?Result.RESULT_TRUE:Result.RESULT_FALSE;
		}
		
		public virtual System.Object eval(IValueProvider provider, System.Object corr)
		{
			return (id_.eval(provider, corr) == null)?Result.RESULT_TRUE:Result.RESULT_FALSE;
		}
		
		public override System.String ToString()
		{
			//UPGRADE_TODO: The equivalent in .NET for method 'java.lang.Object.toString' may return a different value. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1043"'
			return id_.ToString() + " IS NULL";
		}
		
		//UPGRADE_NOTE: Final was removed from the declaration of 'id_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private IExpression id_;
	}
}