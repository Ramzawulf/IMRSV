using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMRSV{

public class FloorCollection{

	private Building building;

	public FloorCollection (Building b)
	{
		floors = new List<Floor> ();
		building = b;

	}

	private List<Floor> floors;

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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