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
			ScreenBoundary screen = new ScreenBoundary(-75, 75, -25, 25, 20);
			WorldToScreen worldToScreen = new WorldToScreen(camera, screen);

			Vector3 point1f = new Vector3(-30, -30, 40);
			Vector3 point2f = new Vector3( 30, -30, 40);
			Vector3 point3f = new Vector3( 30,  30, 40);
			Vector3 point4f = new Vector3(-30,  30, 40);

			Vector3 point1b = new Vector3(-30, -30, 100);
			Vector3 point2b = new Vector3( 30, -30, 100);
			Vector3 point3b = new Vector3( 30,  30, 100);
			Vector3 point4b = new Vector3(-30,  30, 100);

			Vector3 pointTest = new Vector3(0, 0, 15);

			Line line1f = new Line(point1f, point2f, 5);
			Line line2f = new Line(point2f, point3f, 5);
			Line line3f = new Line(point3f, point4f, 5);
			Line line4f = new Line(point1f, point4f, 5);

			Line line1b = new Line(point1b, point2b, 5);
			Line line2b = new Line(point2b, point3b, 5);
			Line line3b = new Line(point3b, point4b, 5);
			Line line4b = new Line(point1b, point4b, 5);

			Line line1s = new Line(point1b, point1f, 5);
			Line line2s = new Line(point2b, point2f, 5);
			Line line3s = new Line(point3b, point3f, 5);
			Line line4s = new Line(point4b, point4f, 5);

			world.AddPoint(line1f.PointsOnLine());
			world.AddPoint(line2f.PointsOnLine());
			world.AddPoint(line3f.PointsOnLine());
			world.AddPoint(line4f.PointsOnLine());

			world.AddPoint(line1b.PointsOnLine());
			world.AddPoint(line2b.PointsOnLine());
			world.AddPoint(line3b.PointsOnLine());
			world.AddPoint(line4b.PointsOnLine());

			world.AddPoint(line1s.PointsOnLine());
			world.AddPoint(line2s.PointsOnLine());
			world.AddPoint(line3s.PointsOnLine());
			world.AddPoint(line4s.PointsOnLine());

			world.AddPoint(pointTest);
			

			Console.WriteLine($"world: {world.GetAllPoints().Length}");

			char[,] c = worldToScreen.ConvertWorldToScreen(world.GetAllPoints());

			ScreenWriter.Write(c, 150, 50);

			Console.WriteLine("end");
			Console.ReadKey();
		}
	}
}
