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

namespace org.opencbr.core.Similarity
{
	using org.opencbr.core.express;
	using System.Collections;
	/// <summary>
	/// EuclideanSimilarity 
	/// <author>xw_cn@163.com</author>
	/// <version>1.0</version>
	/// <creationdate>2005/11/28</creationdate>
	/// <modificationdate></modificationdate>>
	/// <history></history>
	/// </summary>
	public class EuclideanSimilarity:ISimilarity
	{
		protected double _alpha = 0.3;
		public EuclideanSimilarity()
		{
		}
		/// <summary>
		/// set the constant alpha which is a position constant
		/// default value is 1
		/// </summary>
		/// <param name="alpha"></param>
		public void SetAlpha(double alpha)
		{
			if (alpha <= 0)
			{
				//throw exception
			}
			_alpha = alpha;
		}
		#region ISimilarity ³ÉÔ±

		protected string _env = null;
		public void SetEnv(string env){_env = env;}
		public string GetEnv(){return _env;}
		/// <summary>
		/// compute the similarity between problem and solution
		/// throw exception NoSupportTypeException
		/// </summary>
		/// <param name="problem"></param>
		/// <param name="solution"></param>
		/// <returns>the value of similarity</returns>
		public double Compare(org.opencbr.core.express.Case problem, 
							org.opencbr.core.express.Case solution)
		{
			if (problem == null || solution == null)
			{
				return 0;
			}
			double totalSimilarity = 0;
			ArrayList problemFeatures = problem.GetFeatures();
			ArrayList solutionFeatures = solution.GetFeatures();
			if (problemFeatures != null && solutionFeatures != null
				&&problemFeatures.Count > 0 && solutionFeatures.Count > 0
				&&problemFeatures.Count == solutionFeatures.Count)
			{
				int length = problemFeatures.Count;

				for (int i = 0; i < length; i++)
				{
					Feature problemf = (Feature)problemFeatures[i];
					string problemFeatureName = problemf.GetFeatureName();
					if (problemFeatureName == null 
						|| problemFeatureName.Length <= 0)
					{
						//throw exception
					}
					for (int j = 0; j < length; j++)
					{
						Feature solutionf = (Feature)solutionFeatures[j];
						string solutionFeatureName = solutionf.GetFeatureName();
						if (solutionFeatureName == null 
							|| solutionFeatureName.Length <= 0)
						{
							//throw exception
						}
						
						//compute the similarity if same feature name and same weight 
						//and not key
						if (problemFeatureName.Equals(solutionFeatureName)
							&& problemf.GetWeight() == solutionf.GetWeight()
							&& problemf.GetIsKey() == false
							&& solutionf.GetIsKey() == false
							&& problemf.GetFeatureType() == solutionf.GetFeatureType()
							)
						{
							double weight = problemf.GetWeight();
							double diff = Math.Pow(weight, 2) 
								* Compute(problemf, solutionf);

							if (Version.DEBUG)
								System.Console.WriteLine(problemf.GetFeatureName() 
									+ "'s weight: " + weight 
									+ "\n\tdata: " + problemf.GetFeatureValue()
									+ "\t" + solutionf.GetFeatureValue());

							totalSimilarity += diff;
						}
					}
				}
			}
			else
			{
				//throw exception
			}
			double distance = Math.Sqrt(totalSimilarity);
			
			double result = 1 / (1 + _alpha * distance);
			if (Version.DEBUG)
			{
				System.Console.WriteLine("similarity is " + result);
				//System.Console.WriteLine("alpha is " + _alpha);
			}
			return result;
		}

		#endregion

		/// <summary>
		/// return the power of differences between problem feature and solution feature
		/// note that now only support numberic feature type
		/// </summary>
		/// <param name="problem"></param>
		/// <param name="solution"></param>
		/// <returns></returns>
		public virtual double Compute(Feature problem, Feature solution)
		{
			if (problem.GetFeatureType() != solution.GetFeatureType())
			{
				//throw exception
			}

			int featureType = problem.GetFeatureType();
			double diff = 0;
			if (featureType == FeatureType.TYPE_FEATURE_BOOL)
			{
				diff = TypeHandle.DoType((System.Boolean)problem.GetFeatureValue(),
					(System.Boolean)solution.GetFeatureValue());
			}
			else if (featureType == FeatureType.TYPE_FEATURE_FLOAT)
			{
				diff = TypeHandle.DoType((System.Double)Convert.ToDouble(problem.GetFeatureValue().ToString()),
					(System.Double)Convert.ToDouble(solution.GetFeatureValue().ToString()));
			}
			else if (featureType == FeatureType.TYPE_FEATURE_IMAGE)
			{
			}
			else if (featureType == FeatureType.TYPE_FEATURE_INT)
			{
				diff = TypeHandle.DoType(
					(System.Int32)Convert.ToInt32(problem.GetFeatureValue().ToString()),
					(System.Int32)Convert.ToInt32(solution.GetFeatureValue().ToString()));
			}
			else if (featureType == FeatureType.TYPE_FEATURE_MSTRING)
			{
			}
			else if (featureType == FeatureType.TYPE_FEATURE_STRING)
			{
			}
			else if (featureType == FeatureType.TYPE_FEATURE_UNDEFINED)
			{
			}
			else
			{
				//throw exception
			}
			return Math.Pow(diff, 2);		
		}
	}
}
