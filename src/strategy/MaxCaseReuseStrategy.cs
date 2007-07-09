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

namespace org.opencbr.core.strategy
{
	using org.opencbr.core.express;
	using org.opencbr.core.context;
	using System.Collections;
	/// <summary>
	/// MaxCaseReuseStrategy 
	/// <author>xw_cn@163.com</author>
	/// <version>1.0</version>
	/// <creationdate>2005/11/30</creationdate>
	/// <modificationdate></modificationdate>>
	/// <history></history>
	/// </summary>
	public class MaxCaseReuseStrategy:ICaseReuseStrategy
	{
		public MaxCaseReuseStrategy()
		{
		}
		#region ICaseReuseStrategy ≥…‘±

		private string _env = null;
		public void SetEnv(string env){_env = env;}
		public string GetEnv(){return _env;}
		public Case Reuse(ArrayList stats)
		{
			if (stats == null || stats.Count <= 0)
			{
				return null;
			}

			if (_env == null)
				throw new ContextException("environment variable is not set");

			ICBRContext ctx = CBRContextManager.GetCBRContext(_env);
			if (ctx == null)
			{
				throw new ContextException("context is not set");
			}
			Case problem = ctx.GetCurrentCase();
			Case c = ((IStat)(stats[0])).GetCBRCase();
			if (c != null && problem != null)
			{
				ArrayList features = c.GetFeatures();
				for (int i = 0; i < features.Count; i++)
				{
					Feature f = (Feature)features[i];
					//if the feature is the key of problem
					if (f.GetIsKey())
					{
						problem.ModifyFeature(f.GetFeatureName(), 
							f.GetFeatureType(), f.GetFeatureValue(),
							f.GetWeight(), f.GetIsKey(),
							f.GetIsIndex());
					}
				}

				return problem;
			}
			return null;
		}

		#endregion
	}
}
