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

/**
 * Exception thrown when a normal usage error condition is trapped.
 * 
 * @see com.codestreet.selector.parser.SystemException
 * @author Jawaid Hakim.
 */
public class BusinessException extends BaseException
{
	/**
	 * Ctor.
	 * 
	 * @param desc
	 *            Description of exception.
	 */
	public BusinessException(final String desc)
	{
		super(desc);
	}

	/**
	 * Ctor.
	 * 
	 * @param original
	 *            Original throwable.
	 */
	public BusinessException(final Throwable original)
	{
		super(original);
	}
}