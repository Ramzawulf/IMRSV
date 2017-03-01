using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HttpManager : MonoBehaviour
{
	
	private static HttpManager _instance;

	public static HttpManager instance{ get { return _instance; } }

	public string apiKeyId = "api_key";
	public string apiKeyValue = "BMOOROR499fMA4NOSBMZ30189884MXO3MG4";
	protected Dictionary<string, string> headers;

	public void Awake ()
	{

		#region Singleton Initialization
		if (_instance == null)
			_instance = this;
		else if (_instance != this)
			Destroy (gameObject);
		#endregion

		headers = new Dictionary<string, string> ();
		headers.Add (apiKeyId, apiKeyValue);

	}

	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.T)) {
			print ("start query");
			StartCoroutine (QueryForBuildingByName ("Isafjordsgatan "));
		}
			

	}

	private IEnumerator GetBuildingsByStreetName (string streetName, System.Action<BuildingTransferCollection> callBack)
	{
		string url = string.Format (APIUrls.BUILDING_BY_NAME, RequestUtils.PrepareBuildingName (streetName));
		WWW www = new WWW (url, null, headers);
		yield return www;
		BuildingTransferCollection result = null;
		if (string.IsNullOrEmpty (www.error)) {
			string response = www.text;
			result = JsonUtility.FromJson<BuildingTransferCollection> (RequestUtils.ArrayFormatter (ArrayFormatterType.buildings, response));
		}
		callBack (result);
	}

	private IEnumerator GetFloorsByBuildingId (int buildingId, System.Action<FloorTransferCollection> callBack)
	{
		string url = string.Format (APIUrls.FLOOR_BY_BUILDING_ID, buildingId);
		WWW www = new WWW (url, null, headers);
		yield return www;
		FloorTransferCollection result = null;
		if (string.IsNullOrEmpty (www.error)) {
			string response = www.text;
			result = JsonUtility.FromJson<FloorTransferCollection> (RequestUtils.ArrayFormatter(ArrayFormatterType.floors, response));
		}
		callBack (result);
	}

	private IEnumerator GetSensorByFloorId (int floorId, System.Action<SensorTransferCollection> callBack)
	{
		string url = string.Format (APIUrls.SENSOR_BY_FLOOR_ID, floorId.ToString ());

		WWW www = new WWW (url, null, headers);
		yield return www;

		if (string.IsNullOrEmpty (www.error)) {
			string response = www.text;
			SensorTransferCollection sc = JsonUtility.FromJson<SensorTransferCollection> (
				                              RequestUtils.ArrayFormatter (ArrayFormatterType.sensors, response));
			callBack (sc);
		}
	}

	private IEnumerator QueryForBuildingByName (string buildingName)
	{//, System.Action<string> callBack){
		//Get Buildings
		BuildingTransferCollection buildingCollection = null;
		yield return StartCoroutine (GetBuildingsByStreetName (buildingName, (BuildingTransferCollection b) => {
			buildingCollection = b;
		}));
		//Get Floors for every building
		foreach (BuildingTransfer building in buildingCollection.buildings) {
			FloorTransferCollection tempftc = null;
			yield return StartCoroutine(GetFloorsByBuildingId(building.id, (FloorTransferCollection ftc) => {
				tempftc = ftc;
			}));
			print ("Floors: " + tempftc.floors.Length);

			foreach (FloorTransfer floor in tempftc.floors) {
				//Get sensors per floor
				SensorTransferCollection tempSTC = null;
				yield return StartCoroutine (GetSensorByFloorId(floor.id, (SensorTransferCollection stc) => {
					tempSTC = stc;
				}));
				print ( tempSTC.sensors.Length + " sensors for floors : " + floor.name);
				// #ToDo: merge into building object
			}




		}

		print ("Buildings: " + buildingCollection.buildings.Length);
	}
}
