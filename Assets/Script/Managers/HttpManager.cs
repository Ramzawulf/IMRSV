using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HttpManager : MonoBehaviour {
	
	private static HttpManager _instance;
	public static HttpManager instance{get { return _instance;} }

	public string apiKeyId = "api_key";
	public string apiKeyValue = "BMOOROR499fMA4NOSBMZ30189884MXO3MG4";
	protected Dictionary<string, string> headers;

	public void Awake(){

		#region Singleton Initialization
		if (_instance == null)
			_instance = this;
		else if (_instance != this)
			Destroy (gameObject);
		#endregion

		headers = new Dictionary<string, string> ();
		headers.Add (apiKeyId, apiKeyValue);

	}

	void Update(){

		if (Input.GetKeyDown (KeyCode.T)) {
			print ("start query");
			StartCoroutine (QueryForBuildingByName ("Isafjordsgatan "));
		}
			

	}

	private IEnumerator GetBuildingsByStreetName(string streetName, System.Action<BuildingTransferCollection> callBack){
		string url = string.Format (APIUrls.BUILDING_BY_NAME, RequestUtils.PrepareBuildingName(streetName));
		BuildingTransferCollection result =  null;
		WWW www = new WWW (url, null, headers);
		yield return www;
		if (string.IsNullOrEmpty (www.error)) {
			string response = www.text;
			result = JsonUtility.FromJson<BuildingTransferCollection>(RequestUtils.ArrayFormatter(ArrayFormatterType.buildings,response));
		}
		callBack (result);
	}

	private IEnumerator GetFloorsByBuildingId(int buildingId, System.Action<FloorTransferCollection> callBack){
		yield return null;
	}

	private IEnumerator GetSensorByBuildingId(int buildingId){
		string url = string.Format (APIUrls.SENSOR_BY_FLOOR_ID, buildingId.ToString());

		WWW www = new WWW(url, null, headers);
		yield return www;

		if(string.IsNullOrEmpty(www.error)){
			string respone = www.text;
			SensorCollectionTransfer sc = JsonUtility.FromJson<SensorCollectionTransfer>(
				RequestUtils.ArrayFormatter(ArrayFormatterType.sensors, respone));
			print ("Sensors collection: "+sc.sensors.Length);
		}
	}

	private IEnumerator QueryForBuildingByName(string buildingName){//, System.Action<string> callBack){
		//Get Buildings
		BuildingTransferCollection buildingCollection = null;
		yield return StartCoroutine (GetBuildingsByStreetName (buildingName, (BuildingTransferCollection b) => {
			buildingCollection = b;
		}));
		//Get Floors for every building
		foreach (BuildingTransfer building in buildingCollection.buildings) {
			
		}

		print(buildingCollection.buildings.Length);
	}
}
