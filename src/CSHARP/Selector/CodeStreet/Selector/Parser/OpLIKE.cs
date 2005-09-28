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
using System.Text.RegularExpressions;
namespace CodeStreet.Selector.Parser
{
	
	/// <summary> Class to represent the <tt>LIKE</tt> operator. Immutable.</summary>
	/// <author>  Jawaid Hakim.
	/// </author>
	class OpLIKE : IExpressionString
	{
		/// <summary> Ctor.</summary>
		/// <param name="lhs">LHS.
		/// </param>
		/// <param name="pattern">Match pattern.
		/// </param>
		/// <param name="escape">Optional escape character. May be <tt>null</tt>.
		/// @throws java.lang.IllegalStateException Match pattern is invalid.
		/// </param>
		public OpLIKE(IExpression lhs, IExpression pattern, IExpression escape)
		{
			lhs_ = lhs;
			pattern_ = pattern;
			
			esc_ = escape;
			System.String esc = null;
			if (esc_ != null)
			{
				esc = ((System.String) esc_.eval(null)).Trim();
				if (esc.Length != 1)
					throw new System.SystemException("ESCAPE pattern must be one character: ;" + esc + "'");
			}
			
			try
			{
				compiledPattern_ = compilePattern((System.String) pattern.eval(null), esc);
			}
			catch (Exception ex)
			{
				//UPGRADE_TODO: The equivalent in .NET for method 'java.lang.Object.toString' may return a different value. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1043"'
				throw new InvalidSelectorException(ex);
			}
		}
		
		public virtual System.Object eval(System.Collections.IDictionary identifiers)
		{
			System.Object oLhs = lhs_.eval(identifiers);
			if (!(oLhs is System.String))
				return Result.RESULT_UNKNOWN;
			
			return (compiledPattern_.IsMatch((System.String) oLhs))?Result.RESULT_TRUE:Result.RESULT_FALSE;
		}
		
		public virtual System.Object eval(IValueProvider provider, System.Object corr)
		{
			System.Object oLhs = lhs_.eval(provider, corr);
			if (!(oLhs is System.String))
				return Result.RESULT_UNKNOWN;
			
			return (compiledPattern_.IsMatch((System.String) oLhs))?Result.RESULT_TRUE:Result.RESULT_FALSE;
		}
		
		public override System.String ToString()
		{
			if (esc_ != null)
			{
				//UPGRADE_TODO: The equivalent in .NET for method 'java.lang.Object.toString' may return a different value. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1043"'
				return lhs_.ToString() + " LIKE '" + pattern_.ToString() + "'";
			}
			else
			{
				//UPGRADE_TODO: The equivalent in .NET for method 'java.lang.Object.toString' may return a different value. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1043"'
				return lhs_.ToString() + " LIKE '" + pattern_.ToString() + "' ESCAPE '" + esc_.ToString() + "'";
			}
		}
		
		private static Regex compilePattern(System.String pattern, System.String escape)
		{
			// In JMS the wildcard characters are '_' (match any single character) and
			// '%' (match zero or more characters). In regular expressions the equivalent
			// wildcard characters are '.' and '*'.
			// We have to convert JMS wildcard characters in the pattern to regexp wildcard
			// characters taking care of the escape character.
			System.String regExp = null;
			System.Text.StringBuilder buf = new System.Text.StringBuilder();
			if ((System.Object) escape == null)
			{
				// No escape character - simply replace JMS wildcards with
				// regular expression wildcards
				for (SupportClass.Tokenizer strTok = new SupportClass.Tokenizer(pattern.Replace('_', '.'), "%"); strTok.HasMoreTokens(); )
				{
					buf.Append(strTok.NextToken());
				}
				regExp = buf.ToString();
			}
			else
			{
				char esc = escape[0];
				for (int i = 0; i < pattern.Length; ++i)
				{
					char nextChar = pattern[i];
					
					if (nextChar != esc)
					{
						// Not an escape character - simply replace JMS wildcard characters with
						// regular expression wildcard characters
						
						if (nextChar == '_')
							buf.Append('.');
						else if (nextChar == '%')
							buf.Append(".*");
						else
							buf.Append(nextChar);
					}
					else
					{
						// Escape character - replace user-defined escape character with
						// regular expression escape character. Copy the character after
						// the escape character as is since it is being escaped
						
						buf.Append('\\');
						++i;
						if (i < pattern.Length)
						{
							buf.Append(pattern[i]);
						}
					}
				}
				regExp = buf.ToString();
			}
			return new Regex(regExp.ToString());
		}
		
		//UPGRADE_NOTE: Final was removed from the declaration of 'lhs_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private IExpression lhs_;
		//UPGRADE_NOTE: Final was removed from the declaration of 'esc_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private IExpression esc_;
		//UPGRADE_NOTE: Final was removed from the declaration of 'pattern_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private IExpression pattern_;
		//UPGRADE_NOTE: Final was removed from the declaration of 'compiledPattern_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private Regex compiledPattern_;
	}
}