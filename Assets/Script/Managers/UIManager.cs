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
			buildingFound,
			QueryError
		}

		public static UIManager Instance;

		public InputField buildingName;
		public Text Results;
		public State status;
		public Button floorButton;

		void Awake(){
			status = State.idle;
			if (Instance == null)
				Instance = this;
			else if (Instance != this)
				Destroy (gameObject);
			buildingName.text = "Isafjordsgatan";
			floorButton.interactable = false;
		}

		public void LookForBuilding ()
		{
			BuildingManager.instance.QueryForBuildingByName (buildingName.text);
			status = State.searching;
		}

		void Update(){
			if (BuildingManager.instance.MyBuilding != null) {
				status = State.buildingFound;
				Results.text = BuildingManager.instance.MyBuilding.ToString ();
				floorButton.interactable = true;
			} else if (status == State.searching) {
				Results.text = "We are looking for your building.";
			} else if (status == State.idle) {
				Results.text = "Type in a building name.";
			}else if (status == State.QueryError) {
				Results.text = "There was an error with your query, please try again.";
			}
		}

		public void QueryError ()
		{
			status = State.QueryError;
		}

	}
}