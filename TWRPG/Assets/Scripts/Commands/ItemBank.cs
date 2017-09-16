using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemBank : MonoBehaviour {

	public class Item {
		public string name;
		public string id;
		public int sellPrice;
	}

	public class Equip : Item {
		public int slot;
		public int[] stats = new int[5];
	}

	public class Resource : Item {
		public string type;
	}

	public List<Equip> EquipStructs = new List<Equip>();
	public List<string> EquipIds = new List<string>();

	public List<Resource> ResourceStructs = new List<Resource>();
	public List<string> ResourceIds = new List<string>();

	void Start () {
		
		StreamReader reader = new StreamReader (@"X:\TLRPGdata\Items\EquipsHats.txt");
		string s = reader.ReadLine ();
		string[] data;
		while(s != null)
		{
			data = s.Split('~');
			Equip e = new Equip ();
			e.name = data[0];
			e.id = data[1];
			e.sellPrice = CommandsLoadSave.IntParseFast(data[2]);
			e.slot = 0;

			s = reader.ReadLine();
			data = s.Split('~');
			e.stats[0] = CommandsLoadSave.IntParseFast(data[0]);
			e.stats[1] = CommandsLoadSave.IntParseFast(data[1]);
			e.stats[2] = CommandsLoadSave.IntParseFast(data[2]);
			e.stats[3] = CommandsLoadSave.IntParseFast(data[3]);
			e.stats[4] = CommandsLoadSave.IntParseFast(data[4]);

			EquipStructs.Add (e);
			EquipIds.Add(e.id);

			s = reader.ReadLine();
			s = reader.ReadLine();
		}

		reader = new StreamReader (@"X:\TLRPGdata\Items\EquipsBods.txt");
		s = reader.ReadLine();
		while(s != null)
		{
			data = s.Split('~');
			Equip e = new Equip ();
			e.name = data[0];
			e.id = data[1];
			e.sellPrice = CommandsLoadSave.IntParseFast(data[2]);
			e.slot = 1;

			s = reader.ReadLine();
			data = s.Split('~');
			e.stats[0] = CommandsLoadSave.IntParseFast(data[0]);
			e.stats[1] = CommandsLoadSave.IntParseFast(data[1]);
			e.stats[2] = CommandsLoadSave.IntParseFast(data[2]);
			e.stats[3] = CommandsLoadSave.IntParseFast(data[3]);
			e.stats[4] = CommandsLoadSave.IntParseFast(data[4]);

			EquipStructs.Add (e);
			EquipIds.Add(e.id);

			s = reader.ReadLine();
			s = reader.ReadLine();
		}

		reader = new StreamReader (@"X:\TLRPGdata\Items\EquipsWeps.txt");
		s = reader.ReadLine();
		while(s != null)
		{
			data = s.Split('~');
			Equip e = new Equip ();
			e.name = data[0];
			e.id = data[1];
			e.sellPrice = CommandsLoadSave.IntParseFast(data[2]);
			e.slot = 2;

			s = reader.ReadLine();
			data = s.Split('~');
			e.stats[0] = CommandsLoadSave.IntParseFast(data[0]);
			e.stats[1] = CommandsLoadSave.IntParseFast(data[1]);
			e.stats[2] = CommandsLoadSave.IntParseFast(data[2]);
			e.stats[3] = CommandsLoadSave.IntParseFast(data[3]);
			e.stats[4] = CommandsLoadSave.IntParseFast(data[4]);

			EquipStructs.Add (e);
			EquipIds.Add(e.id);

			s = reader.ReadLine();
			s = reader.ReadLine();
		}

		reader = new StreamReader (@"X:\TLRPGdata\Items\EquipsAccs.txt");
		s = reader.ReadLine();
		while(s != null)
		{
			data = s.Split('~');
			Equip e = new Equip ();
			e.name = data[0];
			e.id = data[1];
			e.sellPrice = CommandsLoadSave.IntParseFast(data[2]);
			e.slot = 3;

			s = reader.ReadLine();
			data = s.Split('~');
			e.stats[0] = CommandsLoadSave.IntParseFast(data[0]);
			e.stats[1] = CommandsLoadSave.IntParseFast(data[1]);
			e.stats[2] = CommandsLoadSave.IntParseFast(data[2]);
			e.stats[3] = CommandsLoadSave.IntParseFast(data[3]);
			e.stats[4] = CommandsLoadSave.IntParseFast(data[4]);

			EquipStructs.Add (e);
			EquipIds.Add(e.id);

			s = reader.ReadLine();
			s = reader.ReadLine();
		}

		reader = new StreamReader (@"X:\TLRPGdata\Items\Resources.txt");
		s = reader.ReadLine();
		while(s != null)
		{
			data = s.Split('~');
			Resource r = new Resource ();
			r.name = data[0];
			r.id = data[1];
			r.type = data[2];
			r.sellPrice = CommandsLoadSave.IntParseFast(data[3]);

			ResourceStructs.Add (r);
			ResourceIds.Add(r.id);

			s = reader.ReadLine();
		}
		reader.Close ();
	}
}