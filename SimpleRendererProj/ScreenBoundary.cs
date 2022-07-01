using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleRendererProj
{
	public struct ScreenBoundary
	{
		public ScreenBoundary(int minX, int maxX, int minY, int maxY, int z) 
		{
			this.minX = minX;
			this.maxX = maxX;

			this.minY = minY;
			this.maxY = maxY;

			this.z = z;
		}

		public int minX;
		public int maxX;

		public int minY;
		public int maxY;

		public int z;
	}
}
