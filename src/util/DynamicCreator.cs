using System;

namespace org.opencbr.core.util
{
	using System.Reflection;
	/// <summary>
	/// create instances dynamically by refelect
	/// </summary>
	public class DynamicCreator
	{
		/// <summary>
		/// create instance of class 
		/// note that class is in the same assembly
		/// </summary>
		/// <param name="classType"></param>
		/// <returns></returns>
		public static object CreateInstance(Type classType)
		{
			return Activator.CreateInstance(classType);
		}
		/// <summary>
		/// create instance from outer DLL file
		/// </summary>
		/// <param name="className"></param>
		/// <param name="path"></param>
		/// <returns></returns>
		public static object CreateInstance(string className, string path)
		{
			return null;
		}
	}
}
