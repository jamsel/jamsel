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
	public class Test
	{		
		[STAThread]
		public static void  Main(System.String[] args)
		{
			DoTest1();
			System.Console.WriteLine("");
			DoTest2();
			System.Console.WriteLine("");
			DoTest3();
			System.Console.WriteLine("");
		}

		private static void DoTest1()
		{
			try
			{
				Hashtable dat = new Hashtable();
				dat.Add("Quantity", (int)150);
				dat.Add("Volume", (double)20);
				dat.Add("Price", (double)1234.56);
				dat.Add("Coupon", (decimal)6.5);
				dat.Add("CUSIP", "123456789");

				string selStr = "Coupon > -1.0";
				//string selStr = "CUSIP LIKE '1234%' AND Coupon > 6.5 AND Coupon > -1.0 AND Quantity > 100 AND (Volume < 10 OR Price > 1000)";
				ISelector sel = Selector.getInstance(selStr);
				
				DateTime start = System.DateTime.Now;
				int maxIter = 10;
				for (int i = 0; i < maxIter; ++i)
				{
					Result res = sel.eval(dat);
					if (res == Result.RESULT_TRUE)
					{
						// Success
					}
					else if (res == Result.RESULT_FALSE)
					{
						// Failure
					}
					else
					{
						// Unknown
					}
				}
				DateTime end = System.DateTime.Now;
				TimeSpan diff = end.Subtract(start);
				System.Console.WriteLine("Selector: " + selStr);
				System.Console.WriteLine(maxIter + " evaluations in: " + diff.ToString());
			}
			catch (Exception ex)
			{
				System.Console.WriteLine(ex.StackTrace);
			}
			}

		private static void DoTest2()
		{
			try
			{
				Hashtable dat = new Hashtable();
				dat.Add("TICKER", "MSFT");

				string selStr = "TICKER IN ('TIBX', 'MSFT', 'IBM')";
				ISelector sel = Selector.getInstance(selStr);
				
				DateTime start = System.DateTime.Now;
				int maxIter = 2000000;
				for (int i = 0; i < maxIter; ++i)
				{
					Result res = sel.eval(dat);
					if (res == Result.RESULT_TRUE)
					{
						// Success
					}
					else if (res == Result.RESULT_FALSE)
					{
						// Failure
					}
					else
					{
						// Unknown
					}
				}
				DateTime end = System.DateTime.Now;
				TimeSpan diff = end.Subtract(start);
				System.Console.WriteLine("Selector: " + selStr);
				System.Console.WriteLine(maxIter + " evaluations in: " + diff.ToString());
			}
			catch (Exception ex)
			{
				System.Console.WriteLine(ex.StackTrace);
			}
		}		

		private static void DoTest3()
		{
			try
			{
				Hashtable dat = new Hashtable();
				dat.Add("TICKER", "MSFT");

				string selStr = "TICKER = 'TIBX' OR TICKER = 'MSFT' OR TICKER = 'IBM'";
				ISelector sel = Selector.getInstance(selStr);
				
				DateTime start = System.DateTime.Now;
				int maxIter = 2000000;
				for (int i = 0; i < maxIter; ++i)
				{
					Result res = sel.eval(dat);
					if (res == Result.RESULT_TRUE)
					{
						// Success
					}
					else if (res == Result.RESULT_FALSE)
					{
						// Failure
					}
					else
					{
						// Unknown
					}
				}
				DateTime end = System.DateTime.Now;
				TimeSpan diff = end.Subtract(start);
				System.Console.WriteLine("Selector: " + selStr);
				System.Console.WriteLine(maxIter + " evaluations in: " + diff.ToString());
			}
			catch (Exception ex)
			{
				System.Console.WriteLine(ex.StackTrace);
			}
		}		
	}
}