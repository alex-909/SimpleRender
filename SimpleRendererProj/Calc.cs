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
	}
}
