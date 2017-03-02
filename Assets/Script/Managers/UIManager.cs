using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IMRSV
{

	public class UIManager : MonoBehaviour
	{
		public enum State
		{
			idle, 
			searching, 
			buildingFound
		}

		public InputField buildingName;
		public Text Results;
		public State status;

		void Awake(){
			status = State.idle;
		}

		public void LookForBuilding ()
		{
			BuildingManager.instance.QueryForBuildingByName (buildingName.text);
			status = State.searching;
		}

		void Update(){
			if (BuildingManager.instance.MyBuilding != null) {
				status = State.buildingFound;
				StringBuilder sb = new StringBuilder ();

			} else if (status == State.searching) {
				Results.text = "We are looking for your building.";
			} else if (status == State.idle) {
				Results.text = "Type in a building name.";
			}
		}


	}
}