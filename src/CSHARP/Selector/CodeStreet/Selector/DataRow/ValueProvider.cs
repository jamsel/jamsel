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
using System.Data;
using CodeStreet.Selector.Parser;

namespace Selector.CodeStreet.Selector.DataRow
{
	/// <summary>
	/// Summary description for ValueProvider.
	/// </summary>
	public class ValueProvider : IValueProvider
	{
		/// <summary>
		/// Ctor.
		/// </summary>
		/// <param name="row">Data row on which to operate.</param>
		public ValueProvider(System.Data.DataRow row)
		{
			this.row = row;
		}

		#region IValueProvider Members

		/// <summary>
		/// Get the value of the identifier from the cached data row. The
		/// name of the identifier must correspond to the name of a column
		/// in the data row.
		/// </summary>
		/// <param name="identifier">Identifier.</param>
		/// <param name="correlation">Correlation data (ignored).</param>
		/// <returns>Column data.</returns>
		public Object getValue(Identifier identifier, Object correlation)
		{
			String columnName = identifier.getIdentifier();
			object val = row[columnName];
			
			if ((val is System.Decimal))
				return new NumericValue((System.Decimal) val);

			if ((val is System.Int32))
				return new NumericValue((System.Int32) val);
				
			if ((val is System.Single))
				return new NumericValue((System.Single) val);
				
			if ((val is System.Double))
				return new NumericValue((System.Double) val);
				
			if ((val is System.Int64))
				return new NumericValue((System.Int64) val);
				
			if ((val is System.Int16))
				return new NumericValue((System.Int16) val);
				
			if ((val is System.Byte))
				return new NumericValue((System.Byte) val);
				
			return val;
		}

		#endregion

		private System.Data.DataRow row;
	}
}
