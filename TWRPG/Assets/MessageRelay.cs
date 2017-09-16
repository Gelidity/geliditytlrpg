using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwitchChatter;

public class MessageRelay : MonoBehaviour {

	// This should be the only object that reads and sends twitch chat messages

	public List<PlayerScript> playerScripts = new List<PlayerScript> ();
	public List<string> joinedChannels = new List<string> ();


	public GameObject Commander;
	public CommandsTutorial commandsTutorial;
	public CommandsTravel  commandsTravel;
	public CommandsLoadSave commandsLoadSave;
	public CommandsManageStats commandsManageStats;
	//public CommandsEquip commandsEquip;
	public CommandsMisc commandsMisc;

	public GameObject PlayerCreator;
	public PlayerCreator playerCreator;

	void Start ()
	{
		Application.runInBackground = true;
		TwitchChatClient.singleton.userName = "twitchlandrpg";
		TwitchChatClient.singleton.oAuthPassword = "oauth:vhv08pwm1ajg7j530yqm9m1dia5rym";
		TwitchChatClient.singleton.JoinChannel("twitchlandrpg");
		TwitchChatClient.singleton.AddChatListener (OnChatMessage);
		TwitchChatClient.singleton.EnableWhispers();

		commandsTutorial = Commander.GetComponent<CommandsTutorial> ();
		commandsTravel = Commander.GetComponent<CommandsTravel> ();
		commandsLoadSave = Commander.GetComponent<CommandsLoadSave> ();
		commandsManageStats = Commander.GetComponent<CommandsManageStats> ();
		//commandsEquip = Commander.GetComponent<CommandsEquip> ();
		commandsMisc = Commander.GetComponent<CommandsMisc> ();

		playerCreator = PlayerCreator.GetComponent<PlayerCreator> ();
	}

	public void Chat(string channel, string message)
	{
		TwitchChatClient.singleton.SendMessage(channel, message);
	}

	public void Whisper(string user, string message)
	{
		TwitchChatClient.singleton.SendWhisper(user, message);
	}

	public void AddPlayer(PlayerScript playerScript)
	{
		playerScripts.Add (playerScript);
		joinedChannels.Add (playerScript.playerName.ToLower ());
		TwitchChatClient.singleton.JoinChannel (playerScript.playerName.ToLower ());
	}

	void OnChatMessage(ref TwitchChatMessage msg)
	{
		//Checks to see if player is logged in and using their channel
		var listVal = joinedChannels.IndexOf (msg.userName.ToLower());

		if (listVal == -1) {
			if(msg.channelName == "twitchlandrpg" && msg.chatMessagePlainText == "!play")
			{
				playerCreator.CreatePlayer (msg.userName);
				return;
			}
			return;
		}

		if (msg.userName.ToLower() != msg.channelName) {
			return;
		}

		//Gets player object data

		PlayerScript playerScript = playerScripts [listVal];
		string channel = joinedChannels [listVal];
		string commandtxt = msg.chatMessagePlainText.ToLower ();
		string[] command = commandtxt.Split (new string[] { " " }, System.StringSplitOptions.None);

		if (playerScript.tutorialProgress != 0) {
			commandsTutorial.Tutorial (playerScript, command, this);
			return;
		}

		if (command [0] == "status" && command.Length == 1) {
			commandsMisc.Status (playerScript, this);
			return;
		}

		if (command [0] == "inspect" && command.Length == 2) {
			commandsMisc.Inspect (playerScript, command, this);
			return;
		}

		if (playerScript.isTraveling == true) {
			Chat (channel, "You are currently traveling. You cannot take any action but \"turnback\".");
			return;
		}

		if (command [0] == "travel") {
			commandsTravel.Travel (playerScript, command, this);
			return;
		}

		if (command [0] == "explore" && command.Length == 1) {
			Chat (channel, playerScript.locationScript.exploreDescription);
			return;
		}
	}
}