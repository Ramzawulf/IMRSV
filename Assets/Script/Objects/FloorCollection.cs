using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMRSV
{

	public class FloorCollection
	{
		public int Count {
			get{ return floors.Count; }
			set{ }
		}

		public List<Floor> Floors {
			get {
				return floors;
			}
			set { }
		}

		private Building building;
		private List<Floor> floors;

		public FloorCollection (Building b)
		{
			floors = new List<Floor> ();
			building = b;

		}



		public void Add (Floor floor)
		{
			if (floors == null)
				floors = new List<Floor> ();
			floor.Building = building;
			floors.Add (floor);
		}
	}
}