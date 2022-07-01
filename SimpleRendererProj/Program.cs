using System;

namespace SimpleRendererProj
{
	//2.15
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("start");

			World world = new World();

			Vector3 camera = new Vector3(0, 0, 0);
			ScreenBoundary screen = new ScreenBoundary(-25, 25, -25, 25, 10);
			WorldToScreen worldToScreen = new WorldToScreen(camera, screen);


			Vector3 point1 = new Vector3(-25,-25,20);
			Vector3 point2 = new Vector3(20, 20, 25);

			Line line = new Line(point1, point2, 5);
			Console.WriteLine($"line: {line.PointsOnLine().Length}");

			world.AddPoint(line.PointsOnLine());
			Console.WriteLine($"world: {world.GetAllPoints().Length}");

			char[,] c = worldToScreen.ConvertWorldToScreen(world.GetAllPoints());
			ScreenWriter.Write(c, 50, 50);

			Console.WriteLine("end");
			Console.ReadKey();
		}
	}
}
