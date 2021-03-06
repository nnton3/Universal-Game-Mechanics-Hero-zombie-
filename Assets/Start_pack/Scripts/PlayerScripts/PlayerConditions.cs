﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConditions : Conditions {

	//БЛОК
	public override void EnableBlock ()
	{
		base.EnableBlock ();
	}

	public override void DisableBlock ()
	{
		base.DisableBlock ();
	}

	//ПЕРЕКАТ

	//Параметры "Переката"
	public float rollImpulsePower = 10f;

	public override void EnableInvulnerability ()
	{
		//Если игрок не находится в стане и КД на перекат прошел
		SetImpulse (rollImpulsePower);
		base.EnableInvulnerability ();
		EnableStun (unit.direction);
		Physics2D.IgnoreLayerCollision (9, 8, true);
		attack = true;
		unit.input = Mathf.Sign (unit.direction);
	}

	public override void DisableInvulnerability ()
	{
		DisableStun ();
		SetImpulse (defaultImpulsePower);
		FinishAttack ();
		base.DisableInvulnerability ();
		Physics2D.IgnoreLayerCollision (9, 8, false);
	}

	//ОГЛУШЕНИЕ
	public override void EnableStun (float stunDirection)
	{
		base.EnableStun (stunDirection);
	}

	public override void DisableStun ()
	{
		base.DisableStun ();
	}

	//АТАКА МЕЧОМ

	public override void Default_Attack ()
	{
		base.Default_Attack ();
		//Меняем скорость атаки в зависимости от заданного параметра
		anim.speed = 1 / unit.attackSpeed;
	}



	//Сбросить чек атаки
	public override void FinishAttack () {
		attack = false;
		anim.speed = 1;
	}

	//ВЫСТРЕЛ ИЗ ЛУКА
	public override void Bow_Attack () {
		GameObject arrowInstance = Instantiate (arrow, new Vector3 (transform.position.x, transform.position.y + 0.9f, transform.position.z), Quaternion.identity);
		Аrrow arrowScript = arrowInstance.GetComponent<Аrrow> ();
		arrowScript.SetDirection (unit.direction);
	}

	//СМЕРТЬ
	public override void UnitDie () {
		alive = false;
	}
}
