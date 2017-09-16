using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityScript_VohiyoVillage : City {

	void Start ()
	{
		//destination 1
		destination1Script = destination1Object.GetComponent<CityScript_GrammarGrove>();
		travelTime1 = 2f;

		//destination 2 - Swiftrage Mountain
		//destination2Script = destination2Object.GetComponent<CityScript_SwiftrageMountain>();
		//travelTime2 = 3f;

		travelLines.SetPosition (0, destination1Object.transform.position);
		travelLines.SetPosition (1, this.transform.position);
		//travelLines.SetPosition (2, destination2Object.transform.position);

		travelDescription = "From " + cityName + ", you may travel to " + destination1Script.cityName + ".";
	}
}
