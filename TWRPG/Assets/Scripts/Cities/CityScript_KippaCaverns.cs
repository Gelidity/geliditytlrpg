using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityScript_KippaCaverns : City {

	void Start ()
	{
		//destination 1 - Franker Fields
		destination1Script = destination1Object.GetComponent<CityScript_FrankerFields>();
		travelTime1 = 1f;

		//destination 2 -
		destination2Script = destination2Object.GetComponent<CityScript_GrammarGrove>();
		travelTime2 = 0.5f;

		//destination 3 -
		destination3Script = destination3Object.GetComponent<CityScript_TrihardTavern>();
		travelTime3 = 0.5f;

		travelLines.SetPosition (0, destination1Object.transform.position);
		travelLines.SetPosition (1, this.transform.position);
		travelLines.SetPosition (2, destination2Object.transform.position);
		travelLines.SetPosition (3, this.transform.position);
		travelLines.SetPosition (4, destination3Object.transform.position);

		enemies.Add ("kippa");

		travelDescription = "From " + cityName + ", you may travel to " + destination1Script.cityName + ", " + destination2Script.cityName + ", or " + destination3Script.cityName + ".";
		exploreDescription = "The mundanity of the entrance Kippa Caverns does well to conceal what lies within. The rocky hole on the side " +
		"of a small cliff leads to what can only be described as an entirely new world beneath the ground. Even the most experienced " +
		"spelunkers could easily find themselves lost in the labrynth of tunnels for good if they venture too far down. The environmental " +
		"danger, however, is second compared to the vicious beasts known as kippa that call dark tunnels their home.";
	}
}