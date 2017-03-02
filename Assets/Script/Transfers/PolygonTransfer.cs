using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMRSV{

[System.Serializable]
public class PolygonQueryTransfer{
	public PolygonTransferCollection[] polygons;
}

[System.Serializable]
public class PolygonTransferCollection{
	public int id;
	public PolygonTransfer polygon;
}

[System.Serializable]
public class PolygonTransfer {
	public int id;
	public string fillFgColor;
	public coordinates[] coords;
}
}