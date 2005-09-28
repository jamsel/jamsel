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
	
	/// <summary> Class to represent typesafe enumeration of evaluating a selector or expression. The
	/// enumerations are <tt>TRUE</tt>, <tt>FALSe</tt>. and <tt>RESULT_UNKNOWN</tt>.
	/// </summary>
	/// <author>  Jawaid Hakim.
	/// </author>
	public class Result
	{
		/// <summary> Ctor.</summary>
		/// <param name="result">Result.
		/// </param>
		private Result(System.String result)
		{
			result_ = result;
		}
		
		public override String ToString()
		{
			return result_;
		}

		//UPGRADE_NOTE: Final was removed from the declaration of 'result_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private System.String result_;
		
		/// <summary> TRUE.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'TRUE '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		public static readonly Result RESULT_TRUE = new Result("true");
		
		/// <summary> FALSE.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'FALSE '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		public static readonly Result RESULT_FALSE = new Result("false");
		
		/// <summary> RESULT_UNKNOWN.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'RESULT_UNKNOWN '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		public static readonly Result RESULT_UNKNOWN = new Result("unknown");
	}
}