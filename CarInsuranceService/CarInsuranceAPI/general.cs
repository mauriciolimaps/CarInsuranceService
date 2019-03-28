using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarInsuranceAPI
{
	public class General
	{
		public static string AssemblyDirectory
		{
			get
			{
				string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
				UriBuilder uri = new UriBuilder(codeBase);
				string path = Uri.UnescapeDataString(uri.Path);

				return System.IO.Path.GetDirectoryName(path);
			}
		}
	}
}