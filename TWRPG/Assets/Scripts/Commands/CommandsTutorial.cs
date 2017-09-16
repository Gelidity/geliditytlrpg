using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandsTutorial : MonoBehaviour {

	public void Tutorial (PlayerScript playerScript, string[] command, MessageRelay messageRelay)
	{
		switch (playerScript.tutorialProgress) {
		case 1:
			messageRelay.Chat (playerScript.channel, "Hi there! I will talk you through character creation, but first, please consider typing \"/mod TwitchLandRPG\" so my messages don't get filtered as spam " +
			"if we go too fast. Type anything to continue.");
			playerScript.tutorialProgress++;
			break;
		case 2:
			messageRelay.Chat (playerScript.channel, "The first step is to select your race. This determines your home city, your starting stats, and your racial abilities. Available races are kappa, vohiyo, and " +
			"swiftrage. To learn more about a race, type \"learn race\". To select a race to play, type \"choose race\".");
			playerScript.tutorialProgress++;
			break;
		case 3:
			if (command.Length == 2)
			{
				if(command[0] == "learn" || command[0] == "choose")
				{
					SetRace (playerScript, command, messageRelay);
				}
			}
			if (playerScript.tutorialProgress == 4)
			{
				messageRelay.Chat (playerScript.channel, "You chose " + playerScript.playerRace + " as your race! Excellent choice! Now it is time to choose your class, " +
				"which defines the passive and active abilities you can " +
				"learn as you level up. Available classes are Knight, Medic, Ranger, and Wizard. To learn more about a class, type \"learn class\". " +
				"To select a class to play, type \"choose class\".");
				playerScript.tutorialProgress++;
				break;
			}
			break;
		case 5:
			if (command.Length == 2)
			{
				if(command[0] == "learn" || command[0] == "choose")
				{
					SetClass (playerScript, command, messageRelay);
				}
			}
			if (playerScript.tutorialProgress == 6)
			{
				messageRelay.Chat (playerScript.channel, "You chose " + playerScript.playerClass + " as your class! Superb choice! That is all there is to character creation. " +
				"You have been dropped off at your home city. The world is now yours to explore! Check below the stream to learn about the commands available to you. " +
				"I hope you enjoy the game! :)");
				playerScript.tutorialProgress = 0;
				messageRelay.commandsManageStats.StartStats(playerScript);
				playerScript.location = playerScript.locationScript.travelName;
				playerScript.locationScript.population++;
				playerScript.hpCur = playerScript.hpMax;
				playerScript.mpCur = playerScript.mpMax;
				playerScript.level = 1;
				playerScript.xpCur = 0;
				playerScript.xpMax = 100;
				messageRelay.commandsLoadSave.Save(playerScript);
				break;
			}
			break;
		}
	}
	
	
	//handles commands about deciding upon race
	void SetRace (PlayerScript playerScript, string[] command, MessageRelay messageRelay)
	{
		if (command [0] == "learn")
		{
			switch(command [1])
			{
				case "race":
					messageRelay.Chat (playerScript.channel, "Don't actually type \"race\" FailFish Swap that out for the race you want to learn about!");
					break;
				case "kappa":
					messageRelay.Chat (playerScript.channel, "Kappa Kappas are the commonfolk of TwitchLand. They are found everywhere but are native to KappaDale. " +
					"They start with balanced stats and the ability to travel slightly faster.");
					break;
				case "vohiyo":
					messageRelay.Chat (playerScript.channel, "VoHiYo Vohiyos are a mysterious people from Vohiyo Forest. They start with lower hp but higher mp " +
					"and the ability to quickly regenerate it for a time.");
					break;
				case "swiftrage":
					messageRelay.Chat (playerScript.channel, "SwiftRage Swiftrages are a strong and proud race that live on Swiftrage Mountain. They start with lower mp " +
					"but higher hp and the ability to take less damage and deal more for a time.");
					break;
			}
			return;
		}

		if (command[0] == "choose")
		{
			if (command[1] == "race")
			{
				messageRelay.Chat (playerScript.channel, "Don't actually type \"race\" FailFish Swap that out for the race you want to choose!");
				return;
			}

			if (command[1] == "kappa" || command[1] == "vohiyo" || command[1] == "swiftrage")
			{
				switch (command[1]) {
				case "kappa":
					playerScript.locationObject = GameObject.Find ("City_CastleKappa");
					playerScript.locationScript = playerScript.locationObject.GetComponent<CityScript_CastleKappa> ();
					break;
				case "vohiyo":
					playerScript.locationObject = GameObject.Find ("City_VohiyoVillage");
					playerScript.locationScript = playerScript.locationObject.GetComponent<CityScript_VohiyoVillage> ();
					break;
				case "swiftrage":
					playerScript.locationObject = GameObject.Find ("City_SwiftrageMountain");
					playerScript.locationScript = playerScript.locationObject.GetComponent<CityScript_SwiftrageMountain> ();
					break;
				}
				playerScript.playerRace = command[1];
				playerScript.tutorialProgress++;
			}
		}
	}
	

	void SetClass (PlayerScript playerScript, string[] command, MessageRelay messageRelay)
	{
		if (command [0] == "learn")
		{
			switch(command [1])
			{
				case "class":
					messageRelay.Chat (playerScript.channel, "Don't actually type \"class\" FailFish Swap that out for the class you want to learn about!");
					break;
				case "knight":
					messageRelay.Chat (playerScript.channel, "Knights thrive on being in the front lines of combat. They have access to a variety of offensive, defensive, and " +
					"supportive abilities, allowing them to have an equal balance or a focus on just one fighting style.");
					break;
				case "medic":
					messageRelay.Chat (playerScript.channel, "Medics are fearless combat healers. They mostly have strong supportive abilities, but their offensive potential  " +
					"shouldn't be underestimated.");
					break;
				case "ranger":
					messageRelay.Chat (playerScript.channel, "Rangers are tough and independant fighters. They have strong offense and a decent defense, but don't offer much support to " +
					"their allies.");
					break;
				case "wizard":
					messageRelay.Chat (playerScript.channel, "Wizards are eternal students of the magical arts. They have access to great offensive and utility abilities, but they sorely " +
					"lack and personal defense.");
					break;
			}
			return;
		}

		if (command[0] == "choose")
		{
			if (command[1] == "class")
			{
				messageRelay.Chat (playerScript.channel, "Don't actually type \"class\" FailFish Swap that out for the class you want to choose!");
				return;
			}

			if (command[1] == "knight" || command[1] == "medic" || command[1] == "ranger" || command[1] == "wizard")
			{
				playerScript.playerClass = command[1];
				playerScript.tutorialProgress++;
			}
		}
	}
}