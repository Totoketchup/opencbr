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

namespace org.opencbr.core.testcase.util
{
	using NUnit.Framework;
	/// <summary>
	/// testDynamicCreator 
	/// <author>xw_cn@163.com</author>
	/// <version>1.0</version>
	/// <creationdate>2006/0/3</creationdate>
	/// <modificationdate></modificationdate>>
	/// <history></history>
	/// </summary>
	[TestFixture]
	public class testDynamicCreator
	{
		public testDynamicCreator()
		{
		}
		/// <summary>
		/// test case 1:
		///		input:
		///			the string 
		///			"org.opencbr.core.Similarity.EuclideanSimilarity"
		///		expected output:
		///			the instance of the class
		///			org.opencbr.core.Similarity.EuclideanSimilarity
		/// </summary>
		[Test]public void testCreateInstance()
		{
			Type type = Type.GetType("org.opencbr.core.Similarity.EuclideanSimilarity");
			org.opencbr.core.Similarity.ISimilarity s = (org.opencbr.core.Similarity.ISimilarity)org.opencbr.core.util.DynamicCreator.CreateInstance(type);
			System.Console.WriteLine(s.ToString());
			Assert.IsNotNull(s);
		}
	}
}
