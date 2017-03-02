using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMRSV{

[System.Serializable]
public class SensorTransfer{

	public string id;
	public string uid;
	public float x;
	public float y;
	public float rotation;
	public float transX;
	public float transY;
	public float scaleX;
	public float scaleY;
	public float flipX;
	public float flipY;
	public string origin;
	public string containerType;
	public int containerId;
	public int typeId;
	public string typeName;
	public string typeGroupName;
	public string typeOrigin;
	public AttributeTransfer[] attributes;
}

[System.Serializable]
public class SensorTransferCollection{
	public SensorTransfer[] sensors;
}

}