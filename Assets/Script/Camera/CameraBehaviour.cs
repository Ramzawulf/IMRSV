using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

	public static CameraBehaviour Instance {
		get {
			return instance;
		}
		set {}
	}

	private static CameraBehaviour instance;

	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
	}

	public void LookAt(Transform target){
		transform.LookAt (target);
	}
}
