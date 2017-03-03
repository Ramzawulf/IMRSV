using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace IMRSV
{

	public class Building : MonoBehaviour
	{

		#region Properties

		public int numberOfFloors {
			get { 
				if (floors != null)
					return floors.Count;
				return 0;
			}
			set{ }
		}

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
			set { }
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

		public void Awake ()
		{
			floors = new FloorCollection (this);
		}

		public static Building CreateFromTransfer (BuildingTransfer ft)
		{
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

		public void ImportFloor (Floor f)
		{
			floors.Add (f);
		}

		public void ToggleFloorView (int floorNumber)
		{
			if (floorNumber <= floors.Count) {
				floors.Floors [floorNumber].ToggleBluePrint ();
			}
		}

		public override string ToString ()
		{
			StringBuilder result = new StringBuilder ();			
			result.AppendLine(string.Format ("Building: numberOfFloors={0}, Id={1}, Uid={2}, Version={3}, Created={4}", numberOfFloors, Id, Uid, Version, Created));
			result.AppendLine(string.Format ("Updated={0}, Name={1}, PopularName={2}, MarkerType={3}", Updated, Name, PopularName, MarkerType));
			result.AppendLine(string.Format ("GeoLocation={0}, Origin={1}, Floors={2}]", GeoLocation, Origin, Floors));

			int i = 1;
			foreach (var floor in floors.Floors) {
				result.AppendLine (string.Format("Floor {0}: {1} sensors, {2} polygons",i, floor.Sensors.Collection.Count, floor.Polygons.polygons.Count));	
				i++;
			}

			return result.ToString ();

		}
	}
}