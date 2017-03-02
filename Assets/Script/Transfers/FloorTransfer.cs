using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMRSV{

[System.Serializable]
public class FloorTransfer{
	public int id;
	public string uid;
	public int version;
	public int created;
	public int updated;
	public string name; //#Q: Is this a key candidate?
	public string popularname;
	public float height;
	public float referenceHeight;
}

[System.Serializable]
public class FloorTransferCollection{
	public FloorTransfer[] floors;
	}}