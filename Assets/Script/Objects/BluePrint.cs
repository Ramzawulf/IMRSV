using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMRSV
{
	public class BluePrint:MonoBehaviour
	{
		private Vector3 max;
		private Vector3 min;


		public Vector3 centre{
			get{return GetCenter (); }
			set{ }
		}

		private List<LineRenderer> lRenderers;

		public static BluePrint GetBluePrint(List<Vector3[]> polygons){
			GameObject go = Instantiate (PrefabManager.instance.Blueprint);
			go.name = "Blueprint";
			BluePrint bp = go.GetComponent<BluePrint> ();
			bp.Init ();
			bp.Draw (polygons);
			return bp;
		}

		public void Init(){
			lRenderers = new List<LineRenderer> ();
		}

		private void Draw (List<Vector3[]> polygons)
		{
			foreach (var p in polygons) {
				GameObject go = Instantiate (PrefabManager.instance.LineRenderer);
				LineRenderer lr = go.GetComponent<LineRenderer>();
				lr.useWorldSpace = true;
				lr.numPositions = p.Length;
				for(int i = 0; i < p.Length; i++){
					lr.SetPosition (i, p [i]);
				}
				lr.transform.SetParent (gameObject.transform);
				lRenderers.Add (lr);
			}
		}

		private Vector3 GetCenter(){
			max = Vector3.zero;
			min = Vector3.zero;

			foreach (LineRenderer lr in lRenderers) {
				for (int i = 0; i < lr.numPositions; i++) {
					Vector3 pos = lr.GetPosition (i);
					max.x = Mathf.Max (pos.x, max.x);
					max.y = Mathf.Max (pos.y, max.y);
					max.z = Mathf.Max (pos.z, max.z);

					min.x = Mathf.Min (pos.x, min.x);
					min.y = Mathf.Min (pos.y, min.y);
					min.z = Mathf.Min (pos.z, min.z);
				}
			}

			return (max + min) * 0.5f;;
		}

		void OnDrawGizmos(){
			Gizmos.DrawWireSphere (centre, 5f);
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere (max, 5f);
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere (min, 5f);


		}

	}

}