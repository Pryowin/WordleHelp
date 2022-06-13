using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WordleHelp
{
	public class Words
	{
		private readonly string[] _wordList;

		public Words()
		{
			var assembly = Assembly.GetExecutingAssembly();
			var resourceName = "WordleHelp" + "." + "Words.txt";
			using Stream stream = assembly.GetManifestResourceStream(resourceName);

			using StreamReader reader = new StreamReader(stream);
			_wordList = reader.ReadToEnd().Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

		}
		public string[] WordList
		{
			get { return _wordList; }
		}
	}
}
