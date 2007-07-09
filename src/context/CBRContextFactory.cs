using System;

namespace org.opencbr.core.context
{
	/// <summary>
	/// CBRContextFactory 的摘要说明。
	/// </summary>
	public class CBRContextFactory
	{
		public static ICBRContext newInstance()
		{
			return new DefaultCBRContext();
		}
	}
}
