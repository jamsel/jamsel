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

package com.codestreet.selector.parser;

import java.util.Map;
import java.util.regex.Pattern;
import java.util.regex.PatternSyntaxException;

/**
 * Class to represent the <tt>LIKE</tt> operator. Immutable.
 * 
 * @author Jawaid Hakim.
 */
class OpLIKE implements IExpressionString
{
	/**
	 * Ctor.
	 * 
	 * @param lhs
	 *            LHS.
	 * @param pattern
	 *            Match pattern.
	 * @param escape
	 *            Optional escape character. May be <tt>null</tt>.
	 * @throws java.lang.IllegalStateException
	 *             Match pattern is invalid.
	 */
	public OpLIKE(final IExpression lhs, final IExpression pattern,
			final IExpression escape)
	{
		lhs_ = lhs;
		pattern_ = pattern;

		esc_ = escape;
		String esc = null;
		if (esc_ != null)
		{
			esc = ((String) esc_.eval(null)).trim();
			if (esc.length() != 1)
				throw new java.lang.IllegalStateException(
						"ESCAPE pattern must be one character: ;" + esc + "'");
		}

		try
		{
			compiledPattern_ = compilePattern((String) pattern.eval(null), esc);
		}
		catch (PatternSyntaxException ex)
		{
			throw new java.lang.IllegalStateException("Invalid match pattern: "
					+ pattern);
		}
	}

	public Object eval(final Map identifiers)
	{
		Object oLhs = lhs_.eval(identifiers);
		if (!(oLhs instanceof String))
			return Result.RESULT_UNKNOWN;

		return (compiledPattern_.matcher((String) oLhs).matches()) ? Result.RESULT_TRUE
				: Result.RESULT_FALSE;
	}

	public Object eval(final IValueProvider provider, final Object corr)
	{
		Object oLhs = lhs_.eval(provider, corr);
		if (!(oLhs instanceof String))
			return Result.RESULT_UNKNOWN;

		return (compiledPattern_.matcher((String) oLhs).matches()) ? Result.RESULT_TRUE
				: Result.RESULT_FALSE;
	}

	public String toString()
	{
		if (esc_ != null)
			return lhs_.toString() + " LIKE '" + pattern_.toString() + "'";
		else
			return lhs_.toString() + " LIKE '" + pattern_.toString()
					+ "' ESCAPE '" + esc_.toString() + "'";
	}

	private static Pattern compilePattern(final String pattern, final String esc)
	{
		// In JMS the wildcard characters are '_' (match any single character)
		// and
		// '%' (match zero or more characters). In regular expressions the
		// equivalent
		// wildcard characters are '.' and '*'.
		// We have to convert JMS wildcard characters in the pattern to regexp
		// wildcard
		// characters taking care of the escape character.
		String regExp = null;
		if (esc == null)
		{
			// No escape character - simply replace JMS wildcards with
			// regular expression wildcards
			regExp = pattern.replaceAll("_", ".{1}").replaceAll("%", ".*");
		}
		else
		{
			char cEsc = '\0';
			StringBuffer buf = new StringBuffer();
			cEsc = esc.charAt(0);
			for (int i = 0; i < pattern.length(); ++i)
			{
				char nextChar = pattern.charAt(i);

				if (nextChar != cEsc)
				{
					// Not an escape character - simply replace JMS wildcard
					// characters with
					// regular expression wildcard characters

					if (nextChar == '_')
						buf.append(".{1}");
					else if (nextChar == '%')
						buf.append(".*");
					else
						buf.append(nextChar);
				}
				else
				{
					// Escape character - replace user-defined escape character
					// with
					// regular expression escape character. Copy the character
					// after
					// the escape character as is since it is being escaped

					buf.append('\\');
					++i;
					if (i < pattern.length())
					{
						buf.append(pattern.charAt(i));
					}
				}
			}
			regExp = buf.toString();
		}
		return Pattern.compile(regExp);
	}

	private final IExpression lhs_;

	private final IExpression esc_;

	private final IExpression pattern_;

	private final Pattern compiledPattern_;
}
