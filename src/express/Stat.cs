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

namespace org.opencbr.core.express
{
	/// <summary>
	/// unified value object implementation
	/// used by the following procedure:
	/// case retrievel, case reuse, case revise, case restore
	/// <author>xw_cn@163.com</author>
	/// <version>1.0</version>
	/// <creationdate>2005/11/29</creationdate>
	/// <modificationdate></modificationdate>>
	/// <history></history>
	/// </summary>
	public class Stat:IStat
	{
		private Case _c;
		private double _similarity;
		public Stat()
		{
		}
		#region IStat ≥…‘±

		public void SetCBRCase(Case c)
		{
			_c = c;
		}

		public Case GetCBRCase()
		{
			return _c;
		}

		public void SetCaseSimilarity(double similarity)
		{
			_similarity = similarity;
		}

		public double GetCaseSimilarity()
		{
			return _similarity;
		}

		#endregion
	}
}
