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

package com.codestreet.selector.message;

import com.codestreet.selector.parser.IValueProvider;
import com.codestreet.selector.parser.Identifier;

/**
 * @author pcoates
 * 
 * To change the template for this generated type comment go to
 * Window>Preferences>Java>Code Generation>Code and Comments
 */
public abstract class AbstractValueProvider implements IValueProvider
{

	public abstract Object getValue(final Identifier identifier,
			final Object correlation);

	/**
	 * Return the same string minus a leading dot.
	 * 
	 * @param fldName
	 *            Any legal name string
	 * @return The input, minus the leading dot, if any.
	 */
	public static String loseLeadingDot(String fldName)
	{
		return (fldName.indexOf('.') == 0) ? fldName.substring(1) : fldName;
	}

}
