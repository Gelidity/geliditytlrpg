using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Bestiary : MonoBehaviour {

	public class Enemy {
		public string name;
		public string id;
		public int hp;
		public int atk;
		public int xp;
		public List<string> loot = new List<string>();
	}

	public class Combat {
		public PlayerScript playerScript;
		public Enemy enemyScript;
	}

	public List<Enemy> EnemyStructs = new List<Enemy>();
	public List<string> EnemyIds = new List<string>();

	void Start () {

		StreamReader reader = new StreamReader (@"X:\TLRPGdata\Enemies\Enemies.txt");
		string s = reader.ReadLine ();
		string[] data;
		while(s != null) //Load enemies
		{
			data = s.Split('~');
			Enemy e = new Enemy ();
			e.name = data[0];
			e.id = data[1];
			e.hp = CommandsLoadSave.IntParseFast(data[2]);
			e.atk = CommandsLoadSave.IntParseFast(data [3]);
			e.atk = CommandsLoadSave.IntParseFast(data [4]);

			s = reader.ReadLine();
			data = s.Split('~');

			var i = 0;
			while (i != data.Length) {
				e.loot.Add (data [i]);
				i++;
			}
			EnemyStructs.Add (e);
			EnemyIds.Add(e.id);
			s = reader.ReadLine();
			s = reader.ReadLine();
		}
	}
}