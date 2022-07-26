using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleRendererProj
{
	enum Plane
	{
		XY_Plane,
		XZ_Plane,
		YZ_Plane,
		noPlane
	}
	static class Calc
	{
		public static Vector3[] CalcOffset(Vector3[] points, Vector3 offset) 
		{
			for(int i = 0; i < points.Length; i++) 
			{
				points[i] = points[i] + offset;
			}
			return points;
		}
		public static (float sinRot, float cosRot) RotSinCos(float a, float phi, float phi_offset, float d1, float d2) 
		{
			float rot1 = a * MathF.Sin(phi + phi_offset) + d1;
			float rot2 = a * MathF.Cos(phi + phi_offset) + d2;
			return (rot1, rot2);
		}

		public static float GetAmplitude(Vector3 v1, Vector3 v2, Plane plane) 
		{
			switch (plane) 
			{
				case Plane.noPlane:
					break;
				case Plane.XY_Plane:
					v1 = new Vector3(v1.x, v1.y, 0);
					v2 = new Vector3(v2.x, v2.y, 0);
					break;
				case Plane.XZ_Plane:
					v1 = new Vector3(v1.x, 0, v1.z);
					v2 = new Vector3(v2.x, 0, v2.z);
					break;
				case Plane.YZ_Plane:
					v1 = new Vector3(0, v1.y, v1.z);
					v2 = new Vector3(0, v2.y, v2.z);
					break;
				default:
					break;
			}
			return (v1 - v2).Length();
		}
		public static float GetPhase(Vector3 v1, Vector3 v2, Plane plane) 
		{
			bool oppositeAngle = false;
			Vector3 axisVector = new Vector3(0,0,0);
			switch (plane)
			{
				case Plane.noPlane:
					break;
				case Plane.XY_Plane:
					v1 = new Vector3(v1.x, v1.y, 0);
					v2 = new Vector3(v2.x, v2.y, 0);
					axisVector = new Vector3(1, 0, 0);
					if (v2.y > v1.y) { oppositeAngle = true; }
					break;
				case Plane.XZ_Plane:
					v1 = new Vector3(v1.x, 0, v1.z);
					v2 = new Vector3(v2.x, 0, v2.z);
					axisVector = new Vector3(1, 0, 0);
					if (v2.z > v1.z) { oppositeAngle = true; }
					break;
				case Plane.YZ_Plane:
					v1 = new Vector3(0, v1.y, v1.z);
					v2 = new Vector3(0, v2.y, v2.z);
					axisVector = new Vector3(0, 0, 1);
					if (v2.y > v1.y) { oppositeAngle = true; }
					break;
				default:
					break;
			}
			Vector3 phaseVector = v1 - v2;
			double dotProduct = (phaseVector.x * axisVector.x) + (phaseVector.y * axisVector.y) + (phaseVector.z * axisVector.z);
			double lengthProduct = phaseVector.Length() * axisVector.Length();
			float phi = (float)Math.Acos(dotProduct / lengthProduct);

			if (oppositeAngle) 
			{
				return (2 * MathF.PI) - phi;
			}
			return phi;
		}
		public static Vector3[] RotatePointsAroundAxis(Vector3[] points, Vector3 midpoint, Plane plane, float omegaT, float d1, float d2) 
		{
			List<Vector3> rotatedPoints = new List<Vector3>();
			foreach (Vector3 p in points) 
			{
				Vector3 point = p;
				float amplitude = GetAmplitude(point, midpoint, plane);
				float phase = GetPhase(point, midpoint, plane);
				(point.y, point.z) = RotSinCos(amplitude, omegaT, phase, d1, d2);

				rotatedPoints.Add(point);
			}

			return rotatedPoints.ToArray();
		}
	}
}
