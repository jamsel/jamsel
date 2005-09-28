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
	
	/// <summary> Class to represent a <tt>String</tt> literal. Immutable.</summary>
	/// <author>  Jawaid Hakim.
	/// </author>
	class LiteralString : IExpressionString
	{
		/// <summary> Factory.</summary>
		/// <param name="literal">Literal.
		/// </param>
		/// <returns> Instance.
		/// </returns>
		//UPGRADE_NOTE: Synchronized keyword was removed from method 'valueOf'. Lock expression was added. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1027"'
		public static LiteralString valueOf(System.String literal)
		{
			lock (typeof(CodeStreet.Selector.Parser.LiteralString))
			{
				//UPGRADE_TODO: Method 'java.util.Map.get' was converted to 'System.Collections.IDictionary.Item' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javautilMapget_javalangObject"'
				LiteralString instance = (LiteralString) idMap_[literal];
				if (instance == null)
				{
					instance = new LiteralString(literal);
					object tempObject;
					tempObject = instance;
					idMap_[literal] = tempObject;
					System.Object generatedAux = tempObject;
				}
				return instance;
			}
		}
		
		/// <summary> Ctor.</summary>
		/// <param name="literal">String literal.
		/// </param>
		public LiteralString(System.String literal)
		{
			literal_ = literal;
		}
		
		public virtual System.Object eval(System.Collections.IDictionary identifiers)
		{
			return literal_;
		}
		
		public virtual System.Object eval(IValueProvider provider, System.Object corr)
		{
			return literal_;
		}
		
		public override System.String ToString()
		{
			return literal_;
		}
		
		//UPGRADE_NOTE: Final was removed from the declaration of 'literal_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private System.String literal_;
		//UPGRADE_TODO: Class 'java.util.HashMap' was converted to 'System.Collections.Hashtable' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javautilHashMap"'
		//UPGRADE_NOTE: The initialization of  'idMap_' was moved to static method 'CodeStreet.Selector.Parser.LiteralString'. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1005"'
		private static System.Collections.IDictionary idMap_;
		static LiteralString()
		{
			idMap_ = new System.Collections.Hashtable();
		}
	}
}