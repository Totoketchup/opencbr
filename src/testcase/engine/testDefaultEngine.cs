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

namespace org.opencbr.core.testcase.engine
{
	using NUnit.Framework;
	using org.opencbr.core.engine;
	using org.opencbr.core.express;
	/// <summary>
	/// testDefaultEngine 
	/// <author>xw_cn@163.com</author>
	/// <version>1.0</version>
	/// <creationdate>2006/0/4</creationdate>
	/// <modificationdate></modificationdate>>
	/// <history></history>
	/// </summary>
	[TestFixture]
	public class testDefaultEngine
	{
		IEngine _engine = new DefaultEngine();
		string _env = @"..\..\context\config.xml";
		Case _problem = new Case(1, "cooling", "testcase problem");
		public testDefaultEngine()
		{
		}
		[SetUp]public void Init()
		{
			_problem.AddFeature("硬度等级", FeatureType.TYPE_FEATURE_INT,
				193, 1, false, false);
			_problem.AddFeature("厚度等级", FeatureType.TYPE_FEATURE_INT,
				2, 1, false, false);
			_problem.AddFeature("目标卷温等级", FeatureType.TYPE_FEATURE_INT,
				1, 1, false, false);
			_problem.AddFeature("目标卷温", FeatureType.TYPE_FEATURE_FLOAT,
				570.056, 1, false, false);
			_problem.AddFeature("终轧厚度", FeatureType.TYPE_FEATURE_FLOAT,
				2.6, 1, false, false);
			_problem.AddFeature("终轧速度", FeatureType.TYPE_FEATURE_FLOAT,
				11.12, 1, false, false);
			_problem.AddFeature("水温", FeatureType.TYPE_FEATURE_FLOAT,
				31.35, 1, false, false);
			_problem.AddFeature("上始阀", FeatureType.TYPE_FEATURE_INT,
				45, 1, true, true);

			_engine.SetEnvironmentVariable(_env);
			_engine.SetProblem(_problem);
		}
//		[Test]public void testStartup()
//		{
//			Assert.IsTrue(_engine.Startup());
//		}
		[Test]public void testRun()
		{
			Assert.IsTrue(_engine.Startup());
			_engine.Run();
		}
		
	}
}
