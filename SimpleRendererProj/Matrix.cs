using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleRendererProj
{
	class Matrix
	{
		public static float[,] RotX(float phi) 
		{
			float sin = MathF.Sin(phi);
			float cos = MathF.Cos(phi);
			return new float[,]
			{
				{1, 0,    0 },
				{0, cos, -sin },
				{0, sin,  cos },
			};
		}
		public static float[,] RotY(float phi)
		{
			float sin = MathF.Sin(phi);
			float cos = MathF.Cos(phi);
			return new float[,]
			{
				{cos,  0, sin },
				{0,    1, 0 },
				{-sin, 0, cos },
			};
		}
		public static float[,] RotZ(float phi)
		{
			float sin = MathF.Sin(phi);
			float cos = MathF.Cos(phi);
			return new float[,]
			{
				{cos, -sin, 0 },
				{sin,  cos, 0 },
				{0,    0,   1 },
			};
		}
		public static float[,] VectorToMatrix(Vector3 a) 
		{
			return new float[,]
			{
				{a.x },
				{a.y },
				{a.z },
			};
		}

		public static Vector3 MatrixToVector(float[,] m1)
		{
			return new Vector3(m1[0, 0], m1[1, 0], m1[2, 0]);
		}

		public static Vector3[] PointsAroundAxis(float[,] m1, Vector3[] points) 
		{
			Vector3[] pointList = new Vector3[points.Length];
			for (int i = 0; i < points.Length; i++) 
			{
				pointList[i] = MatVecMul(m1, points[i]);
			}
			return pointList;
		}

		public static Vector3 MatVecMul(float[,] m1, Vector3 a) 
		{
			float[] result = new float[3];
			int test = m1.GetLength(0);
			for (int i = 0; i < m1.GetLength(0); i++) 
			{
				result[i] += m1[i, 0] * a.x;
				result[i] += m1[i, 1] * a.y;
				result[i] += m1[i, 2] * a.z;
			}

			return new Vector3
				(
					result[0],
					result[1],
					result[2]
				);
		}
	}
}
