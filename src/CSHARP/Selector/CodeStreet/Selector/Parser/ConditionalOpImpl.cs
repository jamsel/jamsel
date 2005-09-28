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
	
	/// <summary> Typesafe enumeration of valid conditional operators.</summary>
	/// <author>  Jawaid Hakim.
	/// </author>
	abstract class ConditionalOpImpl
	{
		internal class AnonymousClassConditionalOpImpl:ConditionalOpImpl
		{
			//UPGRADE_NOTE: Final was removed from the declaration of 'AND '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
			internal AnonymousClassConditionalOpImpl(System.String Param1):base(Param1)
			{
			}
			public override System.Object eval(System.Collections.IDictionary identifiers, IExpression lhs, IExpression rhs)
			{
				Result bLhs = (Result) lhs.eval(identifiers);
				// Short circuit evaulation if LHS is FALSE or RESULT_UNKNOWN
				if (bLhs == Result.RESULT_FALSE)
					return Result.RESULT_FALSE;
				else if (bLhs == Result.RESULT_UNKNOWN)
					return Result.RESULT_UNKNOWN;
				
				return (Result) rhs.eval(identifiers);
			}
			
			public override System.Object eval(IValueProvider provider, System.Object corr, IExpression lhs, IExpression rhs)
			{
				Result bLhs = (Result) lhs.eval(provider, corr);
				// Short circuit evaulation if LHS is FALSE or RESULT_UNKNOWN
				if (bLhs == Result.RESULT_FALSE)
					return Result.RESULT_FALSE;
				else if (bLhs == Result.RESULT_UNKNOWN)
					return Result.RESULT_UNKNOWN;
				
				return (Result) rhs.eval(provider, corr);
			}
		}
		internal class AnonymousClassConditionalOpImpl1:ConditionalOpImpl
		{
			//UPGRADE_NOTE: Final was removed from the declaration of 'OR '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
			internal AnonymousClassConditionalOpImpl1(System.String Param1):base(Param1)
			{
			}
			public override System.Object eval(System.Collections.IDictionary identifiers, IExpression lhs, IExpression rhs)
			{
				Result bLhs = (Result) lhs.eval(identifiers);
				// Short circuit evaulation if LHS is TRUE
				if (bLhs == Result.RESULT_TRUE)
					return Result.RESULT_TRUE;
				
				Result bRhs = (Result) rhs.eval(identifiers);
				if (bRhs == Result.RESULT_TRUE)
					return Result.RESULT_TRUE;
				else if (bLhs == Result.RESULT_UNKNOWN || bRhs == Result.RESULT_UNKNOWN)
					return Result.RESULT_UNKNOWN;
				else
					return Result.RESULT_FALSE;
			}
			
			public override System.Object eval(IValueProvider provider, System.Object corr, IExpression lhs, IExpression rhs)
			{
				Result bLhs = (Result) lhs.eval(provider, corr);
				// Short circuit evaulation if LHS is TRUE
				if (bLhs == Result.RESULT_TRUE)
					return Result.RESULT_TRUE;
				
				Result bRhs = (Result) rhs.eval(provider, corr);
				if (bRhs == Result.RESULT_TRUE)
					return Result.RESULT_TRUE;
				else if (bLhs == Result.RESULT_UNKNOWN || bRhs == Result.RESULT_UNKNOWN)
					return Result.RESULT_UNKNOWN;
				else
					return Result.RESULT_FALSE;
			}
		}
		internal class AnonymousClassConditionalOpImpl2:ConditionalOpImpl
		{
			//UPGRADE_NOTE: Final was removed from the declaration of 'NOT '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
			internal AnonymousClassConditionalOpImpl2(System.String Param1):base(Param1)
			{
			}
			public override System.Object eval(System.Collections.IDictionary identifiers, IExpression lhs, IExpression rhs)
			{
				Result bRhs = (Result) rhs.eval(identifiers);
				if (bRhs == Result.RESULT_TRUE)
					return Result.RESULT_FALSE;
				else if (bRhs == Result.RESULT_FALSE)
					return Result.RESULT_TRUE;
				else
					return Result.RESULT_UNKNOWN;
			}
			
			public override System.Object eval(IValueProvider provider, System.Object corr, IExpression lhs, IExpression rhs)
			{
				Result bRhs = (Result) rhs.eval(provider, corr);
				if (bRhs == Result.RESULT_TRUE)
					return Result.RESULT_FALSE;
				else if (bRhs == Result.RESULT_FALSE)
					return Result.RESULT_TRUE;
				else
					return Result.RESULT_UNKNOWN;
			}
		}
		/// <summary> Ctor.</summary>
		/// <param name="operator">Operator.
		/// </param>
		private ConditionalOpImpl(System.String operator_Renamed)
		{
			operator_ = operator_Renamed;
		}
		
		public override System.String ToString()
		{
			return operator_;
		}
		
		public abstract System.Object eval(System.Collections.IDictionary identifiers, IExpression lhs, IExpression rhs);
		
		public abstract System.Object eval(IValueProvider provider, System.Object corr, IExpression lhs, IExpression rhs);
		
		/// <summary> AND operator.</summary>
		public static readonly ConditionalOpImpl AND = new AnonymousClassConditionalOpImpl(" AND ");
		
		/// <summary> OR operator.</summary>
		public static readonly ConditionalOpImpl OR = new AnonymousClassConditionalOpImpl1(" OR ");
		
		/// <summary> NOT operator.</summary>
		public static readonly ConditionalOpImpl NOT = new AnonymousClassConditionalOpImpl2(" NOT ");
		
		//UPGRADE_NOTE: Final was removed from the declaration of 'operator_ '. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1003"'
		private System.String operator_;
	}
}