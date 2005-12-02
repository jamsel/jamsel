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

package com.codestreet.selector;

import com.codestreet.selector.parser.Result;
import com.codestreet.selector.rv.ValueProvider;
import com.codestreet.selector.parser.NumericValue;

// import com.codestreet.selector.jms.ValueProvider;
import com.tibco.tibrv.*;
import java.math.BigDecimal;
import java.util.Hashtable;

/*
 * import com.tibco.tibjms.*; import javax.jms.*;
 */

/**
 * Created by IntelliJ IDEA. User: jawaid.hakim Date: Mar 26, 2003 Time:
 * 11:00:08 AM To change this template use Options | File Templates.
 */
public class Main
{
	public Main()
	{
	}

	public static void main(String[] args)
	{
		try
		{
			{
				/*
				 * com.tibco.tibjms.TibjmsConnectionFactory connFact = new
				 * com.tibco.tibjms.TibjmsConnectionFactory("tcp://localhost:7222");
				 * Connection conn = connFact.createConnection(); Session sess =
				 * conn.createSession(false, Session.AUTO_ACKNOWLEDGE);
				 * 
				 * MapMessage mapMsg = sess.createMapMessage();
				 * mapMsg.setStringProperty("MessageName", "CreateOrder");
				 * mapMsg.setDoubleProperty("Quantity", 101.0);
				 * mapMsg.setDoubleProperty("Price", 100.0);
				 * mapMsg.setDoubleProperty("MinLot", 50);
				 * mapMsg.setBooleanProperty("JMS_TIBCO_MSG_EXT", true);
				 * MapMessage nestedMapMsg = sess.createMapMessage();
				 * nestedMapMsg.setStringProperty("MessageName", "CreateOrder");
				 * mapMsg.setObject("Nested", nestedMapMsg);
				 * 
				 * ValueProvider ext = new ValueProvider(mapMsg);
				 * 
				 * //String selector = "Quantity > 100 AND Price < 100 OR MinLot >=
				 * 50 AND MessageName in ('foo', 'goo', 'too', 'CreateOrder',
				 * 'last')"; //String selector = "MessageName in ('foo', 'goo',
				 * 'too', 'CreateOrder', 'last', '1', '2', '3', '4', '5', 'a',
				 * 'b', 'c', 'd')"; String selector = "JMSPriority >= 0 AND
				 * Quantity > 100 AND MessageName in ('foo', 'goo', 'too',
				 * 'CreateOrder', 'last', '1', '2', '3', '4', '5', 'a', 'b',
				 * 'c', 'd')"; //String selector = "Quantity > 100 AND Price <
				 * 100 OR MinLot >= 50"; // String selector = "MessageName LIKE
				 * 'Create_r%#%' ESCAPE '#' AND Price <= 100 OR Quantity > 100
				 * AND MinLot >= 50"; //String selector = "MessageName LIKE
				 * 'Create_r\\_%' ESCAPE '\\'"; Selector csselector =
				 * Selector.getInstance(selector);
				 * 
				 * //System.out.println(csselector.toString());
				 *  // Get the list of identifiers that the parser found. For
				 * each identifier - set the // value appropriately. //Map idMap =
				 * csselector.getIdentifiers();
				 *  // Evaluate the selector many times and print out the time.
				 * long start = System.currentTimeMillis(); long upper =
				 * 2000000; for (long i = 0; i < upper; ++i) { /* // Set
				 * identifier values Map idValues = new java.util.HashMap(); for
				 * (java.util.Iterator iter = idMap.keySet().iterator();
				 * iter.hasNext(); ) { String id = (String)iter.next(); if
				 * (id.equals("Quantity")) idValues.put(id, new Double(101));
				 * else if (id.equals("MessageName")) idValues.put(id,
				 * "CreateOrder"); else if (id.equals("Price")) idValues.put(id,
				 * new Double(100)); else if (id.equals("MinLot"))
				 * idValues.put(id, new Double(50)); }
				 */

				/*
				 * // Evaluate selector csselector.eval(ext, null); } long end =
				 * System.currentTimeMillis(); System.out.println(upper + "
				 * evaluations of '" + selector + "' in " + ((end - start) /
				 * 1000) + " seconds");
				 */
			}

			{
				java.util.Map map = new java.util.HashMap();
				map.put("SecurityID", "TIBX");
				map.put("Quantity", new NumericValue(new Integer(101)));
				map.put("Volume", new NumericValue(new Double(25.5)));

				String selector = "Quantity > -100 AND Volume <= 50.5";
				//String selector = "SecurityID = 'TIBX' AND Quantity > 100 AND Volume <= 50.5";
				Selector csselector = Selector.getInstance(selector);

				/*
				 * TibrvMsg rvMsg = new TibrvMsg(); rvMsg.add("Quantity", new
				 * Double(101)); rvMsg.add("Price", new Double(100));
				 * rvMsg.add("MinLot", new Double(50)); rvMsg.add("MessageName",
				 * "CreateOrder"); rvMsg.add("JMSPriority", new Integer(0));
				 * TibrvMsg nested = new TibrvMsg(); nested.add("MessageName",
				 * "CreateOrder%"); rvMsg.add("Nested", nested);
				 * 
				 * ValueProvider ext = ValueProvider.valueOf(rvMsg);
				 * 
				 */

				// String selector = "MessageName in ('foo', 'goo', 'too',
				// 'CreateOrder', 'last', '1', '2', '3', '4', '5', 'a', 'b',
				// 'c', 'd')";
				// String selector = "MessageName in ('foo', 'goo', 'too',
				// 'CreateOrder', 'last', '1', '2', '3', '4', '5', 'a', 'b',
				// 'c', 'd')";
				// String selector = "JMSPriority >= 0 AND Quantity > 100 AND
				// MessageName in ('foo', 'goo', 'too', 'CreateOrder', 'last',
				// '1', '2', '3', '4', '5', 'a', 'b', 'c', 'd')";
				// String selector = "Quantity > 100 AND Price < 100 OR MinLot
				// >= 50";
				// String selector = "MessageName LIKE 'CreateOr%' ESCAPE '#'
				// AND Price <= 100 OR Quantity > 100 AND MinLot >= 50";
				// String selector = "MessageName LIKE 'Create_r\\_%' ESCAPE
				// '\\'";
				// System.out.println(csselector.toString());
				// Get the list of identifiers that the parser found. For each
				// identifier - set the
				// value appropriately.
				// Map idMap = csselector.getIdentifiers();
				// Evaluate the selector many times and print out the time.
				long start = System.currentTimeMillis();
				long upper = 2000000;
				for (long i = 0; i < upper; ++i)
				{
					/*
					 * // Set identifier values Map idValues = new
					 * java.util.HashMap(); for (java.util.Iterator iter =
					 * idMap.keySet().iterator(); iter.hasNext(); ) { String id =
					 * (String)iter.next(); if (id.equals("Quantity"))
					 * idValues.put(id, new Double(101)); else if
					 * (id.equals("MessageName")) idValues.put(id,
					 * "CreateOrder"); else if (id.equals("Price"))
					 * idValues.put(id, new Double(100)); else if
					 * (id.equals("MinLot")) idValues.put(id, new Double(50)); }
					 */

					// Evaluate selector
					Result result = csselector.eval(map);
					System.out.println(result.toString());
				}
				long end = System.currentTimeMillis();
				System.out.println(upper + " evaluations of '" + selector
						+ "' in " + ((end - start) / 1000) + " seconds");
			}

		}
		catch (Exception ex)
		{
			ex.printStackTrace();
		}
	}
}
