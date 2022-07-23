using System;

namespace SimpleRendererProj
{
	struct Vector3
	{
		public float x;
		public float y;
		public float z;

		public Vector3(float x, float y, float z) 
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public static Vector3 operator +(Vector3 a, Vector3 b) 
		{
			return new Vector3(
				a.x + b.x, 
				a.y + b.y, 
				a.z + b.z);
		}
		public static Vector3 operator -(Vector3 a, Vector3 b)
		{
			return new Vector3(
				a.x - b.x,
				a.y - b.y,
				a.z - b.z);
		}

		public static Vector3 operator *(Vector3 a, float f)
		{
			return new Vector3(
				a.x * f,
				a.y * f,
				a.z * f);
		}

		public static Vector3 operator /(Vector3 a, float f)
		{
			return new Vector3(
				a.x / f,
				a.y / f,
				a.z / f);
		}

		public static float DotProduct(Vector3 a, Vector3 b) 
		{
			return (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
		}
		public static Vector3 CrossProduct(Vector3 a, Vector3 b) 
		{
			float c1 = (a.y * b.z) - (a.z * b.y);
			float c2 = (a.z * b.x) - (a.x * b.z);
			float c3 = (a.x * b.y) - (a.y * b.x);
			return new Vector3(c1, c2, c3);
		}
		public float Length() 
		{
			float squared = (x * x) + (y * y) + (z * z);
			return MathF.Sqrt(squared);
		}

		public Vector3 Normalized() 
		{
			float length = this.Length();
			return new Vector3(x/length, y/length, z/length);
		}
	}
}
