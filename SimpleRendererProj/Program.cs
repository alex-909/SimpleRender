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

			Vector3 point1f = new Vector3(-30, -30, -30);
			Vector3 point2f = new Vector3( 30, -30, -30);
			Vector3 point3f = new Vector3( 30,  30, -30);
			Vector3 point4f = new Vector3(-30,  30, -30);

			Vector3 point1b = new Vector3(-30, -30, 30);
			Vector3 point2b = new Vector3( 30, -30, 30);
			Vector3 point3b = new Vector3( 30,  30, 30);
			Vector3 point4b = new Vector3(-30,  30, 30);

			Vector3 offset = new Vector3(0, 0, 100);
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
					
					Vector3[] points = new Vector3[]
					{
						point1f, point1b,
						point2f, point2b,
						point3f, point3b,
						point4f, point4b,
					};

					//rot
					float omegaT = 0.001f * runtime;

					points = Matrix.PointsAroundAxis(Matrix.RotX(-omegaT), points);
					points = Matrix.PointsAroundAxis(Matrix.RotY(omegaT * 2), points);
					points = Matrix.PointsAroundAxis(Matrix.RotZ(omegaT), points);
					points = Calc.CalcOffset(points, offset);

					Vector3 point1f_ = points[0];
					Vector3 point1b_ = points[1];
					Vector3 point2f_ = points[2];
					Vector3 point2b_ = points[3];
					Vector3 point3f_ = points[4];
					Vector3 point3b_ = points[5];
					Vector3 point4f_ = points[6];
					Vector3 point4b_ = points[7];
					
					
					Line line1f = new Line(point1f_, point2f_, 5);
					Line line2f = new Line(point2f_, point3f_, 5);
					Line line3f = new Line(point3f_, point4f_, 5);
					Line line4f = new Line(point1f_, point4f_, 5);

					Line line1b = new Line(point1b_, point2b_, 5);
					Line line2b = new Line(point2b_, point3b_, 5);
					Line line3b = new Line(point3b_, point4b_, 5);
					Line line4b = new Line(point1b_, point4b_, 5);

					Line line1s = new Line(point1b_, point1f_, 5);
					Line line2s = new Line(point2b_, point2f_, 5);
					Line line3s = new Line(point3b_, point3f_, 5);
					Line line4s = new Line(point4b_, point4f_, 5);

					Line[] cubeLines = new Line[]
					{
						line1f, line2f, line3f, line4f,
						line1b, line2b, line3b, line4b,
						line1s, line2s, line3s, line4s
					};

					world.AddLines(cubeLines);
					/*
					
					Face face1 = new Face(point1f_, point4f_-point1f_, point2f_-point1f_, 2);
					Face face2 = new Face(point2f_, point3f_-point2f_, point2b_-point2f_, 2);
					Face face3 = new Face(point3f_, point4f_-point3f_, point3b_-point3f_, 2);
					Face face4 = new Face(point4f_, point1f_-point4f_, point4b_-point4f_, 2);
					Face face5 = new Face(point1f_, point2f_-point1f_, point1b_-point1f_, 2);
					Face face6 = new Face(point1b_, point2b_-point1b_, point4b_-point1b_, 2);

					Face[] cubeFaces = new Face[]
					{
						face1, face2, face3,
						face4, face5, face6
					};

					world.AddFaces(cubeFaces, lightSource);
					*/
					
					//world.AddPoint((pointTest, 1));

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
