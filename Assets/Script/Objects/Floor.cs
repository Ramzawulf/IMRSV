using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMRSV
{

	public class Floor : MonoBehaviour
	{
		#region Properties

		public int Id {
			get {
				return id;
			}
			set { }
		}

		public string Uid {
			get {
				return uid;
			}
			set { }
		}

		public int Version {
			get {
				return version;
			}
			set { }
		}

		public int Created {
			get {
				return created;
			}
			set { }
		}

		public int Updated {
			get {
				return updated;
			}
			set { }
		}

		public string Name {
			get {
				return floorName;
			}
			set { }
		}

		public string Popularname {
			get {
				return popularname;
			}
			set { }
		}

		public float Height {
			get {
				return height;
			}
			set { }
		}

		public float ReferenceHeight {
			get {
				return referenceHeight;
			}
			set { }
		}


		public SensorCollection Sensors {
			get {
				return sensors;
			}
			set {
			}
		}

		public Building Building {
			get {
				return building;
			}
			set {
				building = value;
				gameObject.transform.SetParent (value.transform);
				transform.position = Vector3.zero;
			}
		}

		public PolygonCollection Polygons {
			get {
				return polygons;
			}
			set {}
		}

		public BluePrint BluePrint {
			get {
				return bluePrint;
			}
			set {}
		}

	
		#endregion

		private int id;
		private string uid;
		private int version;
		private int created;
		private int updated;
		private string floorName;
		private string popularname;
		private float height;
		private float referenceHeight;
		private SensorCollection sensors;
		private PolygonCollection polygons;
		private Building building;
		private Transform sensorContainer;
		private Transform polygonContainer;
		private BluePrint bluePrint;

		public void Awake ()
		{
			sensorContainer = new GameObject("Sensor COntainer").transform;
			sensorContainer.SetParent (gameObject.transform);
			polygonContainer = new GameObject("Polygon COntainer").transform;
			polygonContainer.SetParent (gameObject.transform);
			sensors = new SensorCollection (sensorContainer);
			polygons = new PolygonCollection (polygonContainer);
		}

		public static Floor CreateFromTransfer (FloorTransfer ft)
		{
			GameObject go = Instantiate (PrefabManager.instance.FloorPrefab) as GameObject;
			Floor f = go.GetComponent<Floor> ();
			f.ImportTransfer (ft);
			return f;
		}

		public void ImportTransfer (FloorTransfer ft)
		{
			id = ft.id;
			uid = ft.uid;
			version = ft.version;
			created = ft.created;
			updated = ft.updated;
			floorName = ft.name; 
			popularname = ft.popularname;
			height = ft.height;
			referenceHeight = ft.referenceHeight;
		}

		public void ImportSensors (SensorTransferCollection stc)
		{
			sensors.ImportSensors (stc);
		}

		public void ImportPolygons (PolygonQueryTransfer tempPQT)
		{
			polygons.ImportPolygon (tempPQT);
			InitBlueprint ();
		}

		private void InitBlueprint ()
		{
			List<Vector3[]> points = polygons.GetPolygonPoints ();
			bluePrint =  BluePrint.GetBluePrint(points);
			bluePrint.transform.SetParent (gameObject.transform);
			bluePrint.gameObject.SetActive (false);
		}

		public void ToggleBluePrint ()
		{
			bluePrint.gameObject.SetActive (!bluePrint.gameObject.activeSelf);
			if (bluePrint.gameObject.activeSelf) {
				Vector3 cameraPosition = bluePrint.centre + new Vector3 (0, 0, -85);
				CameraBehaviour.Instance.transform.position = cameraPosition;
				//CameraBehaviour.Instance.LookAt (bluePrint.centre);
			}
		}
	}
}