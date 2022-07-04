using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleRendererProj
{
	class World
	{
		private List<Vector3> points;
		public World() 
		{
			points = new List<Vector3>();
		}
		public Vector3[] GetAllPoints() 
		{
			return points.ToArray();
		}
		public void AddPoint(Vector3 point) 
		{
			points.Add(point);
		}
		public void AddPoint(Vector3[] point) 
		{
			points.AddRange(point);
		}
		public void AddLines(Line[] lines) 
		{
			foreach (Line line in lines) 
			{
				this.AddPoint(line.PointsOnLine());
			}
		}
		public void Clear() 
		{
			points.Clear();
		}
	}
}
