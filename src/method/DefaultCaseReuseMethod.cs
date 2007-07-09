#region copyright (C) xia wu,pian jin xiang
/************************************************************************************
' Copyright (C) 2005 xia wu,pian jin xiang 
'
' This software is provided 'as-is', without any express or implied warranty. In no 
' event will the authors be held liable for any damages arising from the use of this 
' software.
' 
' Permission is granted to anyone to use this software for any purpose, including 
' commercial applications, and to alter it and redistribute it freely, subject to the 
' following restrictions:
'
' 1. The origin of this software must not be misrepresented; you must not claim that 
' you wrote the original software. If you use this software in a product, an 
' acknowledgment (see the following) in the product documentation is required.
'
' 2. Altered source versions must be plainly marked as such, and must not be 
' misrepresented as being the original software.
'
' 3. This notice may not be removed or altered from any source distribution.
'
'***********************************************************************************/
#endregion
using System;

namespace org.opencbr.core.method
{
	using org.opencbr.core.express;
	using org.opencbr.core.context;
	using org.opencbr.core.strategy;
	using System.Collections;
	/// <summary>
	/// DefaultCaseReuseMethod 
	/// <author>xw_cn@163.com</author>
	/// <version>1.0</version>
	/// <creationdate>2005/11/31</creationdate>
	/// <modificationdate></modificationdate>>
	/// <history></history>
	/// </summary>
	public class DefaultCaseReuseMethod:ICaseReuseMethod
	{
		public DefaultCaseReuseMethod()
		{
		}
		#region IMethod ≥…‘±

		private string _env;
		public void SetEnv(string env)
		{
			_env = env;
		}
		public string GetEnv()
		{
			return _env;
		}
		public object Execute(object obj)
		{
			if (_env == null)
				throw new ContextException("environment variable is not set");

			ICBRContext ctx = CBRContextManager.GetCBRContext(_env);
			if (ctx == null)
			{
				//throw NoContextException
				throw new ContextException("not set the context");
			}

			ICaseReuseStrategy strategy = ctx.GetCaseReuseStrategy();
			if (strategy == null)
			{
				throw new ContextException(
						"context CaseReuseStrategy is not set");
			}


			return strategy.Reuse((ArrayList)obj);
		}

		public void SetMethodType(int methodType)
		{
		}

		public int GetMethodType()
		{
			return 0;
		}

		public void SetMethodName(string methodName)
		{
		}

		public string GetMethodName()
		{
			return null;
		}

		#endregion
	}
}
