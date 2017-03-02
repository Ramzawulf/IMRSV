using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMRSV{

public class BuildingManager : MonoBehaviour {

	private Building myBuilding;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.T)) {
			print ("start query");
			StartCoroutine (HttpManager.instance.QueryForBuildingByName ("Isafjordsgatan ", SetBuilding));
		}
	}

	void SetBuilding (Building b)
	{
		myBuilding = b;
		myBuilding.gameObject.transform.SetParent(gameObject.transform);
		myBuilding.gameObject.name = myBuilding.Name;
	}
}
}