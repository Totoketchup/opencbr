using System;

namespace org.opencbr.core.context
{
	/// <summary>
	/// CBRContextFactory ��ժҪ˵����
	/// </summary>
	public class CBRContextFactory
	{
		public static ICBRContext newInstance()
		{
			return new DefaultCBRContext();
		}
	}
}
