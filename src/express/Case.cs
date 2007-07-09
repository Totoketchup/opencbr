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
	using System.Collections;
	/// <summary>
	/// Case 
	/// </summary>
	/// <author>xw_cn@163.com</author>
	/// <version>1.0</version>
	/// <creationdate>2005-12-15</creationdate>
	/// <modificationdate></modificationdate>>
	/// <history></history>
	
	public class Case
	{
		private int _caseType = CaseType.CASE_DEFAULT;
		public int GetCaseType(){return _caseType;}
		private int _caseID;
		public int GetCaseID(){return _caseID;}
		public void SetCaseID(int caseID){_caseID = caseID;}
		private string _caseName;
		public string GetCaseName(){return _caseName;}
		private string _caseDescription;
		public string GetCaseDescription(){return _caseDescription;}
		private FeatureList _featureList;
		public Case(int caseID, string caseName, string caseDescription)
		{
			_caseID = caseID;
			_caseName = caseName;
			_caseDescription = caseDescription;
			_featureList = new FeatureList();
		}
		public Case(int caseID, string caseName, string caseDescription,
			int caseType)
		{
			_caseID = caseID;
			_caseName = caseName;
			_caseDescription = caseDescription;
			_caseType = caseType;
			_featureList = new FeatureList();
		}
		public Case(int caseID, string caseName, string caseDescription, 
			FeatureList featureList)
		{
			_caseID = caseID;
			_caseName = caseName;
			_caseDescription = caseDescription;
			if (featureList != null)
				_featureList = featureList;
			else
				_featureList = new FeatureList();
		}
		public Case(int caseID, string caseName, string caseDescription,
			FeatureList featureList, int caseType)
		{
			_caseID = caseID;
			_caseName = caseName;
			_caseDescription = caseDescription;
			if (featureList != null)
				_featureList = featureList;
			else
				_featureList = new FeatureList();
			_caseType = caseType;
		}
		/// <summary>
		/// add feature to case
		/// </summary>
		/// <param name="featureName"></param>
		/// <param name="featureType"></param>
		/// <param name="featureValue"></param>
		/// <param name="featureWeight"></param>
		/// <param name="isKey"></param>
		/// <param name="isIndex"></param>
		public void AddFeature(string featureName, 
			int featureType, object featureValue,
			double featureWeight, bool isKey,
			bool isIndex)
		{
			Feature feature = new Feature(featureName, featureType,
				featureValue, featureWeight, isKey, isIndex);
			_featureList.AddFeature(feature);
		}
		/// <summary>
		/// Remove feature from case
		/// </summary>
		/// <param name="featureName"></param>
		public void RemoveFeature(string featureName)
		{
			_featureList.RemoveFeature(featureName);
		}
		/// <summary>
		/// Modify feature of case
		/// </summary>
		/// <param name="featureName"></param>
		/// <param name="featureType"></param>
		/// <param name="featureValue"></param>
		/// <param name="featureWeight"></param>
		public void ModifyFeature(string featureName,
			int featureType, object featureValue,
			double featureWeight, bool isKey,
			bool isIndex)
		{
			Feature feature = new Feature(featureName, featureType,
				featureValue, featureWeight, isKey, isIndex);
			_featureList.ModifyFeature(feature);
		}
		/// <summary>
		/// return the feature list
		/// </summary>
		/// <returns></returns>
		public ArrayList GetFeatures()
		{
			return _featureList.GetFeatures();
		}
		public Feature GetFeature(string featureName)
		{
			ArrayList features = GetFeatures();
			if (features == null || features.Count <= 0)
			{
				return null;
			}
			Feature result = null;
			for (int i = 0; i < features.Count; i++)
			{
				Feature f = (Feature)features[i];
				if (f.GetFeatureName().Equals(featureName))
				{
					result = f;
					break;
				}
			}
			return result;
		}
	}
}
