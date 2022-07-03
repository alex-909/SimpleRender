using System;
using System.Collections.Generic;
using System.Text;



namespace SimpleRendererProj
{
	class WorldToScreen
	{
		Vector3 camera;

		int minX;
		int maxX;

		int minY;
		int maxY;

		int z; // relative to (0/0/0) not camera

		public WorldToScreen(Vector3 camera, ScreenBoundary screen) 
		{
			this.camera = camera;
			minX = screen.minX;
			maxX = screen.maxX;

			minY = screen.minY;
			maxY = screen.maxY;

			this.z = screen.z;
		}

		public char[,] ConvertWorldToScreen(Vector3[] points) 
		{
			List<ScreenPoint> screenPoints = new List<ScreenPoint>();
			foreach (Vector3 point in points) 
			{
				ScreenPoint s = ConvertPointToScreen(point);
				//

				bool stretch = true;
				if (stretch) 
				{
					s.x -= (maxX - minX) / 2;
					s.x *= 2.14f;
					s.x += (maxX - minX) / 2;
				}

				
				if ((s.x < 0) || (s.x >= maxX*2) || (s.y < 0) || (s.y >= maxY*2)) 
				{
					continue;
					//point not on screen
				}

				screenPoints.Add(s);
			}

			return ScreenToChar(screenPoints.ToArray());
		}

		public char[,] ScreenToChar(ScreenPoint[] points) 
		{
			char[,] characters = new char[maxX - minX , maxY - minY];
			for (int j = 0; j < (maxY - minY); j++) 
			{
				for (int i = 0; i < (maxX - minX); i++)
				{
					characters[i,j] = '.';
				}
			}

			Console.WriteLine("in screenToChar");
			Console.WriteLine(points.Length);

			foreach (ScreenPoint point in points) 
			{
				int x = (int)point.x;
				int y = (int)point.y;
				characters[x, y] = '#';
			}

			return characters;
		}

		public ScreenPoint ConvertPointToScreen(Vector3 point) 
		{
			float world_deltaz = point.z - camera.z;

			float deltaX = (point.x - camera.x) * (z - camera.z) / (world_deltaz);
			float deltaY = (point.y - camera.y) * (z - camera.z) / (world_deltaz);

			float planeX = camera.x + deltaX;
			float planeY = camera.y + deltaY;

			float screenX = planeX - minX;
			float screenY = planeY - minY;

			return new ScreenPoint(screenX, screenY);
		}
	}
}
