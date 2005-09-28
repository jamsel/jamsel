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
	
	/// <summary> Abstract base class for arithmetic expression evaluation operators.</summary>
	/// <author>  Jawaid Hakim.
	/// </author>
	abstract class ArithCompareOpImpl
	{
		internal class AnonymousClassArithCompareOpImpl:ArithCompareOpImpl
		{
			//UPGRADE_NOTE: Final was removed from the declaration of 'EQ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
			internal AnonymousClassArithCompareOpImpl(System.String Param1):base(Param1)
			{
			}
			public override System.Object eval(System.Collections.IDictionary identifiers, IExpression lhs, IExpression rhs)
			{
				System.Object oLhs = lhs.eval(identifiers);
				if (oLhs == null)
					return Result.RESULT_UNKNOWN;
				else if (!(oLhs is NumericValue))
					return Result.RESULT_FALSE;
				NumericValue nLhs = (NumericValue) oLhs;
				
				System.Object oRhs = rhs.eval(identifiers);
				if (oRhs == null)
					return Result.RESULT_UNKNOWN;
				else if (!(oRhs is NumericValue))
					return Result.RESULT_FALSE;
				NumericValue nRhs = (NumericValue) oRhs;
				
				return (nLhs.doubleValue() == nRhs.doubleValue())?Result.RESULT_TRUE:Result.RESULT_FALSE;
			}
			
			public override System.Object eval(IValueProvider provider, System.Object corr, IExpression lhs, IExpression rhs)
			{
				System.Object oLhs = lhs.eval(provider, corr);
				if (oLhs == null)
					return Result.RESULT_UNKNOWN;
				else if (!(oLhs is NumericValue))
					return Result.RESULT_FALSE;
				NumericValue nLhs = (NumericValue) oLhs;
				
				System.Object oRhs = rhs.eval(provider, corr);
				if (oRhs == null)
					return Result.RESULT_UNKNOWN;
				else if (!(oRhs is NumericValue))
					return Result.RESULT_FALSE;
				NumericValue nRhs = (NumericValue) oRhs;
				
				return (nLhs.doubleValue() == nRhs.doubleValue())?Result.RESULT_TRUE:Result.RESULT_FALSE;
			}
		}
		internal class AnonymousClassArithCompareOpImpl1:ArithCompareOpImpl
		{
			//UPGRADE_NOTE: Final was removed from the declaration of 'GT '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
			internal AnonymousClassArithCompareOpImpl1(System.String Param1):base(Param1)
			{
			}
			public override System.Object eval(System.Collections.IDictionary identifiers, IExpression lhs, IExpression rhs)
			{
				System.Object oLhs = lhs.eval(identifiers);
				if (oLhs == null)
					return Result.RESULT_UNKNOWN;
				else if (!(oLhs is NumericValue))
					return Result.RESULT_FALSE;
				NumericValue nLhs = (NumericValue) oLhs;
				
				System.Object oRhs = rhs.eval(identifiers);
				if (oRhs == null)
					return Result.RESULT_UNKNOWN;
				else if (!(oRhs is NumericValue))
					return Result.RESULT_FALSE;
				NumericValue nRhs = (NumericValue) oRhs;
				
				return (nLhs.doubleValue() > nRhs.doubleValue())?Result.RESULT_TRUE:Result.RESULT_FALSE;
			}
			
			public override System.Object eval(IValueProvider provider, System.Object corr, IExpression lhs, IExpression rhs)
			{
				System.Object oLhs = lhs.eval(provider, corr);
				if (oLhs == null)
					return Result.RESULT_UNKNOWN;
				else if (!(oLhs is NumericValue))
					return Result.RESULT_FALSE;
				NumericValue nLhs = (NumericValue) oLhs;
				
				System.Object oRhs = rhs.eval(provider, corr);
				if (oRhs == null)
					return Result.RESULT_UNKNOWN;
				else if (!(oRhs is NumericValue))
					return Result.RESULT_FALSE;
				NumericValue nRhs = (NumericValue) oRhs;
				
				return (nLhs.doubleValue() > nRhs.doubleValue())?Result.RESULT_TRUE:Result.RESULT_FALSE;
			}
		}
		internal class AnonymousClassArithCompareOpImpl2:ArithCompareOpImpl
		{
			//UPGRADE_NOTE: Final was removed from the declaration of 'GE '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
			internal AnonymousClassArithCompareOpImpl2(System.String Param1):base(Param1)
			{
			}
			public override System.Object eval(System.Collections.IDictionary identifiers, IExpression lhs, IExpression rhs)
			{
				System.Object oLhs = lhs.eval(identifiers);
				if (oLhs == null)
					return Result.RESULT_UNKNOWN;
				else if (!(oLhs is NumericValue))
					return Result.RESULT_FALSE;
				NumericValue nLhs = (NumericValue) oLhs;
				
				System.Object oRhs = rhs.eval(identifiers);
				if (oRhs == null)
					return Result.RESULT_UNKNOWN;
				else if (!(oRhs is NumericValue))
					return Result.RESULT_FALSE;
				NumericValue nRhs = (NumericValue) oRhs;
				
				return (nLhs.doubleValue() >= nRhs.doubleValue())?Result.RESULT_TRUE:Result.RESULT_FALSE;
			}
			
			public override System.Object eval(IValueProvider provider, System.Object corr, IExpression lhs, IExpression rhs)
			{
				System.Object oLhs = lhs.eval(provider, corr);
				if (oLhs == null)
					return Result.RESULT_UNKNOWN;
				else if (!(oLhs is NumericValue))
					return Result.RESULT_FALSE;
				NumericValue nLhs = (NumericValue) oLhs;
				
				System.Object oRhs = rhs.eval(provider, corr);
				if (oRhs == null)
					return Result.RESULT_UNKNOWN;
				else if (!(oRhs is NumericValue))
					return Result.RESULT_FALSE;
				NumericValue nRhs = (NumericValue) oRhs;
				
				return (nLhs.doubleValue() >= nRhs.doubleValue())?Result.RESULT_TRUE:Result.RESULT_FALSE;
			}
		}
		internal class AnonymousClassArithCompareOpImpl3:ArithCompareOpImpl
		{
			//UPGRADE_NOTE: Final was removed from the declaration of 'LT '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
			internal AnonymousClassArithCompareOpImpl3(System.String Param1):base(Param1)
			{
			}
			public override System.Object eval(System.Collections.IDictionary identifiers, IExpression lhs, IExpression rhs)
			{
				System.Object oLhs = lhs.eval(identifiers);
				if (oLhs == null)
					return Result.RESULT_UNKNOWN;
				else if (!(oLhs is NumericValue))
					return Result.RESULT_FALSE;
				NumericValue nLhs = (NumericValue) oLhs;
				
				System.Object oRhs = rhs.eval(identifiers);
				if (oRhs == null)
					return Result.RESULT_UNKNOWN;
				else if (!(oRhs is NumericValue))
					return Result.RESULT_FALSE;
				NumericValue nRhs = (NumericValue) oRhs;
				
				return (nLhs.doubleValue() < nRhs.doubleValue())?Result.RESULT_TRUE:Result.RESULT_FALSE;
			}
			
			public override System.Object eval(IValueProvider provider, System.Object corr, IExpression lhs, IExpression rhs)
			{
				System.Object oLhs = lhs.eval(provider, corr);
				if (oLhs == null)
					return Result.RESULT_UNKNOWN;
				else if (!(oLhs is NumericValue))
					return Result.RESULT_FALSE;
				NumericValue nLhs = (NumericValue) oLhs;
				
				System.Object oRhs = rhs.eval(provider, corr);
				if (oRhs == null)
					return Result.RESULT_UNKNOWN;
				else if (!(oRhs is NumericValue))
					return Result.RESULT_FALSE;
				NumericValue nRhs = (NumericValue) oRhs;
				
				return (nLhs.doubleValue() < nRhs.doubleValue())?Result.RESULT_TRUE:Result.RESULT_FALSE;
			}
		}
		internal class AnonymousClassArithCompareOpImpl4:ArithCompareOpImpl
		{
			//UPGRADE_NOTE: Final was removed from the declaration of 'LE '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
			internal AnonymousClassArithCompareOpImpl4(System.String Param1):base(Param1)
			{
			}
			public override System.Object eval(System.Collections.IDictionary identifiers, IExpression lhs, IExpression rhs)
			{
				System.Object oLhs = lhs.eval(identifiers);
				if (oLhs == null)
					return Result.RESULT_UNKNOWN;
				else if (!(oLhs is NumericValue))
					return Result.RESULT_FALSE;
				NumericValue nLhs = (NumericValue) oLhs;
				
				System.Object oRhs = rhs.eval(identifiers);
				if (oRhs == null)
					return Result.RESULT_UNKNOWN;
				else if (!(oRhs is NumericValue))
					return Result.RESULT_FALSE;
				NumericValue nRhs = (NumericValue) oRhs;
				
				return (nLhs.doubleValue() <= nRhs.doubleValue())?Result.RESULT_TRUE:Result.RESULT_FALSE;
			}
			
			public override System.Object eval(IValueProvider provider, System.Object corr, IExpression lhs, IExpression rhs)
			{
				System.Object oLhs = lhs.eval(provider, corr);
				if (oLhs == null)
					return Result.RESULT_UNKNOWN;
				else if (!(oLhs is NumericValue))
					return Result.RESULT_FALSE;
				NumericValue nLhs = (NumericValue) oLhs;
				
				System.Object oRhs = rhs.eval(provider, corr);
				if (oRhs == null)
					return Result.RESULT_UNKNOWN;
				else if (!(oRhs is NumericValue))
					return Result.RESULT_FALSE;
				NumericValue nRhs = (NumericValue) oRhs;
				
				return (nLhs.doubleValue() <= nRhs.doubleValue())?Result.RESULT_TRUE:Result.RESULT_FALSE;
			}
		}
		/// <summary> Ctor.</summary>
		/// <param name="operator">Operator.
		/// </param>
		private ArithCompareOpImpl(System.String operator_Renamed)
		{
			operator_ = operator_Renamed;
		}
		
		public override System.String ToString()
		{
			return operator_;
		}
		
		public abstract System.Object eval(System.Collections.IDictionary identifiers, IExpression lhs, IExpression rhs);
		
		public abstract System.Object eval(IValueProvider provider, System.Object corr, IExpression lhs, IExpression rhs);
		
		/// <summary> = operator.</summary>
		public static readonly ArithCompareOpImpl EQ = new AnonymousClassArithCompareOpImpl(" = ");
		
		/// <summary> > operator.</summary>
		public static readonly ArithCompareOpImpl GT = new AnonymousClassArithCompareOpImpl1(" > ");
		
		/// <summary> >= operator.</summary>
		public static readonly ArithCompareOpImpl GE = new AnonymousClassArithCompareOpImpl2(" >= ");
		
		/// <summary> < operator.</summary>
		public static readonly ArithCompareOpImpl LT = new AnonymousClassArithCompareOpImpl3(" < ");
		
		/// <summary> <= operator.</summary>
		public static readonly ArithCompareOpImpl LE = new AnonymousClassArithCompareOpImpl4(" <= ");
		
		//UPGRADE_NOTE: Final was removed from the declaration of 'operator_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private System.String operator_;
	}
}