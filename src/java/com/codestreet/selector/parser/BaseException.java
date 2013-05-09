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

import java.io.PrintStream;
import java.io.PrintWriter;
import java.io.StringWriter;

/**
 * Base class for exceptions. Allows exception chaining.
 * 
 * @author Jawaid Hakim.
 */
public class BaseException extends Exception
{
	/**
	 * Ctor.
	 */
	public BaseException()
	{
	}

	/**
	 * Ctor.
	 * 
	 * @param message
	 *            a <tt>String</tt> value
	 */
	public BaseException(final String message)
	{
		super(message);
	}

	/**
	 * Ctor.
	 * 
	 * @param root
	 *            Root cause of exception. Cannot be <tt>null</tt>.
	 */
	public BaseException(final Throwable root)
	{
		super();
		if (root != null)
		{
			this.previousCause = root;
			stackTraceString = generateStackTraceString(root);
		}
		else
		{
			this.previousCause = new Exception(
					"ERROR: A null value for root was passed to the constructor of RBaseException");
			stackTraceString = generateStackTraceString(this.previousCause);
		}
	}

	/**
	 * Ctor.
	 * 
	 * @param message
	 *            Message to describe the exception
	 * @param root
	 *            Root cause of exception. Cannot be <tt>null</tt>.
	 */
	public BaseException(final String msg, final Throwable root)
	{
		super(msg);
		if (root != null)
		{
			this.previousCause = root;
			stackTraceString = generateStackTraceString(root);
		}
		else
		{
			this.previousCause = new Exception(
					"ERROR: A null value for root was passed to the constructor of RBaseException");
			stackTraceString = generateStackTraceString(this.previousCause);
		}
	}

	/**
	 * Create a new <tt>RBaseException</tt> instance. Allows for an
	 * association of an originating exception.
	 * 
	 * @param msg
	 *            Message to describe the exception
	 * @param inserts
	 *            an <tt>Object[]</tt> value
	 * @param root
	 *            Root cause of exception. Cannot be <tt>null</tt>.
	 */
	public BaseException(final String msg, final Object[] inserts,
			final Throwable root)
	{
		super(msg);
		if (root != null)
		{
			this.previousCause = root;
			stackTraceString = generateStackTraceString(root);
		}
		else
		{
			this.previousCause = new Exception(
					"ERROR: A null value for root was passed to the constructor of RBaseException");
			stackTraceString = generateStackTraceString(this.previousCause);
		}
	}

	/**
	 * Create a new <tt>RBaseException</tt> instance. Allows for an
	 * association of an originating exception.
	 * 
	 * @param msg
	 *            Message to describe the exception
	 * @param insert
	 *            an <tt>Object</tt> value
	 * @param root
	 *            Root cause of exception. Cannot be <tt>null</tt>.
	 */
	public BaseException(final String msg, final Object insert,
			final Throwable root)
	{
		super(msg);
		if (root != null)
		{
			this.previousCause = root;
			stackTraceString = generateStackTraceString(root);
		}
		else
		{
			this.previousCause = new Exception(
					"ERROR: A null value for rootCause was passed to the constructor of RBaseException");
			stackTraceString = generateStackTraceString(this.previousCause);
		}
	}

	/**
	 * Get root cause of exception.
	 * 
	 * @return Root exception.
	 */
	public Throwable getRootCause()
	{
		return previousCause;
	}

	/**
	 * Return the stack trace including root cause exceptions.
	 * 
	 * @return The stack trace of the exception.
	 */
	public String getStackTraceString()
	{
		// if there's no nested exception, there's no stackTrace
		if (previousCause == null)
			return null;

		StringBuffer traceBuffer = new StringBuffer();

		if (previousCause instanceof BaseException)
		{

			traceBuffer.append(((BaseException) previousCause)
					.getStackTraceString());
			traceBuffer.append("-------- nested by:\n");
		}

		traceBuffer.append(stackTraceString);
		return traceBuffer.toString();
	}

	// overrides Exception.getMessage()
	/**
	 * Override Exceptin.getMessage to include information of the root causeo of
	 * the exception.
	 * 
	 * @return The exception msg, including root cause messages.
	 */
	public String getMessage()
	{
		String baseMsg = super.getMessage();

		// if there's no nested exception, do like we would always do
		if (getRootCause() == null)
			return baseMsg;

		StringBuffer theMsg = new StringBuffer();

		// get the nested exception's msg
		String previousMsg = getRootCause().getMessage();

		if (baseMsg != null)
			theMsg.append(baseMsg).append(": ").append(previousMsg);
		else
			theMsg.append(previousMsg);

		return theMsg.toString();
	}

	// overrides Exception.toString()
	public String toString()
	{
		StringBuffer theMsg = new StringBuffer(super.toString());

		if (getRootCause() != null)
			theMsg.append("; \n\t---> nested ").append(getRootCause());

		return theMsg.toString();
	}

	public void printStackTrace()
	{
		super.printStackTrace();
		if (this.previousCause != null)
		{
			this.previousCause.printStackTrace();
		}
	}

	public void printStackTrace(final PrintStream inPrintStream)
	{
		super.printStackTrace(inPrintStream);
		if (this.previousCause != null)
		{
			this.previousCause.printStackTrace(inPrintStream);
		}
	}

	public static String generateStackTraceString(final Throwable t)
	{
		StringWriter s = new StringWriter();
		t.printStackTrace(new PrintWriter(s));
		return s.toString();

	}

	private Throwable previousCause = null;

	private String stackTraceString;
}
