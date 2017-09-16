using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CommandsLoadSave : MonoBehaviour {

	public List<GameObject> cityObjects = new List<GameObject> ();
	public List<string> cityNames = new List<string> ();
	public ItemBank itemBank;
	public CommandsManageStats commandsManageStats;

	void Start(){
		itemBank = this.gameObject.GetComponent<ItemBank> ();
		commandsManageStats = this.gameObject.GetComponent<CommandsManageStats> ();
	}

	public void Load (PlayerScript playerScript, MessageRelay messageRelay) {

		StreamReader reader = new StreamReader (@"X:\TLRPGdata\PlayerProfiles\" + playerScript.playerName + ".txt");

		string[] data = reader.ReadLine().Split('~');

		playerScript.playerName = data [0];
		playerScript.level = IntParseFast (data [1]);
		playerScript.playerRace = data [2];
		playerScript.playerClass = data [3];
		playerScript.location = data [4];

		playerScript.stats[0] = IntParseFast (data [5]);
		playerScript.stats[1] = IntParseFast (data [6]);
		playerScript.stats[2] = IntParseFast (data [7]);
		playerScript.stats[3] = IntParseFast (data [8]);
		playerScript.stats[4] = IntParseFast (data [9]);

		commandsManageStats.SetHpMp (playerScript);

		playerScript.xpCur = IntParseFast (data [10]);
		playerScript.xpMax = IntParseFast (data [11]);
		playerScript.skillPoints = IntParseFast (data [12]);
		playerScript.statPoints = IntParseFast (data [13]);
		playerScript.coins = IntParseFast (data [14]);
		playerScript.rewardFollow = IntParseFast (data [15]);
		playerScript.rewardSub = IntParseFast (data [16]);

		//EQUIP GEAR
		var i = itemBank.EquipIds.IndexOf (data [17]);
		if (i != -1) {
			playerScript.gearHat = itemBank.EquipStructs [i];
		}

		i = itemBank.EquipIds.IndexOf (data [18]);
		if (i != -1) {
			playerScript.gearBod = itemBank.EquipStructs [i];
		}

		i = itemBank.EquipIds.IndexOf (data [19]);
		if (i != -1) {
			playerScript.gearWep = itemBank.EquipStructs [i];
		}

		i = itemBank.EquipIds.IndexOf (data [20]);
		if (i != -1) {
			playerScript.gearAcc = itemBank.EquipStructs [i];
		}

		playerScript.inv[0] = data [21];
		playerScript.inv[1] = data [22];
		playerScript.inv[2] = data [23];
		playerScript.inv[3] = data [24];
		playerScript.inv[4] = data [25];

		reader.Close ();

		var loc = cityNames.IndexOf (playerScript.location);
		playerScript.locationObject = cityObjects [loc];
		playerScript.locationScript = playerScript.locationObject.GetComponent<City> ();
		playerScript.locationScript.population++;
	}

	public void Save (PlayerScript playerScript) {

		StreamWriter writer = new StreamWriter (@"X:\TLRPGdata\PlayerProfiles\" + playerScript.playerName + ".txt");

		writer.WriteLine (
			playerScript.playerName + "~" +
			playerScript.level.ToString () + "~" +
			playerScript.playerRace + "~" +
			playerScript.playerClass + "~" +
			playerScript.location + "~" +
			playerScript.stats[0].ToString () + "~" +
			playerScript.stats[1].ToString () + "~" +
			playerScript.stats[2].ToString () + "~" +
			playerScript.stats[3].ToString () + "~" +
			playerScript.stats[4].ToString () + "~" +
			playerScript.xpCur.ToString () + "~" +
			playerScript.xpMax.ToString () + "~" +
			playerScript.skillPoints.ToString () + "~" +
			playerScript.statPoints.ToString () + "~" +
			playerScript.coins.ToString () + "~" +
			playerScript.rewardFollow.ToString () + "~" +
			playerScript.rewardSub.ToString () + "~" +
			playerScript.gearHat.id + "~" +
			playerScript.gearBod.id + "~" +
			playerScript.gearWep.id + "~" +
			playerScript.gearAcc.id + "~" +
			playerScript.inv[0] + "~" +
			playerScript.inv[1] + "~" +
			playerScript.inv[2] + "~" +
			playerScript.inv[3] + "~" +
			playerScript.inv[4] + "~");

		writer.WriteLine (
			"Username~Level~Race~Class~Location~Str~Con~Dex~Wis~Int~XPcur~XPmax~Skillpoints~Statpoints~Coins~Follower~Sub~Hat~Bod~Wep~Acc~inv1~inv2~inv3~inv4~inv5~");

		writer.Close ();
	}

	public static int IntParseFast(string value)
	{
		int result = 0;
		for (int i = 0; i < value.Length; i++) {
			char letter = value [i];
			result = 10 * result + (letter - 48);
		}
		return result;
	}
}