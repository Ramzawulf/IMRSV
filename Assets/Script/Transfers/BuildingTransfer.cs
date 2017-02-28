using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildingTransfer{
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
public class BuildingTransferCollection{
	
	public BuildingTransfer[] buildings;

	public static BuildingTransferCollection Empty {
		get{ 
			var bc = new BuildingTransferCollection ();
			bc.buildings = new BuildingTransfer[0];
			return bc;
		}
	}
}

