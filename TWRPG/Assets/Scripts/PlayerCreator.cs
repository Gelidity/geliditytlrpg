using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TwitchChatter;

public class PlayerCreator : MonoBehaviour {

	public GameObject MessageRelay;
	public MessageRelay messageRelay;

	public GameObject playerObject;
	GameObject newPlayerObject;

	public GameObject playerParent;

	private PlayerScript newPlayerScript;

	public void Start()
	{
		messageRelay = MessageRelay.GetComponent<MessageRelay> ();
	}

	public void CreatePlayer(string userName)
	{
		newPlayerObject = Instantiate (playerObject);
		newPlayerObject.transform.parent = playerParent.transform;
		newPlayerObject.name = "Player_" + userName;

		newPlayerScript = newPlayerObject.GetComponent<PlayerScript> ();
		newPlayerScript.channel = userName.ToLower ();

		newPlayerScript.playerName = userName;

		if (System.IO.File.Exists(@"X:\TLRPGdata\PlayerProfiles\" + newPlayerScript.playerName + ".txt")) {
			messageRelay.Whisper (userName, "HeyGuys Welcome back, " + userName + "! You are now logged in and ready to play. Head on over to your channel!");
			messageRelay.commandsLoadSave.Load (newPlayerScript, messageRelay);
		}
		else {
			messageRelay.Whisper (userName, "HeyGuys Hi there new player! Your character creation process has begun! Go to your channel chat to continue.");
			newPlayerScript.tutorialProgress = 1;
		}

		messageRelay.AddPlayer (newPlayerScript);
	}
}