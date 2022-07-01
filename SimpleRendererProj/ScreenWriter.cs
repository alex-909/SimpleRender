using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleRendererProj
{
	//writes char array on screen
	class ScreenWriter
	{
		//char[x][y]
		public static void Write(char[,] characters, int xLen, int yLen) 
		{
			for (int j = (yLen - 1); j >= 0; j--)
			{
				string s = "";
				for (int i = 0; i < xLen; i++) 
				{
					s += characters[i,j];
				}
				Console.WriteLine(s);
			}
		}
	}
}
