using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleRendererProj
{
	class Cube
	{
		Vector3 origin;
		Vector3 g1;
		Vector3 g2;
		Vector3 g3;

		float ppU;

		public Cube(Vector3 origin, Vector3 g1, Vector3 g2, Vector3 g3, float ppU) 
		{
			this.origin = origin;
			this.g1 = g1;
			this.g2 = g2;
			this.g3 = g3;
			this.ppU = ppU;
		}
		public Line[] GetAllLines() 
		{
			List<Line> lines = new List<Line>();
			//12 in total
			lines.Add(new Line(origin, g1, ppU));
			lines.Add(new Line(origin + g1, g2, ppU));
			lines.Add(new Line(origin, g1, ppU));

			return lines.ToArray();
		}
	}
}
