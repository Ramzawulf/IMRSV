using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMRSV
{

	public class Sensor : MonoBehaviour
	{

		#region Properties

		public string Id {
			get {
				return id;
			}
			set { }
		}

		public string Uid {
			get {
				return uid;
			}
			set { }
		}

		public float X {
			get {
				return x;
			}
			set {
			}
		}

		public float Y {
			get {
				return y;
			}
			set {
			}
		}

		public float Rotation {
			get {
				return rotation;
			}
			set {
			}
		}

		public float TransX {
			get {
				return transX;
			}
			set {
			}
		}

		public float TransY {
			get {
				return transY;
			}
			set {
			}
		}

		public float ScaleX {
			get {
				return scaleX;
			}
			set {
			}
		}

		public float ScaleY {
			get {
				return scaleY;
			}
			set {
			}
		}

		public float FlipX {
			get {
				return flipX;
			}
			set {
			}
		}

		public float FlipY {
			get {
				return flipY;
			}
			set {
			}
		}

		public string Origin {
			get {
				return origin;
			}
			set {
			}
		}

		public string ContainerType {
			get {
				return containerType;
			}
			set {
			}
		}

		public int ContainerId {
			get {
				return containerId;
			}
			set {
			}
		}

		public int TypeId {
			get {
				return typeId;
			}
			set {
			}
		}

		public string TypeName {
			get {
				return typeName;
			}
			set {
			}
		}

		public string TypeGroupName {
			get {
				return typeGroupName;
			}
			set {
			}
		}

		public string TypeOrigin {
			get {
				return typeOrigin;
			}
			set {
			}
		}

		public AttributeTransfer[] Attributes {
			get {
				return attributes;
			}
			set {
				attributes = value;
			}
		}

		#endregion

		private string id;
		private string uid;
		private float x;
		private float y;
		private float rotation;
		private float transX;
		private float transY;
		private float scaleX;
		private float scaleY;
		private float flipX;
		private float flipY;
		private string origin;
		private string containerType;
		private int containerId;
		private int typeId;
		private string typeName;
		private string typeGroupName;
		private string typeOrigin;
		private AttributeTransfer[] attributes;


		void Start ()
		{
		
		}

		void ImportTransfer (SensorTransfer st)
		{
			id = st.id;
			uid = st.uid;
			x = st.x;
			y = st.y;
			rotation = st.rotation;
			transX = st.transX;
			transY = st.transY;
			scaleX = st.scaleX;
			scaleY = st.scaleY;
			flipX = st.flipX;
			flipY = st.flipY;
			origin = st.origin;
			containerType = st.containerType;
			containerId = st.containerId;
			typeId = st.typeId;
			typeName = st.typeName;
			typeGroupName = st.typeGroupName;
			typeOrigin = st.typeOrigin;
			attributes = st.attributes;

		}

		public static Sensor CreateFromTransfer (SensorTransfer st)
		{
			GameObject go = Instantiate (PrefabManager.instance.SensorPrefab) as GameObject;
			Sensor s = go.GetComponent<Sensor> ();
			s.ImportTransfer (st);
			return s;
		}
	}
}