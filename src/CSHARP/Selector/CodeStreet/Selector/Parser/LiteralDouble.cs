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
	
	/// <summary> Class to represent a <tt>Double</tt> literal. Immutable.</summary>
	/// <author>  Jawaid Hakim.
	/// </author>
	class LiteralDouble : IExpressionNumeric
	{
		/// <summary> Factory.</summary>
		/// <param name="literal">Literal.
		/// </param>
		/// <returns> Instance.
		/// </returns>
		//UPGRADE_NOTE: Synchronized keyword was removed from method 'valueOf'. Lock expression was added. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1027"'
		public static LiteralDouble valueOf(System.String literal)
		{
			lock (typeof(CodeStreet.Selector.Parser.LiteralDouble))
			{
				//UPGRADE_TODO: Method 'java.util.Map.get' was converted to 'System.Collections.IDictionary.Item' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javautilMapget_javalangObject"'
				LiteralDouble instance = (LiteralDouble) idMap_[literal];
				if (instance == null)
				{
					instance = new LiteralDouble(literal);
					object tempObject;
					tempObject = instance;
					idMap_[literal] = tempObject;
					System.Object generatedAux = tempObject;
				}
				return instance;
			}
		}
		
		/// <summary> Ctor.</summary>
		/// <param name="literal">Double literal.
		/// </param>
		private LiteralDouble(System.String literal)
		{
			literal_ = new NumericValue(System.Double.Parse(literal));
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
			//UPGRADE_TODO: The equivalent in .NET for method 'java.lang.Object.toString' may return a different value. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1043"'
			return literal_.ToString();
		}
		
		//UPGRADE_NOTE: Final was removed from the declaration of 'literal_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private NumericValue literal_;
		//UPGRADE_TODO: Class 'java.util.HashMap' was converted to 'System.Collections.Hashtable' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javautilHashMap"'
		//UPGRADE_NOTE: The initialization of  'idMap_' was moved to static method 'CodeStreet.Selector.Parser.LiteralDouble'. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1005"'
		private static System.Collections.IDictionary idMap_;
		static LiteralDouble()
		{
			idMap_ = new System.Collections.Hashtable();
		}
	}
}