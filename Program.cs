using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempName
{
	class Program
	{
		static string shortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Shortcuts/";
		static string archivePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Archives/";
		static string executablePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Executables/";
		static string picturePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Pictures/";
		static string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Documents/";

		static void Main(string[] args)
		{
			List<string> files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)).ToList<string>();
			string[] publicFiles = Directory.GetFiles("C:\\Users\\Public\\Desktop");

			foreach(string file in publicFiles)
			{
				files.Add(file);
			}

			List<string> shortcuts = new List<string>();
			List<string> executables = new List<string>();
			List<string> archives = new List<string>();
			List<string> pictures = new List<string>();
			List<string> documents = new List<string>();

			foreach (string file in files)
			{
				Console.WriteLine(file);

				if (file.EndsWith(".lnk") || file.EndsWith(".url") || file.EndsWith(".pif") || file.EndsWith(".scf") || file.EndsWith(".shs") || file.EndsWith(".shb") || file.EndsWith(".xnk"))
					shortcuts.Add(file);
				if (file.EndsWith(".exe"))
					executables.Add(file);
				if (file.EndsWith(".zip") || file.EndsWith(".rar"))
					archives.Add(file);
				if (file.EndsWith(".jpg") || file.EndsWith(".png") || file.EndsWith(".gif"))
					pictures.Add(file);
				if (file.EndsWith(".txt"))
					documents.Add(file);
			}

			Console.WriteLine("\n");
			files = null;

			foreach (string shortcut in shortcuts)
				Console.WriteLine(shortcut);

			Console.WriteLine("\n");

			if (!Directory.Exists(shortcutPath))
				Directory.CreateDirectory(shortcutPath);
			if (!Directory.Exists(executablePath))
				Directory.CreateDirectory(executablePath);
			if (!Directory.Exists(archivePath))
				Directory.CreateDirectory(archivePath);
			if (!Directory.Exists(picturePath))
				Directory.CreateDirectory(picturePath);
			if (!Directory.Exists(documentPath))
				Directory.CreateDirectory(documentPath);


			MoveFiles(shortcutPath, shortcuts);
			MoveFiles(archivePath, archives);
			MoveFiles(executablePath, executables);
			MoveFiles(picturePath, pictures);
			MoveFiles(documentPath, documents);

			Console.ReadKey(true);
		}

		static void MoveFiles(string filePath, List<string> files)
		{
			foreach(string file in files)
			{
				string[] fileNameFragments = file.Split('\\');
				string fileName = fileNameFragments[fileNameFragments.Length - 1];
				string newFilePath = filePath + fileName;

				File.Move(file, newFilePath);
				Console.WriteLine("Moved: {0}", fileName);
			}
		}
	}
}
