using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace IMRSV{

public class Building : MonoBehaviour
{

	#region Properties
	public int Id {
		get {
			return id;
		}
		set {
			
		}
	}

	public string Uid {
		get {
			return uid;
		}
		set {
		}
	}

	public int Version {
		get {
			return version;
		}
		set {
		}
	}

	public int Created {
		get {
			return created;
		}
		set {
		}
	}

	public int Updated {
		get {
			return updated;
		}
		set {
		}
	}

	public string Name {
		get {
			return buildingName;
		}
		set {
		}
	}

	public string PopularName {
		get {
			return popularName;
		}
		set {
		}
	}

	public int MarkerType {
		get {
			return markerType;
		}
		set {
		}
	}

	public GeoLocation GeoLocation {
		get {
			return geoLocation;
		}
		set {
		}
	}

	public string Origin {
		get {
			return origin;
		}
		set {
		}
	}


	public FloorCollection Floors {
		get {
			return floors;
		}
		set {}
	}
	#endregion

	private int id;
	private string uid;
	private int version;
	private int created;
	private int updated;
	private string buildingName;
	private string popularName;
	private int markerType;
	private GeoLocation geoLocation;
	private string origin;
	private FloorCollection floors;

	public void Awake(){
		floors = new FloorCollection (this);
	}

	public static Building CreateFromTransfer(BuildingTransfer ft){
		GameObject go = Instantiate (PrefabManager.instance.BuildingPrefab) as GameObject;
		Building b = go.GetComponent<Building> ();
		b.ImportTransfer (ft);
		return b;
	}

	public void ImportTransfer (BuildingTransfer buildingTransfer)
	{
		id = buildingTransfer.id;
		uid = buildingTransfer.uid;
		version = buildingTransfer.version;
		created = buildingTransfer.created;
		updated = buildingTransfer.updated;
		buildingName = buildingTransfer.name;
		popularName = buildingTransfer.popularName;
		markerType = buildingTransfer.markerType;
		geoLocation = buildingTransfer.geoLocation;
		origin = buildingTransfer.origin;
	}

	public void ImportFloor(FloorTransfer ft){
		 Floor.CreateFromTransfer (ft);
		floors.Add (Floor.CreateFromTransfer(ft));

	}

	public void ImportFloor(Floor f){
		floors.Add (f);
	}
}
}