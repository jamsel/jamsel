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
namespace CodeStreet.Selector.Parser
{
	
	/// <summary> Class to represent an identifier. Thread safe class may be freely used across threads.
	/// Identifiers can either be JMS header fields, or JMS provider-specific properties, or
	/// application properties.<p>
	/// The following JMS header fields are supported: <tt>JMSDeliveryMode</tt>,
	/// <tt>JMSPriority</tt>, <tt>JMSMessageID</tt>, <tt>JMSTimestamp</tt>, <tt>JMSCorrelationID, 
	/// and <tt>JMSType</tt>. In addition, the header fields <tt>JMSRedelivered</tt> and 
	/// <tt>JMSExpiration</tt> are also supported. These additional fields are relevant only 
	/// for the receiving application and not for the sender.<p>
	/// Support is provided for <tt>nested</tt> fields. Nested fields are referenced using a <tt>dot</tt>
	/// notation. For example, <tt>order.quantity</tt> would select the <tt>quantity</tt> field of 
	/// the nested sub-message field <tt>order</tt> if it exists. Otherwise, it selects nothing 
	/// (<tt>null</tt>).
	/// </summary>
	/// <author>  Jawaid Hakim.
	/// </author>
	public class Identifier : IExpression
	{
		/// <summary> Check if this is a JMS header property.</summary>
		/// <returns> <tt>true</tt> if this identifier is a JMS header property. Otherwise, 
		/// returns <tt>false</tt>.
		/// </returns>
		virtual public bool JMSHeader
		{
			get
			{
				return jmsHeader_;
			}
			
		}
		/// <summary> Factory.</summary>
		/// <param name="id">Identifier name.
		/// </param>
		/// <returns> Instance.
		/// @throws IllegalArgumentException Invalid identifier name.
		/// </returns>
		//UPGRADE_NOTE: Synchronized keyword was removed from method 'valueOf'. Lock expression was added. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1027"'
		public static Identifier valueOf(System.String id)
		{
			lock (typeof(CodeStreet.Selector.Parser.Identifier))
			{
				if (reservedNamesSet_.Contains(id))
					throw new System.ArgumentException("Identifier name cannot be a reserved name: " + id);
				
				//UPGRADE_TODO: Method 'java.util.Map.get' was converted to 'System.Collections.IDictionary.Item' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javautilMapget_javalangObject"'
				Identifier instance = (Identifier) idMap_[id];
				if (instance == null)
				{
					instance = new Identifier(id);
					object tempObject;
					tempObject = instance;
					idMap_[id] = tempObject;
					System.Object generatedAux = tempObject;
				}
				return instance;
			}
		}
		
		/// <summary> Ctor.</summary>
		/// <param name="id">Identifier name.
		/// </param>
		private Identifier(System.String id)
		{
			id_ = id;
			jmsHeader_ = jmsHeadersSet_.Contains(id);
		}
		
		/// <summary> Get identifier name.</summary>
		/// <returns> Identifier name.
		/// </returns>
		public virtual System.String getIdentifier()
		{
			return id_;
		}
		
		public virtual System.Object eval(System.Collections.IDictionary identifiers)
		{
			return getValue(identifiers);
		}
		
		public virtual System.Object eval(IValueProvider provider, System.Object corr)
		{
			return provider.getValue(this, corr);
		}
		
		internal virtual System.Object getValue(System.Collections.IDictionary identifiers)
		{
			//UPGRADE_TODO: Method 'java.util.Map.get' was converted to 'System.Collections.IDictionary.Item' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javautilMapget_javalangObject"'
			object val = identifiers[id_];
			if (val is System.Decimal || val is System.Int16 || val is System.Int32 || val is System.Int64 || val is System.Single ||
			    val is System.Double || val is System.Byte)
				return new NumericValue(val);
			return val;
		}
		
		public override System.String ToString()
		{
			return id_;
		}
		
		//UPGRADE_NOTE: Final was removed from the declaration of 'id_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private System.String id_;
		//UPGRADE_NOTE: Final was removed from the declaration of 'jmsHeader_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private bool jmsHeader_;
		private static SupportClass.SetSupport jmsHeadersSet_;
		private static SupportClass.SetSupport reservedNamesSet_;
		
		//UPGRADE_TODO: Class 'java.util.HashMap' was converted to 'System.Collections.Hashtable' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javautilHashMap"'
		//UPGRADE_NOTE: The initialization of  'idMap_' was moved to static method 'CodeStreet.Selector.Parser.Identifier'. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1005"'
		private static System.Collections.IDictionary idMap_;
		static Identifier()
		{
			idMap_ = new System.Collections.Hashtable();
			{
				// Valid JMS header fields
				System.String[] jmsHeaders_ = new System.String[]{"JMSDeliveryMode", "JMSPriority", "JMSMessageID", "JMSTimestamp", "JMSCorrelationID", "JMSType", "JMSRedelivered", "JMSExpiration"};
				//UPGRADE_TODO: The equivalent in .NET for method 'java.util.Arrays.asList' may return a different value. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1043"'
				jmsHeadersSet_ = new SupportClass.HashSetSupport(SupportClass.CollectionSupport.ToCollectionSupport(jmsHeaders_));
				
				// Valid JMS header fields
				System.String[] reservedNames_ = new System.String[]{"NULL", "TRUE", "FALSE", "NULL", "NOT", "AND", "OR", "BETWEEN", "LIKE", "IN", "IS", "ESCAPE"};
				//UPGRADE_TODO: The equivalent in .NET for method 'java.util.Arrays.asList' may return a different value. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1043"'
				reservedNamesSet_ = new SupportClass.HashSetSupport(SupportClass.CollectionSupport.ToCollectionSupport(reservedNames_));
			}
		}
	}
}