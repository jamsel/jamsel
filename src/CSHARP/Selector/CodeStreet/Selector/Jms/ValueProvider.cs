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
using IValueProvider = CodeStreet.Selector.Parser.IValueProvider;
using Identifier = CodeStreet.Selector.Parser.Identifier;
using NumericValue = CodeStreet.Selector.Parser.NumericValue;
// JMS

using TIBCO.EMS;

namespace CodeStreet.Selector.Jms
{
	
	/// <summary> Value provider for JMS. As an extension to the JMS specification, this implementation allows values to be 
	/// extracted from <tt>JMS</tt> message <tt>body</tt> using a <tt>dot</tt> notation.<p>
	/// The <tt>dot</tt> notation provides reference to message body fields. For example, <tt>.order.quantity</tt> 
	/// would access the <tt>quantity</tt> field of the nested sub-message field <tt>order</tt>, if it exists. If the 
	/// field does not exist, it returns <tt>null</tt>.
	/// </summary>
	/// <author>  Jawaid Hakim.
	/// </author>
	public class ValueProvider : IValueProvider
	{
		/// <summary> Factory.</summary>
		/// <param name="msg">Message to extract values from.
		/// </param>
		/// <returns> Instance.
		/// </returns>
		//UPGRADE_TODO: Interface 'javax.jms.Message' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
		public static ValueProvider valueOf(Message msg)
		{
			return new ValueProvider(msg);
		}
		
		/// <summary> Ctor.</summary>
		/// <param name="msg"><tt>Message</tt> from which to extract values.<p>
		/// For example, <tt>order.quantity</tt> would select the <tt>quantity</tt> field of the 
		/// nested sub-message field <tt>order</tt> if it exists. If the field does not exist, it 
		/// returns <tt>null</tt>.
		/// </param>
		/// <seealso cref="Object)">
		/// </seealso>
		//UPGRADE_TODO: Interface 'javax.jms.Message' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
		private ValueProvider(Message msg)
		{
			msg_ = msg;
		}
		
		/// <summary> Get the value of the specified identifier.</summary>
		/// <param name="identifier">Field identifier.
		/// </param>
		/// <param name="correlation">Application correlation data. May be <tt>null</tt>.
		/// </param>
		/// <returns> Value of the specified identifier. Returns <tt>null</tt> if value
		/// of the specified identifier is not found.
		/// </returns>
		public virtual System.Object getValue(Identifier identifier, System.Object correlation)
		{
			try
			{
				/// <summary> Wrap numeric values in NumericValue instance</summary>
				System.Object value_Renamed = getValue(msg_, identifier);
				if ((value_Renamed is System.Int32))
					return new NumericValue((System.Int32) value_Renamed);
				
				if ((value_Renamed is System.Single))
					return new NumericValue((System.Single) value_Renamed);
				
				if ((value_Renamed is System.Double))
					return new NumericValue((System.Double) value_Renamed);
				
				if ((value_Renamed is System.Int64))
					return new NumericValue((System.Int64) value_Renamed);
				
				if ((value_Renamed is System.Int16))
					return new NumericValue((System.Int16) value_Renamed);
				
				if ((value_Renamed is System.Byte))
					return new NumericValue((System.Byte) value_Renamed);
				
				return value_Renamed;
			}
			//UPGRADE_TODO: Class 'javax.jms.JMSException' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
			catch (Exception ex)
			{
				//UPGRADE_TODO: The equivalent in .NET for method 'java.lang.Throwable.toString' may return a different value. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1043"'
				throw new System.ArgumentException(ex.ToString());
			}
		}
		
		//UPGRADE_TODO: Interface 'javax.jms.Message' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
		private static System.Object getValue(Message msg, Identifier identifier)
		{
			if (identifier.JMSHeader)
				return getHeaderValue(msg, identifier);
			
			System.String fldName = identifier.getIdentifier();
			
			// Leading '.' is there to indicate that this identifier references a nested
			// message field (not a property)
			int ind = fldName.IndexOf((System.Char) '.');
			if (ind >= 0)
			{
				// Skip over leading '.' if any
				if (ind == 0)
					fldName = fldName.Substring(1);
				
				//UPGRADE_ISSUE: Constructor 'java.util.StringTokenizer.StringTokenizer' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javautilStringTokenizerStringTokenizer_javalangString_javalangString_boolean"'
				for (SupportClass.Tokenizer strTok = new SupportClass.Tokenizer(identifier.getIdentifier(), "."); strTok.HasMoreTokens(); )
				{
					//UPGRADE_TODO: Interface 'javax.jms.MapMessage' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
					if (!(msg is MapMessage))
						return null;
					
					//UPGRADE_TODO: Interface 'javax.jms.MapMessage' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
					MapMessage mapMsg = (MapMessage) msg;
					
					fldName = strTok.NextToken();
					//UPGRADE_TODO: Method 'javax.jms.MapMessage.getObject' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
					System.Object nestedMsg = mapMsg.GetObject(fldName);
					if (strTok.HasMoreTokens())
					{
						//UPGRADE_TODO: Interface 'javax.jms.MapMessage' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
						if (!(nestedMsg is MapMessage))
							return null;
						
						//UPGRADE_TODO: Interface 'javax.jms.Message' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
						msg = (Message) nestedMsg;
					}
					else
						return nestedMsg;
				}
			}
			
			// Must be a property
			//UPGRADE_TODO: Method 'javax.jms.Message.propertyExists' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
			if (msg.PropertyExists(fldName))
			{
				//UPGRADE_TODO: Method 'javax.jms.Message.getObjectProperty' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
				return msg.GetObjectProperty(fldName);
			}
			return null;
		}
		
		//UPGRADE_TODO: Interface 'javax.jms.Message' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
		private static System.Object getHeaderValue(Message msg, Identifier identifier)
		{
			System.String prop = identifier.getIdentifier();
			if (prop.Equals("JMSMessageID"))
			{
				//UPGRADE_TODO: Method 'javax.jms.Message.getJMSMessageID' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
				return msg.MessageID;
			}
			else if (prop.Equals("JMSPriority"))
			{
				//UPGRADE_TODO: Method 'javax.jms.Message.getJMSPriority' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
				return msg.Priority;
			}
			else if (prop.Equals("JMSTimestamp"))
			{
				//UPGRADE_TODO: Method 'javax.jms.Message.getJMSTimestamp' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
				return msg.Timestamp;
			}
			else if (prop.Equals("JMSCorrelationID"))
			{
				//UPGRADE_TODO: Method 'javax.jms.Message.getJMSCorrelationID' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
				return msg.CorrelationID;
			}
			else if (prop.Equals("JMSDeliveryMode"))
			{
				//UPGRADE_TODO: Method 'javax.jms.Message.getJMSDeliveryMode' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
				return msg.DeliveryMode;
			}
			else if (prop.Equals("JMSRedelivered"))
			{
				//UPGRADE_TODO: Method 'javax.jms.Message.getJMSRedelivered' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
				return msg.Redelivered;
			}
			else if (prop.Equals("JMSType"))
			{
				//UPGRADE_TODO: Method 'javax.jms.Message.getJMSType' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
				return msg.MsgType;
			}
			else if (prop.Equals("JMSExpiration"))
			{
				//UPGRADE_TODO: Method 'javax.jms.Message.getJMSExpiration' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
				return msg.Expiration;
			}
			
			throw new System.SystemException("Invalid JMS property referenced: " + prop);
		}
		
		//UPGRADE_NOTE: Final was removed from the declaration of 'msg_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		//UPGRADE_TODO: Interface 'javax.jms.Message' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
		private Message msg_;
	}
}