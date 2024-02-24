using System.IO;
using System.Buffers.Binary;
using System;

class Program
{
	public static ConsoleColor[] foregroundColours = new[]
	{
		ConsoleColor.Blue,
		ConsoleColor.Green,
		ConsoleColor.Red,
		ConsoleColor.Yellow,
		ConsoleColor.Cyan,
		ConsoleColor.Magenta,
		ConsoleColor.Gray,
		ConsoleColor.White,
		ConsoleColor.DarkBlue,
		ConsoleColor.DarkGreen,
		ConsoleColor.DarkRed,
		ConsoleColor.DarkYellow,
		ConsoleColor.DarkCyan,
		ConsoleColor.DarkMagenta,
		ConsoleColor.DarkGray
	};
	public static string moyai = "";
	public static void Main(string[] args)
	{
		var rootDirectory = Directory.GetCurrentDirectory();

		moyai = Path.Combine(rootDirectory, "boom.wav");

		if (File.Exists(moyai))
		{
			Console.WriteLine("🗿 found! Running recursive replacement operation..");

			FolderSearch(Directory.GetDirectories(rootDirectory), 0);

			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("\nSuccess!!!");
			//	-->	https://ascii-generator.site/
			//Console.WriteLine("         ..::----======----::..         \r\n      :-========================-:      \r\n     -=============================     \r\n    .=====+*##%%@@@@@@@@%%##*+=====.    \r\n    -==*%@@@@@@@@@@@@@@@@@@@@@@%*==-.   \r\n  :@+*@@@@@@@@@@@@@@@@@@@@@@@@@@@@#+@-  \r\n  %@=+*%%@@@@@@@#+====+#@@@@@@@%%#+=@@  \r\n :@@========++#@========#%*+========@@- \r\n +@@===========@========%*==========%@* \r\n #@%===========%+=======@===========%@@ \r\n @@%===========#+=======@===========#@@.\r\n:@@%===========#+=======%===========#@@-\r\n=@@%===========*==++++==*===========#@@+\r\n*@@%===========+#@@@@@@%+===========#@@#\r\n%@@%==========#@@@@@@@@@@%==========#@@%\r\n@@@%==========*#%%%%%%%%#*==========%@@@\r\n%@@@===========+**####**+===========%@@%\r\n+@@@========+***++++++++***+========@@@*\r\n *@@========*#%@@@@@@@@@@%%*========@@# \r\n   :-======%@@@@@@@@@@@@@@@@%======-:   \r\n    :==============================:    \r\n   .*==============================#.   \r\n   %@==============================%%   \r\n  =@@%*==========================+#@@+  \r\n  #@@@@@@%%###************###%%@@@@@@%  \r\n  :*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#:  \r\n");
			Console.WriteLine("                     :----------=+*++--:.::. \r\n                  .------------+*******=--**=\r\n                .------------=********+--=***\r\n              =+++++++++++++**********=--+**=\r\n           .*@@@@@@@@@@@@@@@@@#*******---***:\r\n           *@@@@@@@@@@@@@@@@@@@******+--=*** \r\n           *@@@#+==*#@@@@@@@@@@******=--+**= \r\n           *@#=--+****+#@@@@@@#******---***: \r\n          .=---=*****+--=+**#*******+--=***  \r\n        .-----+******-------+*******=--+**=  \r\n      :-----=*******=-------+*******---***:  \r\n   .-------+*******=--------+******+--=***   \r\n .-------=********+---------+******=--+**=   \r\n=+++++++*********+----------+*****+---***.   \r\n%%%%%%%%%%%%%%%%*-----------+*****=--=**+    \r\n#@@@@@@@@@@@@@#=------------+*****---+**-    \r\n :*@@@@@@@@%*---------------+****=---***.    \r\n   =#@@@@%+---------------=+***++++++**+     \r\n   ---==---------------=+***********+=-      \r\n   ------------------=+*************=        \r\n   ----------------=+***************.        \r\n  :-------------=+****************:          \r\n :------------=+***************#@@.          \r\n------------=+***************%@@@@%-         \r\n+*************************#%@@@@%#***-       \r\n =**********************#@@@@@%********=.    \r\n   ::---+%%%%%%%%%%%%@@@@@@@%************=:  \r\n        =%%%%%%%%%%%%%%%%%#****************+ \r\n      .-------------------=+****************=\r\n    :------------------------+***************\r\n   ----------------------------=+************\r\n   ------------------------------=+********+.\r\n   ---------------------------------+****+-  \r\n");
			Console.ResetColor();
			Console.WriteLine("Press the ANY key to close.");
			Console.ReadKey();

			return;
		}
		Console.ForegroundColor = ConsoleColor.DarkRed;
		Console.WriteLine($"🗿 not found! Make sure 'boom.wav' exists in the same folder as this executable.. ({Path.Combine(rootDirectory, "boom.wav")})");
		Console.WriteLine("Press the ANY key to close.");
		Console.ReadKey();
	}
	public static void FolderSearch(string[] paths, int index)
	{
		if (index >= paths.Length)
			return;

		FileMoyaification(Directory.GetFiles(paths[index]), 0);
		FolderSearch(Directory.GetDirectories(paths[index]), 0);

		FolderSearch(paths, index + 1);
	}
	public static void FileMoyaification(string[] paths, int index)
	{
		if (index >= paths.Length)
			return;

		FileMoyaification(paths, index + 1);

		if (Path.GetExtension(paths[index]) != Path.GetExtension(moyai))
			return;

		File.Copy(moyai, paths[index], true);
		Console.ForegroundColor = foregroundColours[index % foregroundColours.Length];
		Console.WriteLine($"{paths[index]} replaced with 🗿");
	}
}