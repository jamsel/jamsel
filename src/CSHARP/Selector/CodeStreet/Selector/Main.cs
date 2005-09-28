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
using Result = CodeStreet.Selector.Parser.Result;
using CodeStreet.Selector;
using System.Collections;

// import CodeStreet.Selector.jms.ValueProvider;
// using com.tibco.tibrv;
namespace CodeStreet.Selector
{
	
	/*
	import com.tibco.tibjms.*;
	import javax.jms.*;*/
	
	/// <summary> Created by IntelliJ IDEA.
	/// User: jawaid.hakim
	/// Date: Mar 26, 2003
	/// Time: 11:00:08 AM
	/// To change this template use Options | File Templates.
	/// </summary>
	public class Main
	{
		public Main()
		{
		}
		
		[STAThread]
		public static void  Main0(System.String[] args)
		{
			try
			{
				Hashtable dat = new Hashtable();
				dat.Add("Quantity", (int)150);
				dat.Add("Volume", (double)20.5);
				ISelector sel = Selector.getInstance("Quantity > 100 AND Volume < 25");
				Result res = sel.eval(dat);
				System.Console.WriteLine(res.ToString());
			}
			catch (System.Exception ex)
			{
				SupportClass.WriteStackTrace(ex, Console.Error);
			}
		}
	}
}