using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandsMisc : MonoBehaviour {

	private PlayerScript inspectScript;

	public void Status (PlayerScript playerScript, MessageRelay messageRelay) {
		
		string s = "You are ";

		if (playerScript.isTraveling) {
			s += "currently traveling from " + playerScript.traveler.originCityScript.cityName + " to "	+ playerScript.traveler.destinationCityScript.cityName + ". ";
		} else {
			s += "currently at " + playerScript.locationScript.cityName + ". ";
		}

		s += " You are level " + playerScript.level.ToString() + " with (" + playerScript.xpCur.ToString() + "/" + playerScript.xpMax.ToString() + ") XP";
		s += " Your HP is (" + playerScript.hpCur.ToString() + "/" + playerScript.hpMax.ToString() + ")";
		s += " Your MP is (" + playerScript.mpCur.ToString() + "/" + playerScript.mpMax.ToString() + ")";

		messageRelay.Chat (playerScript.channel, s);
	}

	public void Inspect (PlayerScript playerScript, string[] command, MessageRelay messageRelay) {

		var listVal = messageRelay.joinedChannels.IndexOf (command[1]);

		if (listVal == -1) {
			messageRelay.Chat (playerScript.channel, "That player either does not exist or is not logged in.");
		} else {
			inspectScript = messageRelay.playerScripts [listVal];
			messageRelay.Chat(playerScript.channel,
				inspectScript.playerName + " is a level " + inspectScript.level.ToString() + " " + inspectScript.playerRace + " " + inspectScript.playerClass + ". They are equipped with " +
				inspectScript.gearHat.name + ", " + inspectScript.gearBod.name + ", " + inspectScript.gearWep.name + ", and " + inspectScript.gearAcc.name + 
				". They are currently located in " + inspectScript.locationScript.cityName + ".");
		}
	}
}