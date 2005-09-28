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
using IValueProvider = CodeStreet.Selector.Parser.IValueProvider;
using Result = CodeStreet.Selector.Parser.Result;
namespace CodeStreet.Selector
{
	
	/// <summary> Interface implemented by selectors.</summary>
	/// <author>  Jawaid Hakim.
	/// </author>
	public interface ISelector
		{
			/// <summary> Get identifiers used by the selector. The key into the <tt>Map</tt> is 
			/// the name of the identifier and the value is an instance of <tt>Identifier</tt>.
			/// </summary>
			/// <returns> Readonly <tt>Map</tt> of identifiers that are used within the selector.
			/// @throws UnsupportedOperationException
			/// </returns>
			/// <seealso cref="#eval(Map)">
			/// </seealso>
			System.Collections.IDictionary Identifiers
			{
				get;
				
			}
			/// <summary> Evaluate the selector.</summary>
			/// <param name="identifiers">Value for each non-null identifier in the selector.
			/// </param>
			/// <returns> Returns <tt>true</tt> if the data passes the selector. Otherwise, returns
			/// <tt>false</tt>.
			/// </returns>
			/// <seealso cref="#getIdentifiers()">
			/// </seealso>
			Result eval(System.Collections.IDictionary identifiers);
			
			/// <summary> Evaluate the selector.</summary>
			/// <param name="provider">Value provider. During evaluation of the selector callbacks
			/// are made on the value provider to get identifier values.
			/// </param>
			/// <param name="corr">Correlation data. Passed as-is to the value provider.
			/// </param>
			/// <returns> Result evaluating the selector.
			/// </returns>
			Result eval(IValueProvider provider, System.Object corr);
			
			/// <summary> Get the selector.</summary>
			/// <returns> Selector.
			/// </returns>
			System.String getSelector();
		}
}