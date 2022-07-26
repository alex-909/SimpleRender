using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleRendererProj
{
	class Face
	{
		Vector3 origin;
		Vector3 dir1;
		Vector3 dir2;

		public float ppU;
		public float intensity = 1;

		public Face(Vector3 origin, Vector3 dir1, Vector3 dir2, float ppU)
		{
			this.origin = origin;
			this.dir1 = dir1;
			this.dir2 = dir2;
			this.ppU = ppU;
		}

		public (Vector3 pos, float f)[] PointsOnFace() 
		{
			List<(Vector3, float)> facePoints = new List<(Vector3, float)>();

			Vector3 start = origin;
			Vector3 end = origin + dir1;
			Line line1 = new Line(start, end, ppU);

			Vector3[] points1 = line1.PointsOnLine();
			Vector3[] points2 = new Vector3[points1.Length];
			for (int i = 0; i < points1.Length; i++) 
			{
				points2[i] = points1[i] + dir2;
			}

			for (int i = 0; i < points1.Length; i++)
			{
				Line line3 = new Line(points1[i], points2[i], ppU);
				foreach (Vector3 point in line3.PointsOnLine())
				{
					facePoints.Add((point, intensity));
				}
			}

			//Console.WriteLine($"facepoints length: {facePoints.Count}");
			return facePoints.ToArray();
		}

		public void CalculateLighting(Vector3 lightSource) 
		{
			Vector3 surfaceMid = origin + ((dir1 + dir2) * 0.5f);
			Vector3 surfaceNormal = Vector3.CrossProduct(dir1, dir2).Normalized();
			Vector3 lightDir = (lightSource - surfaceMid).Normalized();

			float f = Vector3.DotProduct(lightDir, surfaceNormal);
			this.intensity = MathF.Max(0, f);
		}
	}
}
