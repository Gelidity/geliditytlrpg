using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandsFight : MonoBehaviour {

	public GameObject fightObject;
	public Bestiary bestiaryScript;
	private Bestiary.Combat combat;

	void Start (){
		bestiaryScript = this.GetComponent<Bestiary> ();
	}

	public void Fight(PlayerScript playerScript, string[] command, string mob, MessageRelay messageRelay)
	{
		var i = bestiaryScript.EnemyIds.IndexOf (mob);
		//Bestiary.Enemy enemy = new bestiaryScript.EnemyStructs[i];


	}
}