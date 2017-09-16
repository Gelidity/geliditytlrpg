using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityScript_CastleKappa: City {

	void Start ()
	{
		//destination 1 - Port Pogchamp
		destination1Script = destination1Object.GetComponent<CityScript_PortPogchamp>();
		travelTime1 = 3f;

		//destination 2 - Franker Fields
		destination2Script = destination2Object.GetComponent<CityScript_FrankerFields>();
		travelTime2 = 5f;

		travelLines.SetPosition (0, destination1Object.transform.position);
		travelLines.SetPosition (1, this.transform.position);
		travelLines.SetPosition (2, destination2Object.transform.position);

		travelDescription = "From " + cityName + ", you may travel to " + destination1Script.cityName + " or " + destination2Script.cityName + ".";

		exploreDescription = "The magnificent castle stands tall and proud. Inside lives the good King Ross and his royal family. Just " +
		"outside the castle walls the city bustles with activity. Citizens pour into and out of the city bank and through the shop-" +
		"lined streets. The inns and taverns are always full of people and opportunities to find work.";
	}
}