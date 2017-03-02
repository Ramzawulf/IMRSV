using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMRSV
{
	public class BuildingManager : MonoBehaviour
	{
		public Building MyBuilding {
			get {
				return myBuilding;
			}
			set {
			}
		}

		public static BuildingManager instance;
		private Building myBuilding;

		void Awake ()
		{
			if (instance == null)
				instance = this;
			else if (instance != this)
				Destroy (gameObject);
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (Input.GetKey (KeyCode.D)) {
			 	myBuilding.Floors.Floors[0].ToggleBluePrint ();
			}
		}

		void SetBuilding (Building b)
		{
			myBuilding = b;
			myBuilding.gameObject.transform.SetParent (gameObject.transform);
			myBuilding.gameObject.name = myBuilding.Name;
		}

		public void QueryForBuildingByName(string name){
			print ("start query");
			StartCoroutine (HttpManager.instance.QueryForBuildingByName ("Isafjordsgatan ", SetBuilding));
		}
	}
}