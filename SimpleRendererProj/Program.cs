using System;
using System.Diagnostics;

namespace SimpleRendererProj
{
	// 2.15
	// .,-~:;=!*#$@   -> 12
	class Program
	{
		static void Main(string[] args)
		{
			float pi = MathF.PI;

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

			Vector3 midpoint = new Vector3(0, 0, 100);

			Vector3 pointTest = new Vector3(0, 0, 15);

			Vector3 lightSource = new Vector3(0, 0, -10);

			Stopwatch sw = Stopwatch.StartNew();
			//update

			while (true)
			{
				long runtime = sw.ElapsedMilliseconds;
				if (runtime % 10 == 0)
				{
					//tick();
					//1 frame:
					world.Clear();

					Console.WriteLine(runtime);

					float amplitude = MathF.Sqrt(30 * 30 * 2);

					#region y axis rotation
					
					//upper
					(point3f.x, point3f.z) = Calc.RotSinCos(amplitude, 0.001f * runtime, (7f/4f) * pi, midpoint.x, midpoint.z);
					(point4f.x, point4f.z) = Calc.RotSinCos(amplitude, 0.001f * runtime, (5f/4f) * pi, midpoint.x, midpoint.z);
					(point3b.x, point3b.z) = Calc.RotSinCos(amplitude, 0.001f * runtime, (1f/4f) * pi, midpoint.x, midpoint.z);
					(point4b.x, point4b.z) = Calc.RotSinCos(amplitude, 0.001f * runtime, (3f/4f) * pi, midpoint.x, midpoint.z);

					//lower
					(point1f.x, point1f.z) = Calc.RotSinCos(amplitude, 0.001f * runtime, (5f / 4f) * pi, midpoint.x, midpoint.z);
					(point2f.x, point2f.z) = Calc.RotSinCos(amplitude, 0.001f * runtime, (7f / 4f) * pi, midpoint.x, midpoint.z);
					(point1b.x, point1b.z) = Calc.RotSinCos(amplitude, 0.001f * runtime, (3f / 4f) * pi, midpoint.x, midpoint.z);
					(point2b.x, point2b.z) = Calc.RotSinCos(amplitude, 0.001f * runtime, (1f / 4f) * pi, midpoint.x, midpoint.z);

					#endregion

					point1b.y = point1f.y = point2b.y = point2f.y = -30;
					point3b.y = point3f.y = point4b.y = point4f.y = 30;

					#region x axis rotation

					Vector3[] points = new Vector3[]
					{
						point1f, point1b, 
						point2f, point2b,
						point3f, point3b,
						point4f, point4b,
					};

					float omegaT = 0.001f * runtime;
					points = Calc.RotatePointsAroundAxis(points, midpoint, Plane.YZ_Plane, omegaT, midpoint.y, midpoint.z);

					point1f = points[0];
					point1b = points[1];
					point2f = points[2];
					point2b = points[3];
					point3f = points[4];
					point3b = points[5];
					point4f = points[6];
					point4b = points[7];

					#endregion

					/*
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
					*/

					Face face1 = new Face(point1f, point2f-point1f, point4f-point1f, 2);
					Face face2 = new Face(point2f, point2b-point2f, point3f-point2f, 2);
					Face face3 = new Face(point3f, point3b-point3f, point4f-point3f, 2);
					Face face4 = new Face(point4f, point4b-point4f, point1f-point4f, 2);
					Face face5 = new Face(point1f, point1b-point1f, point2f-point1f, 2);
					Face face6 = new Face(point1b, point4b-point1b, point2b-point1b, 2);

					Face[] cubeFaces = new Face[]
					{
						face1, face2, face3,
						face4, face5, face6
					};



					world.AddFaces(cubeFaces, lightSource);
					world.AddPoint((pointTest, 1));


					Console.WriteLine($"world: {world.GetAllPoints().Length}");

					char[,] c = worldToScreen.ConvertWorldToScreen(world.GetAllPoints());

					Console.SetCursorPosition(0,0);
					ScreenWriter.Write(c, 150, 50);

					Console.WriteLine("end");
				}
			}
		}
	}
}
