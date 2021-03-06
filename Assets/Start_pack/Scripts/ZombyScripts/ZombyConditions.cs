﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombyConditions : Conditions {

	//ОГЛУШЕНИЕ
	public override void EnableStun (float stunDirection)
	{
		base.EnableStun (stunDirection);
	}

	public override void DisableStun ()
	{
		base.DisableStun ();
	}

	//АТАКА
	public override void Default_Attack ()
	{
		base.Default_Attack ();
	}

	public override void FinishAttack ()
	{
		StartCoroutine ("ResetAttackCheck");
	}

	//Сбросить чек атаки
	public IEnumerator ResetAttackCheck () {
		yield return new WaitForSeconds (unit.attackSpeed);
		attack = false;
	}

	//СМЕРТЬ

	public override void UnitDie ()
	{
		anim.SetTrigger ("die");
		base.UnitDie ();
		hpBar.Disable ();
		gameObject.layer = 2;
		gameObject.tag = "Puddle";

	}
}
