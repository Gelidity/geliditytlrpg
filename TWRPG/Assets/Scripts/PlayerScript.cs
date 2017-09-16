using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwitchChatter;

public class PlayerScript : MonoBehaviour {

	public string channel;

	public int tutorialProgress;
	public string playerName;
	public string playerRace;
	public string playerClass;

	public bool isTraveling = false;
	public Traveler traveler = null;
	public bool isFighting = false;
	public bool isDungeon = false;

	public GameObject locationObject;
	public City locationScript;
	public string location;

	public int rewardFollow;
	public int rewardSub;

	public int hpMax;
	public int hpCur;
	public int mpMax;
	public int mpCur;

	public int[] stats;

	public int coins;

	public ItemBank.Equip gearHat;
	public ItemBank.Equip gearBod;
	public ItemBank.Equip gearWep;
	public ItemBank.Equip gearAcc;

	public int invSize;
	public string[] inv;
	public string inv1;
	public string inv2;
	public string inv3;
	public string inv4;
	public string inv5;

	public List<ItemBank.Item> loot = new List<ItemBank.Item>();

	public int level;
	public int xpCur;
	public int xpMax;
	public int skillPoints;
	public int statPoints;

	public int timerXp;
	public int boostXp;

	void Awake ()
	{
		stats = new int[5];
		inv = new string[5];
	}
}