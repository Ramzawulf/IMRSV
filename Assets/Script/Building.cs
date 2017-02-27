using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Building{
	public int id;
	public string uid;
	public int version;
	public int created;
	public int updated;
	public string name;
	public string popularName;
	public int markerType;
	public GeoLocation geoLocation;
	public string origin;
}

[System.Serializable]
public class GeoLocation{
	public float x;
	public float y;
	public float rotation;

}

[System.Serializable]

public class BuildingList{
	List<Building> buildings;
}

public class JsonResponseExamples{
	public const string Building = @"[{""id"":13,""uid"":""b36c5d75-0927-42e3-92b9-ed5b51981f25"",""version"":14,""created"":1478599222000,""updated"":1485784724000,""name"":""ISAFJORDSGATAN"",""popularName"":null,""markerType"":67,""geoLocation"":{""x"":59.40428739999999,""y"":17.9487753,""rotation"":0.0},""origin"":""SpaceManager""}]";
}

