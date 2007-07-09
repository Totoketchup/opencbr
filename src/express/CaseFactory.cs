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
	/// CaseFactory 
	/// <author>xw_cn@163.com</author>
	/// <version>1.0</version>
	/// <creationdate>2005/11/15</creationdate>
	/// <modificationdate></modificationdate>>
	/// <history></history>
	/// </summary>
	public class CaseFactory
	{
		private static long instances;
		private static readonly int DEFAULT_CASE_ID = 1;
		private static readonly string DEFAULT_CASE_NAME = "default case name";
		private static readonly string DEFAULT_CASE_DES = "default case description";
		public static Case CreateInstance()
		{

			return CreateInstance(DEFAULT_CASE_ID, DEFAULT_CASE_NAME,
				DEFAULT_CASE_DES, CaseType.CASE_DEFAULT, null);
		}
		public static Case CreateInstance(int caseType)
		{
			return CreateInstance(DEFAULT_CASE_ID, DEFAULT_CASE_NAME,
				DEFAULT_CASE_DES, caseType, 
				null);

		}
		public static Case CreateInstance(string caseName)
		{
			return CreateInstance(DEFAULT_CASE_ID, caseName,
				DEFAULT_CASE_DES, CaseType.CASE_DEFAULT, 
				null);
		}
		public static Case CreateInstance(FeatureList featureList)
		{
			return CreateInstance(DEFAULT_CASE_ID, DEFAULT_CASE_NAME,
				DEFAULT_CASE_DES, CaseType.CASE_DEFAULT,
				featureList);
		}
		public static Case CreateInstance(int caseID, string caseName,
			string caseDescription, int caseType, FeatureList featureList)
		{
			Case instance = new Case(caseID, caseName, caseDescription,
				featureList,caseType);
			instances++;
			return instance;
		}
		public static Case Clone(Case c)
		{
			if (c == null)
				return null;
			FeatureList list = new FeatureList();
			Case instance = CaseFactory.CreateInstance(c.GetCaseID(),
				c.GetCaseName(),
				c.GetCaseDescription(),
				c.GetCaseType(),
				list);
			System.Collections.ArrayList features = c.GetFeatures();
			foreach(Feature f in features)
			{
				c.AddFeature(f.GetFeatureName(),
					f.GetFeatureType(),
					f.GetFeatureValue(),
					f.GetWeight(),
					f.GetIsKey(),
					f.GetIsIndex());
			}

			return instance;
		}
	}
}
