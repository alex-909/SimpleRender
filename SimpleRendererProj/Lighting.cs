using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleRendererProj
{
	// .,-~:;=!*#$@
	class Lighting
	{
		public static char empty = ' ';
		public static char full = '#';

		public static string lightString = ".:-=+*#%@@";
		//public static string lightString = ".,-~:;=*#$$";
		//public static string lightString = ".,-~:;=!*#$@";
		//public static string lightString = @"$@B%8&WM#oahdpwmZOLCJYXzcvrjft/\|()1{}[]?+~<>i!lI;:,^`'.";

		public static char[] lightChars = lightString.ToCharArray();

		public static char LightToChar(float intensity)
		{
			return lightChars[(int)((lightChars.Length - 1) * intensity)];
		}
		public static string Reverse(string s)
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}
	}
}
