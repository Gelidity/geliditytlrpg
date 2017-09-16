using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandsTravel : MonoBehaviour {
	
	public GameObject Traveler;
	GameObject TravelerClone;
	private Traveler travelScript;

	public void Travel(PlayerScript playerScript, string[] command, MessageRelay messageRelay)
	{
		if (command.Length == 1) {
			messageRelay.Chat (playerScript.channel, playerScript.locationScript.travelDescription);
		}

		if(command.Length == 2) {
			if(command[1] == playerScript.locationScript.destination1Script.travelName) {
				CreateTraveler (playerScript, playerScript.locationObject, playerScript.locationScript, playerScript.locationScript.destination1Object, playerScript.locationScript.destination1Script, playerScript.locationScript.travelTime1, messageRelay);
				return;
			}
			if (playerScript.locationScript.destination2Script != null) {
				if (command [1] == playerScript.locationScript.destination2Script.travelName) {
					CreateTraveler (playerScript, playerScript.locationObject, playerScript.locationScript, playerScript.locationScript.destination2Object, playerScript.locationScript.destination2Script, playerScript.locationScript.travelTime2, messageRelay);
					return;
				}
			}
			if (playerScript.locationScript.destination3Script != null) {
				if (command [1] == playerScript.locationScript.destination3Script.travelName) {
					CreateTraveler (playerScript, playerScript.locationObject, playerScript.locationScript, playerScript.locationScript.destination3Object, playerScript.locationScript.destination3Script, playerScript.locationScript.travelTime3, messageRelay);
					return;
				}
			}
			messageRelay.Chat (playerScript.channel, "You cannot travel there!");
		}
	}

	void CreateTraveler(PlayerScript playerScript, GameObject originCityObject, City originCityScript, GameObject destinationCityObject, City destinationCityScript, float travelTime, MessageRelay messageRelay)
	{
		TravelerClone = Instantiate (Traveler, transform.position, Quaternion.identity) as GameObject;
		TravelerClone.transform.parent = this.transform;

		TravelerClone.transform.position = originCityObject.transform.position;
		travelScript = TravelerClone.GetComponent<Traveler> ();

		travelScript.playerScript = playerScript;

		travelScript.originCityObject = originCityObject;
		travelScript.originCityScript = originCityScript;

		travelScript.destinationCityObject = destinationCityObject;
		travelScript.destinationCityScript = destinationCityScript;

		travelScript.travelTime = travelTime;
		travelScript.messageRelay = messageRelay;

		originCityScript.population--;
		playerScript.isTraveling = true;
		playerScript.traveler = travelScript;
	}
}