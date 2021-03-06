﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMRSV
{

	public class Polygon : MonoBehaviour
	{
		public List<Vector3> vertex;
		public int id;
		private LineRenderer lRendereer;

		void Awake ()
		{
			vertex = new List<Vector3> ();

		}

		public static Polygon CreateFromTransfer (PolygonTransfer pt)
		{
			GameObject go = Instantiate (PrefabManager.instance.PolygonPrefab) as GameObject;
			Polygon p = go.GetComponent<Polygon> ();
			p.ImportTransfer (pt);
			return p;
		}

		public void ImportTransfer(PolygonTransfer pt){
			id = pt.id;
			foreach (var c in pt.coords) {
				vertex.Add(new Vector3(c.x, c.y, c.z));
			}
		}

		public void Draw(){
			/*
			lRendereer = gameObject.AddComponent<LineRenderer> ();
			lRendereer.numPositions = vertex.Count;
			for(int i = 0; i < vertex.Count; id++){
				GameObject	go = Instantiate (PrefabManager.instance.Temp);
				go.transform.position = vertex [i];
			}
			*/
		}
	}
}