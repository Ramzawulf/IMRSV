using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMRSV{

public class PrefabManager : MonoBehaviour {

	public static PrefabManager instance;

	public GameObject FloorPrefab;
	public GameObject BuildingPrefab;
	public GameObject SensorPrefab;
	public GameObject PolygonPrefab;

	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
}