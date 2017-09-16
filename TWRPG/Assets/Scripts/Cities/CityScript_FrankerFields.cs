using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityScript_FrankerFields : City {

	void Start ()
	{
		//destination 1 - Castle Kappa
		destination1Script = destination1Object.GetComponent<CityScript_CastleKappa>();
		travelTime1 = 1f;

		//destination 2 - Kippa Caverns
		destination2Script = destination2Object.GetComponent<CityScript_KippaCaverns>();
		travelTime2 = 0.5f;

		travelLines.SetPosition (0, destination1Object.transform.position);
		travelLines.SetPosition (1, this.transform.position);
		travelLines.SetPosition (2, destination2Object.transform.position);

		travelDescription = "From " + cityName + ", you may travel to " + destination1Script.cityName + " or "  + destination2Script.cityName + ".";
		exploreDescription = "The vast grasslands of Franker Fields cover most of KappaDale's eastern territory. Many types of common plants " +
		"can be found along with scattered farms that grow simple crops to feed the citizens. Trees are present but sparse.";
	}
}