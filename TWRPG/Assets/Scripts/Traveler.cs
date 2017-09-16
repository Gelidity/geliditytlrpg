using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traveler : MonoBehaviour {

	public PlayerScript playerScript;
	public MessageRelay messageRelay;

	public GameObject originCityObject;
	public City originCityScript;

	public GameObject destinationCityObject;
	public City destinationCityScript;

	public float speed;
	public float travelTime;

	void Start ()
	{
		speed = Time.deltaTime/travelTime;
	}

	void Update ()
	{
		transform.position = Vector3.MoveTowards(transform.position, destinationCityObject.transform.position, speed);

		if (this.transform.position == destinationCityObject.transform.position)
		{
			playerScript.locationObject = destinationCityObject;
			playerScript.locationScript = destinationCityScript;
			playerScript.location = playerScript.locationScript.travelName;
			playerScript.locationScript.population++;
			playerScript.isTraveling = false;
			playerScript.traveler = null;
			messageRelay.Chat (playerScript.channel, "You have arrived at " + playerScript.locationScript.cityName + ".");
			Destroy (this.gameObject, 0f);
		}
	}
}