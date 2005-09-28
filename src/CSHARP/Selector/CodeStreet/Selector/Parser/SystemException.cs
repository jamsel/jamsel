using System;
namespace CodeStreet.Selector.Parser
{
	
	/// <summary> Exception thrown when a system error condition is trapped. This category of exceptions indicate system exceptions.</summary>
	/// <seealso cref="CodeStreet.Selector.Parser.BusinessException">
	/// </seealso>
	/// <author>  Jawaid Hakim.
	/// </author>
	public class SystemException:BaseException
	{
		/// <summary> Constructor.</summary>
		/// <param name="desc">Description of exception.
		/// </param>
		public SystemException(System.String desc):base(desc)
		{
		}
		
		/// <summary> Constructor.</summary>
		/// <param name="original">Original throwable.
		/// </param>
		//UPGRADE_NOTE: Exception 'java.lang.Throwable' was converted to 'System.Exception' which has different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1100"'
		public SystemException(String desc, System.Exception original):base(desc, original)
		{
		}
	}
}