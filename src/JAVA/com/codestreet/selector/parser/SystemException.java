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

import com.codestreet.selector.parser.BaseException;

/**
 * Exception thrown when a system error condition is trapped. This category of
 * exceptions indicate system exceptions.
 * 
 * @see com.codestreet.selector.parser.BusinessException
 * @author Jawaid Hakim.
 */
public class SystemException extends BaseException
{
	/**
	 * Constructor.
	 * 
	 * @param desc
	 *            Description of exception.
	 */
	public SystemException(String desc)
	{
		super(desc);
	}

	/**
	 * Constructor.
	 * 
	 * @param original
	 *            Original throwable.
	 */
	public SystemException(Throwable original)
	{
		super(original);
	}
}