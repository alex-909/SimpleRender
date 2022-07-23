using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleRendererProj
{
	class ScreenPoint
	{
		public float x;
		public float y;
		public char lighting;

		public ScreenPoint(float x, float y, char lighting) 
		{
			this.x = x;
			this.y = y;
			this.lighting = lighting;
		}
	}
}
