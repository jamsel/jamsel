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
using CodeStreet.Selector.Parser;
using SelectorParseState = CodeStreet.Selector.Parser.SelectorParser.SelectorParseState;
namespace CodeStreet.Selector
{
	
	/// <summary> Thread safe Selector implementation.</summary>
	/// <author>  Jawaid Hakim.
	/// </author>
	public class Selector : ISelector
	{
		/// <summary> Get identifiers used by the selector. The key into the <tt>Map</tt> is 
		/// the name of the identifier and the value is an instance of <tt>Identifier</tt>.
		/// </summary>
		/// <returns> Readonly <tt>Map</tt> of identifiers that are used within the selector.
		/// @throws UnsupportedOperationException
		/// </returns>
		/// <seealso cref="#eval(Map)">
		/// </seealso>
		virtual public System.Collections.IDictionary Identifiers
		{
			get
			{
				return identifiers_;
			}
			
		}
		/// <summary> Factory.</summary>
		/// <param name="selector">Selector.
		/// </param>
		/// <returns>  Selector instance.
		/// @throws NullPointerException
		/// </returns>
		/// <seealso cref="boolean)">
		/// </seealso>
		public static Selector getInstance(System.String selector)
		{
			return getInstance(selector, false);
		}
		
		/// <summary> Factory.</summary>
		/// <param name="selector">Selector.
		/// </param>
		/// <param name="trace">Parser outputs trace if <tt>true</tt> .
		/// </param>
		/// <returns> Selector instance.
		/// @throws NullPointerException
		/// @throws CodeStreet.Selector.Parser.InvalidSelectorException
		/// </returns>
		/// <seealso cref="#getInstance(String)">
		/// </seealso>
		public static Selector getInstance(System.String selector, bool trace)
		{
			if ((System.Object) selector == null)
				throw new System.NullReferenceException("NULL selector");
			
			SelectorParseState exp = SelectorParser.doParse(selector, trace);
			return new Selector(selector, exp.Root, exp.Identifiers);
		}
		
		/// <summary> Ctor.</summary>
		/// <param name="selector">Selector.
		/// </param>
		/// <param name="root">Root expression of the parsed selector.
		/// </param>
		/// <param name="identifiers">Identifiers used by the selector. The key
		/// into the <tt>Map</tt> is name of the identifier and the value is an
		/// instance of <tt>Identifier</tt>.
		/// </param>
		private Selector(System.String selector, IExpression root, System.Collections.IDictionary identifiers)
		{
			selector_ = selector;
			root_ = root;
			//UPGRADE_ISSUE: Method 'java.util.Collections.unmodifiableMap' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javautilCollectionsunmodifiableMap_javautilMap"'
			identifiers_ = identifiers;
		}
		
		/// <summary> Evaluate the selector.</summary>
		/// <param name="identifiers">Value for each non-null identifier in the selector.
		/// </param>
		/// <returns> Result of evaluating the selector.
		/// </returns>
		/// <seealso cref="#getIdentifiers()">
		/// </seealso>
		public virtual Result eval(System.Collections.IDictionary identifiers)
		{
			return (Result) root_.eval(identifiers);
		}
		
		/// <summary> Evaluate the selector.</summary>
		/// <param name="provider">Value provider. During evaluation of the selector callbacks
		/// are made on the value provider to get identifier values.
		/// </param>
		/// <param name="corr">Correlation data. Passed as-is to the value provider.
		/// </param>
		/// <returns> Result of evaluating the selector.
		/// </returns>
		public virtual Result eval(IValueProvider provider, System.Object corr)
		{
			return (Result) root_.eval(provider, corr);
		}
		
		/// <summary> Get the selector.</summary>
		/// <returns> Selector.
		/// </returns>
		public virtual System.String getSelector()
		{
			return selector_;
		}
		
		/// <summary> Get selector parse tree.</summary>
		/// <returns> Selector parse tree.
		/// </returns>
		public override System.String ToString()
		{
			return selector_;
		}
		
		//UPGRADE_NOTE: Final was removed from the declaration of 'root_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private IExpression root_;
		//UPGRADE_NOTE: Final was removed from the declaration of 'identifiers_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private System.Collections.IDictionary identifiers_;
		//UPGRADE_NOTE: Final was removed from the declaration of 'selector_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private System.String selector_;
	}
}