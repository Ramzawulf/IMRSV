using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMRSV{
public class APIUrls{

	public const string BUILDING_BY_NAME = "https://pim.pythagoras.se/py_datamanager_conference/rest/v1/building/name/{0}";
	public const string SENSOR_BY_FLOOR_ID = "https://pim.pythagoras.se/py_datamanager_conference/rest/v1/floor/{0}/workspace/component/info?pN%5B%5D=EQ%3AtypeName&pV%5B%5D=LiveSensor";
	public const string FLOOR_BY_BUILDING_ID = "https://pim.pythagoras.se/py_datamanager_conference/rest/v1/building/{0}/floor";
	public const string POLYGONS_BY_FLOOR_ID = "https://pim.pythagoras.se/py_datamanager_conference/rest/v1/floor/{0}/workspace/info?includePolygon=true";

}
}