﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : Damage {

	public override void DefaultDamage(float damage, float stunDirection) {

		bool backToTheEnemy = BackToTheEnemyCheck (stunDirection);

		//Если игрок поставил блок
		if (conditions.block) {
			//Если игрок стоит к врагу спиной
			if (backToTheEnemy) {
				//Нанести урон
				ReduceHP (damage);
				//Получить оглушение
				conditions.EnableStun (stunDirection);
				//Анимация получения урона
				anim.SetTrigger ("attackable");
			} else {
				//Если игрок стоит лицом к врагу
				conditions.EnableStun (stunDirection);
				anim.SetTrigger ("blocked");
			}
			//Если игрок не заблокировал и не использовал перекат
		} else if (!conditions.invulnerability) {
			ReduceHP (damage);
			anim.SetTrigger ("attackable");
		}
	}

	public override void CriticalDamage (float damage, float stunDirection, float criticalScale) {
		
		bool backToTheEnemy = BackToTheEnemyCheck (stunDirection);
		float criticalDamageValue = (damage * criticalScale);

		//Если игрок поставил блок
		if (conditions.block) {
			//Если игрок стоит к врагу спиной
			if (backToTheEnemy) {
				//Нанести урон
				ReduceHP (criticalDamageValue);
				//Получить оглушение
				conditions.EnableStun (stunDirection);
				//Анимация получения урона
				anim.SetTrigger ("attackable");
			} else
				//Если игрок стоит лицом к врагу
				conditions.EnableStun (stunDirection);
			anim.SetTrigger ("blocked");
			//Если игрок не заблокировал и не использовал перекат
		} else if (!conditions.invulnerability) {
			ReduceHP (criticalDamageValue);
			anim.SetTrigger ("attackable");
		}
	}

	//Проверка: игрок стоит спиной к врагу?
	bool BackToTheEnemyCheck (float direction) {
		return unit.direction == direction;
	}

	//Уменьшить ХП + проверка на "смерть"
	void ReduceHP (float damage) {
		if (unit.health <= damage) {
			conditions.UnitDie ();
		}
		unit.health -= damage;
	}
}
