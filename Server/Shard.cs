#region Header
// Shard.cs XML setting reader.
#endregion

#region References
using System;
using System.Xml;
#endregion

namespace Server
{
	public static class Shard
	{
		private static XmlDocument settings = new XmlDocument();
		private static string xmlfile = "startup.xml";  // Declare and Set vars needed to load xml file
		
		public static string Xml(string setting)  // used in calling script to reference xml setting ex. Shard.Xml("shardname")
		{
			Shard.settings.Load(Shard.xmlfile); // Load Xml File
			return Shard.settings.SelectSingleNode("startupinfo/" + setting).InnerText; // read xml and return value as string, must be converted in
		}	                                                                            // calling script ex. Convert.ToInt32(Shard.Xml("statcap"))
		                                                                                // server will crash if no matching setting is found in xml file
	}
}