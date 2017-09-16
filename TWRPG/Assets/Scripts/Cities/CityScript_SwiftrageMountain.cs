using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityScript_SwiftrageMountain : City {

	void Start ()
	{
		//destination 1 - PJ Pass
		destination1Script = destination1Object.GetComponent<CityScript_PJPass>();
		travelTime1 = 2f;

		//destination 2 - KappaDale
		//destination2Script = destination2Object.GetComponent<CityScript_CastleKappa>();
		//travelTime2 = 5f;


		travelLines.SetPosition (0, destination1Object.transform.position);
		travelLines.SetPosition (1, this.transform.position);
		//travelLines.SetPosition (2, destination2Object.transform.position);

		travelDescription = "From " + cityName + ", you may travel to " + destination1Script.cityName + ".";
	}
}
