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
	
	/// <summary> Typesafe enumeration of valid arithmetic operators.</summary>
	/// <author>  Jawaid Hakim.
	/// </author>
	abstract class ArithOpImpl
	{
		internal class AnonymousClassArithOpImpl:ArithOpImpl
		{
			//UPGRADE_NOTE: Final was removed from the declaration of 'PLUS '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
			internal AnonymousClassArithOpImpl(System.String Param1):base(Param1)
			{
			}
			public override System.Object eval(System.Collections.IDictionary identifiers, IExpression lhs, IExpression rhs)
			{
				System.Object oLhs = lhs.eval(identifiers);
				//UPGRADE_ISSUE: Class 'java.lang.Number' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javalangNumber"'
				if (!(oLhs is NumericValue))
					return Result.RESULT_UNKNOWN;
				//UPGRADE_ISSUE: Class 'java.lang.Number' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javalangNumber"'
				NumericValue lhsVal = (NumericValue) oLhs;
				
				System.Object oRhs = rhs.eval(identifiers);
				//UPGRADE_ISSUE: Class 'java.lang.Number' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javalangNumber"'
				if (!(oRhs is NumericValue))
					return Result.RESULT_UNKNOWN;
				//UPGRADE_ISSUE: Class 'java.lang.Number' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javalangNumber"'
				NumericValue rhsVal = (NumericValue) oRhs;
				
				//UPGRADE_ISSUE: Method 'java.lang.Number.doubleValue' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javalangNumber"'
				return new NumericValue(lhsVal.doubleValue() + rhsVal.doubleValue());
			}
			
			public override System.Object eval(IValueProvider provider, System.Object corr, IExpression lhs, IExpression rhs)
			{
				System.Object oLhs = lhs.eval(provider, corr);
				if (!(oLhs is NumericValue))
					return Result.RESULT_UNKNOWN;
				NumericValue lhsVal = (NumericValue) oLhs;
				
				System.Object oRhs = rhs.eval(provider, corr);
				if (!(oRhs is NumericValue))
					return Result.RESULT_UNKNOWN;
				NumericValue rhsVal = (NumericValue) oRhs;
				
				return new NumericValue(lhsVal.doubleValue() + rhsVal.doubleValue());
			}
		}
		internal class AnonymousClassArithOpImpl1:ArithOpImpl
		{
			//UPGRADE_NOTE: Final was removed from the declaration of 'MINUS '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
			internal AnonymousClassArithOpImpl1(System.String Param1):base(Param1)
			{
			}
			public override System.Object eval(System.Collections.IDictionary identifiers, IExpression lhs, IExpression rhs)
			{
				System.Object oLhs = lhs.eval(identifiers);
				if (!(oLhs is NumericValue))
					return Result.RESULT_UNKNOWN;
				NumericValue lhsVal = (NumericValue) oLhs;
				
				System.Object oRhs = rhs.eval(identifiers);
				if (!(oRhs is NumericValue))
					return Result.RESULT_UNKNOWN;
				NumericValue rhsVal = (NumericValue) oRhs;
				
				return new NumericValue(lhsVal.doubleValue() - rhsVal.doubleValue());
			}
			
			public override System.Object eval(IValueProvider provider, System.Object corr, IExpression lhs, IExpression rhs)
			{
				System.Object oLhs = lhs.eval(provider, corr);
				if (!(oLhs is NumericValue))
					return Result.RESULT_UNKNOWN;
				NumericValue lhsVal = (NumericValue) oLhs;
				
				System.Object oRhs = rhs.eval(provider, corr);
				if (!(oRhs is NumericValue))
					return Result.RESULT_UNKNOWN;
				NumericValue rhsVal = (NumericValue) oRhs;
				
				return new NumericValue(lhsVal.doubleValue() - rhsVal.doubleValue());
			}
		}
		internal class AnonymousClassArithOpImpl2:ArithOpImpl
		{
			//UPGRADE_NOTE: Final was removed from the declaration of 'MULT '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
			internal AnonymousClassArithOpImpl2(System.String Param1):base(Param1)
			{
			}
			public override System.Object eval(System.Collections.IDictionary identifiers, IExpression lhs, IExpression rhs)
			{
				System.Object oLhs = lhs.eval(identifiers);
				if (!(oLhs is NumericValue))
					return Result.RESULT_UNKNOWN;
				NumericValue lhsVal = (NumericValue) oLhs;
				
				System.Object oRhs = rhs.eval(identifiers);
				if (!(oRhs is NumericValue))
					return Result.RESULT_UNKNOWN;
				NumericValue rhsVal = (NumericValue) oRhs;
				
				return new NumericValue(lhsVal.doubleValue() * rhsVal.doubleValue());
			}
			
			public override System.Object eval(IValueProvider provider, System.Object corr, IExpression lhs, IExpression rhs)
			{
				System.Object oLhs = lhs.eval(provider, corr);
				if (!(oLhs is NumericValue))
					return Result.RESULT_UNKNOWN;
				NumericValue lhsVal = (NumericValue) oLhs;
				
				System.Object oRhs = rhs.eval(provider, corr);
				if (!(oRhs is NumericValue))
					return Result.RESULT_UNKNOWN;
				NumericValue rhsVal = (NumericValue) oRhs;
				
				return new NumericValue(lhsVal.doubleValue() * rhsVal.doubleValue());
			}
		}
		internal class AnonymousClassArithOpImpl3:ArithOpImpl
		{
			//UPGRADE_NOTE: Final was removed from the declaration of 'DIV '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
			internal AnonymousClassArithOpImpl3(System.String Param1):base(Param1)
			{
			}
			public override System.Object eval(System.Collections.IDictionary identifiers, IExpression lhs, IExpression rhs)
			{
				System.Object oLhs = lhs.eval(identifiers);
				if (!(oLhs is NumericValue))
					return Result.RESULT_UNKNOWN;
				NumericValue lhsVal = (NumericValue) oLhs;
				
				System.Object oRhs = rhs.eval(identifiers);
				if (!(oRhs is NumericValue))
					return Result.RESULT_UNKNOWN;
				NumericValue rhsVal = (NumericValue) oRhs;
				
				return new NumericValue(lhsVal.doubleValue() / rhsVal.doubleValue());
			}
			
			public override System.Object eval(IValueProvider provider, System.Object corr, IExpression lhs, IExpression rhs)
			{
				System.Object oLhs = lhs.eval(provider, corr);
				if (!(oLhs is NumericValue))
					return Result.RESULT_UNKNOWN;
				NumericValue lhsVal = (NumericValue) oLhs;
				
				System.Object oRhs = rhs.eval(provider, corr);
				if (!(oRhs is NumericValue))
					return Result.RESULT_UNKNOWN;
				NumericValue rhsVal = (NumericValue) oRhs;
				
				return new NumericValue(lhsVal.doubleValue() / rhsVal.doubleValue());
			}
		}
		internal class AnonymousClassArithOpImpl4:ArithOpImpl
		{
			//UPGRADE_NOTE: Final was removed from the declaration of 'NEG '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
			internal AnonymousClassArithOpImpl4(System.String Param1):base(Param1)
			{
			}
			public override System.Object eval(System.Collections.IDictionary identifiers, IExpression lhs, IExpression rhs)
			{
				System.Object oRhs = rhs.eval(identifiers);
				if (!(oRhs is NumericValue))
					return Result.RESULT_UNKNOWN;
				NumericValue rhsVal = (NumericValue) oRhs;
				
				return new NumericValue(- rhsVal.doubleValue());
			}
			
			public override System.Object eval(IValueProvider provider, System.Object corr, IExpression lhs, IExpression rhs)
			{
				System.Object oRhs = rhs.eval(provider, corr);
				if (!(oRhs is NumericValue))
					return Result.RESULT_UNKNOWN;
				NumericValue rhsVal = (NumericValue) oRhs;
				
				return new NumericValue(- rhsVal.doubleValue());
			}
		}
		/// <summary> Ctor.</summary>
		/// <param name="operator">Operator.
		/// </param>
		private ArithOpImpl(System.String operator_Renamed)
		{
			operator_ = operator_Renamed;
		}
		
		public override System.String ToString()
		{
			return operator_;
		}
		
		public abstract System.Object eval(System.Collections.IDictionary identifiers, IExpression lhs, IExpression rhs);
		
		public abstract System.Object eval(IValueProvider provider, System.Object corr, IExpression lhs, IExpression rhs);
		
		/// <summary> + operator.</summary>
		public static readonly ArithOpImpl PLUS = new AnonymousClassArithOpImpl("+");
		
		/// <summary> - operator.</summary>
		public static readonly ArithOpImpl MINUS = new AnonymousClassArithOpImpl1("-");
		
		/// <summary> * operator.</summary>
		public static readonly ArithOpImpl MULT = new AnonymousClassArithOpImpl2("*");
		
		/// <summary> / operator.</summary>
		public static readonly ArithOpImpl DIV = new AnonymousClassArithOpImpl3("/");
		
		/// <summary> unary - operator.</summary>
		public static readonly ArithOpImpl NEG = new AnonymousClassArithOpImpl4("-");
		
		//UPGRADE_NOTE: Final was removed from the declaration of 'operator_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private System.String operator_;
	}
}