using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class City : MonoBehaviour {

	public string cityName;
	public string travelName;
	public int population = 0;
	public Text cityText;

	public string travelDescription;
	public string exploreDescription;

	public GameObject destination1Object;
	public GameObject destination2Object;
	public GameObject destination3Object;

	public City destination1Script;
	public City destination2Script;
	public City destination3Script;

	public float travelTime1;
	public float travelTime2;
	public float travelTime3;

	public LineRenderer travelLines;

	public List<string> enemies = new List<string> ();

	private CommandsLoadSave loaderScript;
	private Bestiary bestiaryScript;

	void Awake() {
		var loader = GameObject.Find ("Commander");
		loaderScript = loader.GetComponent<CommandsLoadSave> ();
		AddToList ();
	}
		
		
	void AddToList () {
		loaderScript.cityObjects.Add (this.gameObject);
		loaderScript.cityNames.Add (travelName);
	}

	void Update ()
	{
		cityText.text = cityName + "\nPopulation: " + population.ToString ();
	}
}