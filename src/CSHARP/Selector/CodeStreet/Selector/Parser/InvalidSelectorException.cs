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
	
	/// <summary> Exception thrown selector is invalid.</summary>
	/// <seealso cref="com.codestreet.parser.BusinessException">
	/// </seealso>
	/// <author>  Jawaid Hakim.
	/// </author>
	public class InvalidSelectorException:BusinessException
	{
		/// <summary> Ctor.</summary>
		/// <param name="desc">Description of exception.
		/// </param>
		public InvalidSelectorException(System.String desc):base(desc)
		{
		}
		
		/// <summary> Ctor.</summary>
		/// <param name="root">Root throwable.
		/// </param>
		//UPGRADE_NOTE: Exception 'java.lang.Throwable' was converted to 'System.Exception' which has different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1100"'
		public InvalidSelectorException(System.Exception root):base(root)
		{
		}

		public InvalidSelectorException(String desc, System.Exception root):base(desc, root)
		{
		}
	}
}