using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class RequestUtils{

	public static string ArrayFormatter( ArrayFormatterType type,  string jsonString){
		string formattedString = jsonString;
		StringBuilder sb = new StringBuilder ();

		if (jsonString [0] == '[') {
			sb.Append ("{\"" + type.ToString () + "\":");
			sb.Append (jsonString);
			sb.Append ("}");
			formattedString = sb.ToString ();
		}
		return formattedString;
	}

	public static string PrepareBuildingName(string buildingName){
		buildingName = buildingName.Replace(" ", string.Empty);
		buildingName = buildingName.ToUpper ();
		return buildingName;
	}
}



public enum ArrayFormatterType{
	buildings,
	sensors, 
	floors
}
