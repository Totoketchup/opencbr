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
	using System.Collections;
	/// <summary>
	/// MethodList 
	/// <author>xw_cn@163.com</author>
	/// <version>1.0</version>
	/// <creationdate>2005/11/15</creationdate>
	/// <modificationdate></modificationdate>>
	/// <history></history>
	/// </summary>
	public class MethodList
	{
		private ArrayList _methods = new ArrayList();
		public MethodList()
		{
		}
		public int GetLength()
		{
			return _methods.Count;
		}
		public IMethod GetMethod(int i)
		{
			if (GetLength() > i || i < 0)
				return null;
			return (IMethod)_methods[i];
		}
		public void AddMethod(IMethod method)
		{
			_methods.Add(method);
		}
		public void RemoveMethod(IMethod method)
		{
			if (method == null)
				return;
			for (int i = 0; i < _methods.Count; i++)
			{
				IMethod m = (IMethod)_methods[i];
				if (method.GetMethodName().CompareTo(
					method.GetMethodName()
					) == 0)
				{
					_methods.RemoveAt(i);
					break;
				}
			}
		}
		public IMethod GetMethod(string methodName)
		{
			if (methodName == null || methodName.Length == 0)
				return null;
			for (int i = 0; i < _methods.Count; i++)
			{
				IMethod m = (IMethod) _methods[i];
				if (m.GetMethodName().CompareTo(methodName) == 0)
				{
					return m;
				}
			}
			return null;
		}
	}
}
