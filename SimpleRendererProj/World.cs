using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleRendererProj
{
	class World
	{
		private List<(Vector3, float)> points;
		public World() 
		{
			points = new List<(Vector3, float)>();
		}
		public (Vector3, float)[] GetAllPoints() 
		{
			return points.ToArray();
		}
		public void AddPoint((Vector3, float) point) 
		{
			points.Add(point);
		}
		public void AddPoint((Vector3, float)[] point) 
		{
			points.AddRange(point);
		}
		public void AddLines(Line[] lines) 
		{
			foreach (Line line in lines) 
			{
				foreach (Vector3 point in line.PointsOnLine()) 
				{
					this.AddPoint((point, 1));
				}
			}
		}
		public void AddFaces(Face[] faces, Vector3 lightSource) 
		{
			foreach (Face face in faces) 
			{
				face.CalculateLighting(lightSource);
				this.AddPoint(face.PointsOnFace());
			}
		}
		public void Clear() 
		{
			points.Clear();
		}
	}
}
