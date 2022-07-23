using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleRendererProj
{
	class Line
	{
		public Vector3 start;
		public Vector3 end;

		public float pointsPerUnit;

		public Line(Vector3 start, Vector3 end, float ppU) 
		{
			this.start = start;
			this.end = end;
			pointsPerUnit = ppU;
		}

		public Vector3[] PointsOnLine()
		{
			List<Vector3> points = new List<Vector3>();

			float length = (end - start).Length();
			float num = pointsPerUnit * length;
			int numberOfPoints = (int)num;

			Vector3 pointVector = (end - start) / numberOfPoints;

			for (int i = 0; i < numberOfPoints; i++) 
			{
				Vector3 v1 = start + (pointVector * i);
				points.Add(v1);
			}

			return points.ToArray();
		}
	}
}
