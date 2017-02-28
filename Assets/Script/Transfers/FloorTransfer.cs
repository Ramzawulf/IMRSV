using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FloorTransfer{
	public string id;
	public string uid;
	public int version;
	public int created;
	public int updated;
	public string name;
	public string popularname;
	public float height;
	public float referenceHeight;
}

[System.Serializable]
public class FloorTransferCollection{
	public FloorTransfer[] floors;
}