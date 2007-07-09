using System;

namespace org.opencbr.core.context
{
	using System.Collections;
	/// <summary>
	/// ConfigInfo 的摘要说明。
	/// </summary>
	public class ConfigInfo
	{
		private Hashtable _mapping = null;
		private Hashtable _outerDLL = null;
		private Hashtable _parameters = null;
		public ConfigInfo()
		{
			_mapping = new Hashtable();
			_outerDLL = new Hashtable();
			_parameters = new Hashtable();
		}
		/// <summary>
		/// add a entry of mapping
		/// </summary>
		/// <param name="entryKey">interface class name</param>
		/// <param name="entryValue">the implementation class name of interface</param>
		public void AddMappingEntry(string entryKey, string entryValue)
		{
			try
			{
				_mapping.Add(entryKey, entryValue);
			}
			catch(System.ArgumentException e)
			{
				if (Version.DEBUG)
					System.Console.WriteLine(e.StackTrace);
			}
		}
		/// <summary>
		/// remove a entry in mapping 
		/// </summary>
		/// <param name="entryKey"></param>
		public void RemoveMappingEntry(string entryKey)
		{
			_mapping.Remove(entryKey);
		}
		/// <summary>
		/// return the mapping entry value
		/// </summary>
		/// <param name="entryKey"></param>
		/// <returns></returns>
		public string GetMappingEntry(string entryKey)
		{
			return (string)_mapping[entryKey];
		}
		/// <summary>
		/// return the all mapping entry
		/// </summary>
		/// <returns></returns>
		public Hashtable GetMappingEntries()
		{
			return _mapping;
		}
		/// <summary>
		/// add the class file path
		/// </summary>
		/// <param name="entryKey"></param>
		/// <param name="path"></param>
		public void AddOuterDLLPath(string entryKey, string path)
		{
			try
			{
				_outerDLL.Add(entryKey, path);
			}
			catch(System.ArgumentException e)
			{
				if (Version.DEBUG)
					System.Console.WriteLine(e.Message);
			}
		}
		public string GetOuterDLLPath(string entryKey)
		{
			return (string)_outerDLL[entryKey];
		}
		public Hashtable GetOuterDLLPaths()
		{
			return _outerDLL;
		}
		/// <summary>
		/// add the parameter from config file
		/// </summary>
		/// <param name="entryKey"></param>
		/// <param name="entryValue"></param>
		public void AddParameter(string entryKey, string entryValue)
		{
			try
			{
				_parameters.Add(entryKey, entryValue);
			}
			catch(System.ArgumentException e)
			{
				if (Version.DEBUG)
					System.Console.WriteLine(e.Message);
			}
		}
		public string GetParameter(string entryKey)
		{
			return (string)_parameters[entryKey];
		}
		public Hashtable GetParameters()
		{
			return _parameters;
		}
	}
}
