using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMRSV
{
	public class BluePrint:MonoBehaviour
	{
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
				lr.numPositions = p.Length;
				for(int i = 0; i < p.Length; i++){
					lr.SetPosition (i, p [i]);
				}
				lr.transform.SetParent (gameObject.transform);
				lRenderers.Add (lr);
			}
		}

		private Vector3 GetCenter(){
			Vector3 max = Vector3.zero;
			Vector3 min = Vector3.zero;

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

			return (max - min) * 0.5f;;
		}

	}

}