using System;

namespace org.opencbr.core.context
{
	using System.IO;
	using System.Xml;
	/// <summary>
	/// XMLConfigFile 的摘要说明。
	/// </summary>
	public class XMLConfigFile
	{
        private static readonly string TOKEN_NAMESPACE_CONFIG = "//config:";
        private static readonly string TOKEN_NODE_CONFIG = TOKEN_NAMESPACE_CONFIG;
        //private static readonly string TOKEN_NODE_CONFIG = "opencbr-config";
        //private static readonly string TOKEN_NODE_MAPPING = "mapping";
		private static readonly string TOKEN_NODE_METHOD = "method";
		//private static readonly string TOKEN_NODE_PARAMETERS = "parameters";
		private static readonly string TOKEN_NODE_PARAMETER = "parameter";
		private static readonly string TOKEN_ATTR_INTERFACE = "interface";
		private static readonly string TOKEN_ATTR_IMPL = "impl";
		private static readonly string TOKEN_ATTR_PATH = "path";
		private static readonly string TOKEN_ATTR_NAME = "name";
		private static readonly string TOKEN_ATTR_VALUE = "value";
		private ConfigInfo _configInfo = null;
		private string _path;
		public XMLConfigFile(string path)
		{
			_path = path;
		}
		/// <summary>
		/// return the configuration information from config file
		/// </summary>
		/// <returns></returns>
		public ConfigInfo GetConfigInfo()
		{
			try
			{
				XmlDocument doc = new XmlDocument();
				doc.Load(_path);
                //xmlns="http://tempuri.org/config.xsd"
                XmlNamespaceManager manager = new XmlNamespaceManager(doc.NameTable);

                if (doc.DocumentElement.NamespaceURI == "")
                    manager.AddNamespace("config", "http://tempuri.org/config.xsd");
                else
                    manager.AddNamespace("config", doc.DocumentElement.NamespaceURI);

                XmlNode rootNode = doc.SelectSingleNode("//config:opencbr-config", manager);

                string xmlPath = TOKEN_NAMESPACE_CONFIG
                    + TOKEN_NODE_METHOD;
                XmlNodeList methods = rootNode.SelectNodes(xmlPath, manager);
				if (methods != null 
					&& methods.Count > 0)
				{
					AddMappingInfo(methods);
				}
                //read the parameter setting
                xmlPath = TOKEN_NAMESPACE_CONFIG 
					+ TOKEN_NODE_PARAMETER;
                XmlNodeList parameters = rootNode.SelectNodes(xmlPath, manager);
				if (parameters != null
					&& parameters.Count > 0)
				{
					AddParameterInfo(parameters);
				}
			}
			catch(Exception e)
			{
				if (Version.DEBUG)
				{
					System.Console.WriteLine(e.StackTrace);
				}

				return null;
			}
			//verify data from xml file
			if (VerifyFile(_configInfo) == false)
			{
				System.Console.WriteLine("verify file data error");
			}

			return _configInfo;
		}
		/// <summary>
		/// add the mapping information 
		/// </summary>
		/// <param name="methods"></param>
		private void AddMappingInfo(XmlNodeList methods)
		{
			_configInfo = new ConfigInfo();

			for (int i = 0; i < methods.Count; i++)
			{

				XmlNode method = methods[i];
				XmlAttributeCollection attrs =  method.Attributes;
				if (attrs != null)
				{
					string attrKey = null;
					string attrValue = null;
					string attrPath = null;
					for (int j = 0; j < attrs.Count; j++)
					{
						XmlAttribute attr = attrs[j];
						if (attr.Name.Equals(TOKEN_ATTR_INTERFACE))
						{
							attrKey = attr.Value;
						}
						if (attr.Name.Equals(TOKEN_ATTR_IMPL))
						{
							attrValue = attr.Value;
						}
						if (attr.Name.Equals(TOKEN_ATTR_PATH))
						{
							attrPath = attr.Value;
						}
					}
					if (attrKey != null 
						&& attrValue != null)
					{
						_configInfo.AddMappingEntry(attrKey, attrValue);
						if (attrPath != null)
						{
							_configInfo.AddOuterDLLPath(attrKey, attrPath);
						}
					}
				}
			}
		}
		/// <summary>
		/// add the parameter information
		/// </summary>
		/// <param name="parameters"></param>
		private void AddParameterInfo(XmlNodeList parameters)
		{
			if (_configInfo == null)
				_configInfo = new ConfigInfo();

			for (int i = 0; i < parameters.Count; i++)
			{

				XmlNode parameter = parameters[i];
				XmlAttributeCollection attrs =  parameter.Attributes;
				if (attrs != null)
				{
					string attrKey = null;
					string attrValue = null;

					for (int j = 0; j < attrs.Count; j++)
					{
						XmlAttribute attr = attrs[j];
						if (attr.Name.Equals(TOKEN_ATTR_NAME))
						{
							attrKey = attr.Value;
						}
						if (attr.Name.Equals(TOKEN_ATTR_VALUE))
						{
							attrValue = attr.Value;
						}
						
					}
					if (attrKey != null 
						&& attrValue != null)
					{
						_configInfo.AddParameter(attrKey, attrValue);
					}
				}
			}
		}
		private bool VerifyFile(ConfigInfo config)
		{
			return true;
		}
	}
}
