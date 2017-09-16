using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityScript_MingMarshes : City {

	void Start ()
	{
		//destination 1 - Trihard Tavern
		destination1Script = destination1Object.GetComponent<CityScript_TrihardTavern>();
		travelTime1 = 1f;

		//destination 2 - PJ Pass
		destination2Script = destination2Object.GetComponent<CityScript_PJPass>();
		travelTime2 = 0.5f;

		travelLines.SetPosition (0, destination1Object.transform.position);
		travelLines.SetPosition (1, this.transform.position);
		travelLines.SetPosition (2, destination2Object.transform.position);

		travelDescription = "From " + cityName + ", you may travel to " + destination1Script.cityName + " or "  + destination2Script.cityName + ".";
	}
}