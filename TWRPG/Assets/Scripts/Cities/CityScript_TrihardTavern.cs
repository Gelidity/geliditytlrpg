using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityScript_TrihardTavern : City {

	void Start ()
	{
		//destination 1 - Kippa Caverns
		destination1Script = destination1Object.GetComponent<CityScript_KippaCaverns>();
		travelTime1 = 0.5f;

		//destination 2 -
		destination2Script = destination2Object.GetComponent<CityScript_MingMarshes>();
		travelTime2 = 0.5f;

		//destination 3 -
		destination3Script = destination3Object.GetComponent<CityScript_BigBrotherBay>();
		travelTime2 = 0.5f;

		travelLines.SetPosition (0, destination1Object.transform.position);
		travelLines.SetPosition (1, this.transform.position);
		travelLines.SetPosition (2, destination2Object.transform.position);
		travelLines.SetPosition (3, this.transform.position);
		travelLines.SetPosition (4, destination3Object.transform.position);

		travelDescription = "From " + cityName + ", you may travel to " + destination1Script.cityName + ", " + destination2Script.cityName + ", or " + destination3Script.cityName + ".";
	}
}