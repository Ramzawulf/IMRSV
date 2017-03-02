using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMRSV{

	public class PolygonCollection
{
		private Transform container;
		public List<Polygon> polygons;

		public PolygonCollection (Transform c)
		{
			container = c;
			polygons = new List<Polygon>();

		}



		public void ImportPolygon (PolygonQueryTransfer pqt)
		{
			if(polygons == null)
				polygons = new List<Polygon>();

			foreach (PolygonTransferCollection st in pqt.polygons) {
				Polygon p = Polygon.CreateFromTransfer (st.polygon);
				p.transform.SetParent (container);
				p.gameObject.name = st.polygon.id.ToString();
				polygons.Add (p);
			}

		}
}

}