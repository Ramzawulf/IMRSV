using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMRSV{

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

	public IEnumerator QueryForBuildingByName (string buildingName, System.Action<Building> callBack)
	{
		//Get Buildings
		BuildingTransferCollection buildingCollection = null;

		yield return StartCoroutine (GetBuildingsByStreetName (buildingName, (BuildingTransferCollection b) => {
			buildingCollection = b;
		}));
		Building buildingGo = null;
		if (buildingCollection.buildings.Length > 0) {
			buildingGo = Building.CreateFromTransfer (buildingCollection.buildings [0]);
		
			//Get Floors for every building
			foreach (BuildingTransfer building in buildingCollection.buildings) {
				FloorTransferCollection tempftc = null;
				yield return StartCoroutine (GetFloorsByBuildingId (building.id, (FloorTransferCollection ftc) => {
					tempftc = ftc;
				}));

				foreach (FloorTransfer floor in tempftc.floors) {
					//Get sensors per floor
					SensorTransferCollection tempSTC = null;
					yield return StartCoroutine (GetSensorByFloorId (floor.id, (SensorTransferCollection stc) => {
						tempSTC = stc;
					}));
					PolygonQueryTransfer tempPQT = null;
					yield return StartCoroutine(GetPolygonByFloorId(floor.id, (PolygonQueryTransfer pqt) => {
						tempPQT = pqt;
					}));
					//Merge the floor,sensor and polygon transfer object into the Building obj.
					Floor tempFloor = Floor.CreateFromTransfer (floor);
					tempFloor.ImportSensors (tempSTC);
					tempFloor.ImportPolygons (tempPQT);
					buildingGo.ImportFloor (tempFloor);



						
				}
			}
		}
		callBack (buildingGo);
	}

	public IEnumerator GetPolygonByFloorId(int floorId, System.Action<PolygonQueryTransfer> callBack){
		string url = string.Format (APIUrls.POLYGONS_BY_FLOOR_ID, floorId.ToString ());

		WWW www = new WWW (url, null, headers);
		yield return www;

		if (string.IsNullOrEmpty (www.error)) {
			string response = RequestUtils.ArrayFormatter (ArrayFormatterType.polygons, www.text);

			PolygonQueryTransfer sc = JsonUtility.FromJson<PolygonQueryTransfer> (response);
			callBack (sc);
		}
	}
}
}