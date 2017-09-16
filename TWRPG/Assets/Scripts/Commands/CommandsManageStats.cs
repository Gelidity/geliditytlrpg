using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandsManageStats : MonoBehaviour {

	public ItemBank itemBank;

	void Start(){
		itemBank = this.gameObject.GetComponent<ItemBank> ();
	}

	public void LevelUp (PlayerScript playerScript, MessageRelay messageRelay)
	{
		if (playerScript.xpCur >= playerScript.xpMax) {
			playerScript.xpCur -= playerScript.xpMax;
			playerScript.xpMax += 150;
			playerScript.level++;
			playerScript.skillPoints += 2;
			playerScript.statPoints += 3;
			messageRelay.Chat (playerScript.channel, "Congratulations! You have reached level " + playerScript.level.ToString () + "! PogChamp");
		} else {
			var diff = playerScript.xpMax - playerScript.xpCur;
			messageRelay.Chat (playerScript.channel, "You need " + diff.ToString () + " more XP before you can level up.");
		}
	}

	public void EquipGear (PlayerScript playerScript, string gearName)
	{
		var i = itemBank.EquipIds.IndexOf (gearName);
		if (i != -1) {
			var gear = itemBank.EquipStructs [i];
			switch (gear.slot) {
			case 0:
				playerScript.gearHat = gear;
				ChangeStats (playerScript, gear.stats, 1);
				break;
			case 1:
				playerScript.gearBod = gear;
				ChangeStats (playerScript, gear.stats, 1);
				break;
			case 2:
				playerScript.gearWep = gear;
				ChangeStats (playerScript, gear.stats, 1);
				break;
			case 3:
				playerScript.gearAcc = gear;
				ChangeStats (playerScript, gear.stats, 1);
				break;
			}
		} else {
			Debug.Log ("Something tried to equip gear that does not exist! (" + gearName + ")");
		}
	}

	public void UnequipGear (PlayerScript playerScript, string gearName)
	{
		var i = itemBank.EquipIds.IndexOf (gearName);
		if (i != -1) {
			var gear = itemBank.EquipStructs [i];
			switch (gear.slot) {
			case 0:
				playerScript.gearHat = null;
				ChangeStats (playerScript, gear.stats, -1);
				break;
			case 1:
				playerScript.gearBod = null;
				ChangeStats (playerScript, gear.stats, -1);
				break;
			case 2:
				playerScript.gearWep = null;
				ChangeStats (playerScript, gear.stats, -1);
				break;
			case 3:
				playerScript.gearAcc = null;
				ChangeStats (playerScript, gear.stats, -1);
				break;
			}
		} else {
			Debug.Log ("Something tried to unequip gear that does not exist! (" + gearName + ")");
		}
	}

	public void ChangeStats (PlayerScript playerScript, int[] stats, int sign)
	{
		playerScript.stats[0] += stats [0] * sign;
		playerScript.stats[1] += stats [1] * sign;
		playerScript.stats[2] += stats [2] * sign;
		playerScript.stats[3] += stats [3] * sign;
		playerScript.stats[4] += stats [4] * sign;

		SetHpMp (playerScript);
	}

	public void SetHpMp (PlayerScript playerScript)
	{
		playerScript.hpMax = playerScript.stats [1] * 2;
		if (playerScript.hpCur > playerScript.hpMax) {
			playerScript.hpCur = playerScript.hpMax;
		}

		playerScript.mpMax = playerScript.stats [3] * 2;
		if (playerScript.mpCur > playerScript.mpMax) {
			playerScript.mpCur = playerScript.mpMax;
		}
	}

	public void StartStats (PlayerScript playerScript)
	{
		//Giving player stats and equips after tutorial when the character is first made

		playerScript.stats[0] = 5;
		playerScript.stats[1] = 5;
		playerScript.stats[2] = 5;
		playerScript.stats[3] = 5;
		playerScript.stats[4] = 5;

		switch (playerScript.playerRace) {
		case "kappa":
			playerScript.stats[0] += 1;
			playerScript.stats[1] += 1;
			playerScript.stats[2] += 1;
			playerScript.stats[3] += 1;
			playerScript.stats[4] += 1;
			EquipGear (playerScript, "kappacap");
			EquipGear (playerScript, "kappajersey");
			break;
		case "vohiyo":
			playerScript.stats[0] += 0;
			playerScript.stats[1] += 0;
			playerScript.stats[2] += 1;
			playerScript.stats[3] += 2;
			playerScript.stats[4] += 2;
			EquipGear (playerScript, "vohiyoveil");
			EquipGear (playerScript, "vohiyorobe");
			break;
		case "swiftrage":
			playerScript.stats[0] += 2;
			playerScript.stats[1] += 2;
			playerScript.stats[2] += 1;
			playerScript.stats[3] += 0;
			playerScript.stats[4] += 0;
			EquipGear (playerScript, "swiftragesalakot");
			EquipGear (playerScript, "swiftragesarong");
			break;
		}
		switch (playerScript.playerClass) {
		case "knight":
			EquipGear (playerScript, "shortsword");
			EquipGear (playerScript, "woodenshield");
			break;
		case "medic":
			EquipGear (playerScript, "truncheon");
			EquipGear (playerScript, "fieldreference");
			break;
		case "ranger":
			EquipGear (playerScript, "slingshot");
			EquipGear (playerScript, "pocketknife");
			break;
		case "wizard":
			EquipGear (playerScript, "walkingstick");
			EquipGear (playerScript, "shinyrock");
			break;
		}
		SetHpMp (playerScript);
	}
}