using System;
using System.Diagnostics;

namespace SimpleRendererProj
{
	//2.15
	class Program
	{
		public static char empty = ' ';
		public static char full = '#';

		static void Main(string[] args)
		{
			//setup
			Console.WriteLine("start");

			World world = new World();

			Vector3 camera = new Vector3(0, 0, -10);
			ScreenBoundary screen = new ScreenBoundary(-75, 75, -25, 25, 20);
			WorldToScreen worldToScreen = new WorldToScreen(camera, screen);

			Vector3 point1f = new Vector3(-30, -30, 70);
			Vector3 point2f = new Vector3( 30, -30, 70);
			Vector3 point3f = new Vector3( 30,  30, 70);
			Vector3 point4f = new Vector3(-30,  30, 70);

			Vector3 point1b = new Vector3(-30, -30, 130);
			Vector3 point2b = new Vector3( 30, -30, 130);
			Vector3 point3b = new Vector3( 30,  30, 130);
			Vector3 point4b = new Vector3(-30,  30, 130);

			Vector3 uppermid = new Vector3(0, 30, 100);
			Vector3 lowermid = new Vector3(0, -30, 100);

			Vector3 pointTest = new Vector3(0, 0, 15);

			Stopwatch sw = Stopwatch.StartNew();
			//update

			while (true)
			{
				long runtime = sw.ElapsedMilliseconds;
				if (runtime % 100 == 0)
				{
					//1 frame:
					world.Clear();

					Console.WriteLine(runtime);

					float amplitude = (uppermid - point3f).Length();

					//upper
					point3f.x = (amplitude * MathF.Sin((0.001f * runtime) + ((7f / 4f) * MathF.PI))) + uppermid.x;
					point3f.z = (amplitude * MathF.Cos((0.001f * runtime) + ((7f / 4f) * MathF.PI))) + uppermid.z;

					point4f.x = (amplitude * MathF.Sin((0.001f * runtime) + ((5f / 4f) * MathF.PI))) + uppermid.x;
					point4f.z = (amplitude * MathF.Cos((0.001f * runtime) + ((5f / 4f) * MathF.PI))) + uppermid.z;

					point3b.x = (amplitude * MathF.Sin((0.001f * runtime) + ((1f / 4f) * MathF.PI))) + uppermid.x;
					point3b.z = (amplitude * MathF.Cos((0.001f * runtime) + ((1f / 4f) * MathF.PI))) + uppermid.z;

					point4b.x = (amplitude * MathF.Sin((0.001f * runtime) + ((3f / 4f) * MathF.PI))) + uppermid.x;
					point4b.z = (amplitude * MathF.Cos((0.001f * runtime) + ((3f / 4f) * MathF.PI))) + uppermid.z;

					//lower
					point1f.x = (amplitude * MathF.Sin((0.001f * runtime) + ((5f / 4f) * MathF.PI))) + lowermid.x;
					point1f.z = (amplitude * MathF.Cos((0.001f * runtime) + ((5f / 4f) * MathF.PI))) + lowermid.z;

					point2f.x = (amplitude * MathF.Sin((0.001f * runtime) + ((7f / 4f) * MathF.PI))) + lowermid.x;
					point2f.z = (amplitude * MathF.Cos((0.001f * runtime) + ((7f / 4f) * MathF.PI))) + lowermid.z;

					point1b.x = (amplitude * MathF.Sin((0.001f * runtime) + ((3f / 4f) * MathF.PI))) + lowermid.x;
					point1b.z = (amplitude * MathF.Cos((0.001f * runtime) + ((3f / 4f) * MathF.PI))) + lowermid.z;

					point2b.x = (amplitude * MathF.Sin((0.001f * runtime) + ((1f / 4f) * MathF.PI))) + lowermid.x;
					point2b.z = (amplitude * MathF.Cos((0.001f * runtime) + ((1f / 4f) * MathF.PI))) + lowermid.z;

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

					Line[] cubeLines = new Line[]
					{
						line1f, line2f, line3f, line4f,
						line1b, line2b, line3b, line4b,
						line1s, line2s, line3s, line4s
					};

					world.AddLines(cubeLines);
					world.AddPoint(pointTest);


					Console.WriteLine($"world: {world.GetAllPoints().Length}");

					char[,] c = worldToScreen.ConvertWorldToScreen(world.GetAllPoints());

					Console.Clear();
					ScreenWriter.Write(c, 150, 50);

					Console.WriteLine("end");
				}
			}
		}
	}
}
