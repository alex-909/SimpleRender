using System;
using System.Collections.Generic;
using System.Text;

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
