using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityScript_PortPogchamp : City {

	void Start ()
	{
		//destination 1 - Helix Island
		destination1Script = destination1Object.GetComponent<CityScript_HelixIsland>();
		travelTime1 = 0.1f;

		//destination 2 - Castle Kappa
		destination2Script = destination2Object.GetComponent<CityScript_CastleKappa>();
		travelTime2 = 0.1f;

		travelLines.SetPosition (0, destination1Object.transform.position);
		travelLines.SetPosition (1, this.transform.position);
		travelLines.SetPosition (2, destination2Object.transform.position);

		travelDescription = "From " + cityName + ", you may travel to " + destination1Script.cityName + " or " + destination2Script.cityName + ".";
	}
}