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
	
	/// <summary> Class to represent <tt>immutable</tt> <tt>Bool</tt> literals.</summary>
	/// <author>  Jawaid Hakim.
	/// </author>
	class LiteralBool : IExpressionBool
	{
		/// <summary> Factory.</summary>
		/// <param name="literal">Literal. Must be either <tt>true</tt>, or <tt>TRUE</tt>, 
		/// or <tt>True</tt>, or <tt>false</tt>, or <tt>FALSE</tt>, or <tt<False</tt>.
		/// </param>
		/// <returns> Instance.
		/// @throws java.lang.IllegalArgumentException Invalid literal.
		/// </returns>
		//UPGRADE_NOTE: Synchronized keyword was removed from method 'valueOf'. Lock expression was added. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1027"'
		public static LiteralBool valueOf(System.String literal)
		{
			lock (typeof(CodeStreet.Selector.Parser.LiteralBool))
			{
				//UPGRADE_TODO: Method 'java.util.Map.get' was converted to 'System.Collections.IDictionary.Item' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javautilMapget_javalangObject"'
				LiteralBool ret = (LiteralBool) idMap_[literal];
				if (ret == null)
					throw new System.ArgumentException("Invalid literal: " + literal);
				return ret;
			}
		}
		
		/// <summary> Ctor.</summary>
		/// <param name="literal">Literal.
		/// </param>
		private LiteralBool(System.String literal)
		{
			//UPGRADE_NOTE: Exceptions thrown by the equivalent in .NET of method 'java.lang.Boolean.valueOf' may be different. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1099"'
			literal_ = System.Boolean.Parse(literal);
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
			//UPGRADE_TODO: The equivalent in .NET for method 'java.lang.Boolean.toString' may return a different value. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1043"'
			return literal_.ToString();
		}
		
		//UPGRADE_NOTE: Final was removed from the declaration of 'literal_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private System.Boolean literal_;
		//UPGRADE_TODO: Class 'java.util.HashMap' was converted to 'System.Collections.Hashtable' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javautilHashMap"'
		//UPGRADE_NOTE: The initialization of  'idMap_' was moved to static method 'CodeStreet.Selector.Parser.LiteralBool'. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1005"'
		private static System.Collections.IDictionary idMap_;
		static LiteralBool()
		{
			idMap_ = new System.Collections.Hashtable();
			{
				LiteralBool literal = new LiteralBool("true");
				object tempObject;
				tempObject = literal;
				idMap_["true"] = tempObject;
				System.Object generatedAux = tempObject;
				object tempObject2;
				tempObject2 = literal;
				idMap_["TRUE"] = tempObject2;
				System.Object generatedAux2 = tempObject2;
				object tempObject3;
				tempObject3 = literal;
				idMap_["True"] = tempObject3;
				System.Object generatedAux3 = tempObject3;
				
				literal = new LiteralBool("false");
				object tempObject4;
				tempObject4 = literal;
				idMap_["false"] = tempObject4;
				System.Object generatedAux4 = tempObject4;
				object tempObject5;
				tempObject5 = literal;
				idMap_["FALSE"] = tempObject5;
				System.Object generatedAux5 = tempObject5;
				object tempObject6;
				tempObject6 = literal;
				idMap_["False"] = tempObject6;
				System.Object generatedAux6 = tempObject6;
			}
		}
	}
}