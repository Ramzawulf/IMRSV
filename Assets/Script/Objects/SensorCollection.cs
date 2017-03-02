using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMRSV{

public class SensorCollection
{
	public List<Sensor> Collection {
		get {
			return collection;
		}
		set {
		}
	}

	private List<Sensor> collection;
	private Floor floor;

	public SensorCollection(Floor f){
		floor = f;
	}

	public void ImportSensors (SensorTransferCollection stc)
	{
		collection = new List<Sensor>();

		foreach (var st in stc.sensors) {
			Sensor s = Sensor.CreateFromTransfer (st);
			s.transform.SetParent (floor.transform);
			s.gameObject.name = s.TypeName +"-"+ s.Id;
			collection.Add (s);
		}

	}
}

}