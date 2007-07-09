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

namespace org.opencbr.core.testcase
{
	using NUnit.Framework;
	using org.opencbr.core.express;
	using org.opencbr.core.Similarity;
	/// <summary>
	/// testEuclideanSimilarity 
	/// <author>xw_cn@163.com</author>
	/// <version>1.0</version>
	/// <creationdate>2005/11/28</creationdate>
	/// <modificationdate></modificationdate>>
	/// <history></history>
	/// </summary>
	[TestFixture]public class testEuclideanSimilarity
	{
		Case c1 = new Case(1, "testcase", "testcase");
		Case c2 = new Case(1, "testcase", "testcase");
		ISimilarity sim = new EuclideanSimilarity();
		public testEuclideanSimilarity()
		{
		}
		/// <summary>
		/// test init
		/// case 1 data:
		///			speed		2.0
		///			temperature	3.5
		///			quality		0.7
		///			result		1
		///	case 2 data:
		///			speed		3.0
		///			temperature 6.7
		///			quality		0.6	
		///			result		2
		///			
		/// </summary>
		[SetUp]public void Init()
		{
			c1.AddFeature("speed", FeatureType.TYPE_FEATURE_FLOAT,
							2.0, 0.5, false, false);
			c2.AddFeature("speed", FeatureType.TYPE_FEATURE_FLOAT,
							3.0, 0.5, false, false);

			c1.AddFeature("temperature", FeatureType.TYPE_FEATURE_FLOAT,
							3.0, 0.3, false, false);
			c2.AddFeature("temperature", FeatureType.TYPE_FEATURE_FLOAT,
							4.0, 0.3, false, false);

			c1.AddFeature("quality", FeatureType.TYPE_FEATURE_FLOAT,
							1.0, 0.2, false, false);
			c2.AddFeature("quality", FeatureType.TYPE_FEATURE_FLOAT,
							2.0, 0.2, false, false);

			c1.AddFeature("result",FeatureType.TYPE_FEATURE_FLOAT,
							1.0, 0, true, false);
			c2.AddFeature("result", FeatureType.TYPE_FEATURE_FLOAT,
							2.0, 0, true, false);
		}
		/// <summary>
		/// test data:
		///		case structure:
		///			feature name	feature type	weight		key
		///			speed			double			0.5			false
		///			temperature		double			0.3			false
		///			quality			double			0.2			false
		///			result			double			0			true
		///		case 1 data:
		///			speed		2.0
		///			temperature	3.0
		///			quality		1
		///			result		1
		///		case 2 data:
		///			speed		3.0
		///			temperature 4.0
		///			quality		2
		///			result		2
		///	expected result value is 1 / (1 + Math.Sqrt(0.38)* 1
		/// 
		/// </summary>
		[Test]public void testCompare()
		{
			double diff = sim.Compare(c1, c2);
			Assert.AreEqual(1 / (1 + Math.Sqrt(0.38) * 1), diff);
		}

	}
}
