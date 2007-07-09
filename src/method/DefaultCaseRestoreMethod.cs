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
	/// <summary>
	/// DefaultCaseRestoreMethod 
	/// <author>xw_cn@163.com</author>
	/// <version>1.0</version>
	/// <creationdate>2006/0/3</creationdate>
	/// <modificationdate></modificationdate>>
	/// <history></history>
	/// </summary>
	public class DefaultCaseRestoreMethod:ICaseRestoreMethod
	{
		public DefaultCaseRestoreMethod()
		{
		}
		#region IMethod ��Ա

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
			// TODO:  ��� DefaultCaseRestoreMethod.Execute ʵ��
			return null;
		}

		public void SetMethodType(int methodType)
		{
			// TODO:  ��� DefaultCaseRestoreMethod.SetMethodType ʵ��
		}

		public int GetMethodType()
		{
			// TODO:  ��� DefaultCaseRestoreMethod.GetMethodType ʵ��
			return 0;
		}

		public void SetMethodName(string methodName)
		{
			// TODO:  ��� DefaultCaseRestoreMethod.SetMethodName ʵ��
		}

		public string GetMethodName()
		{
			// TODO:  ��� DefaultCaseRestoreMethod.GetMethodName ʵ��
			return null;
		}

		#endregion
	}
}
