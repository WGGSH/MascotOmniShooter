using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnzu : Character {

	protected override void ShootFunction(){
		// 前後2WAY弾
		for (int i = 0; i < 2; i++){
			GameObject shootWeapon = Instantiate(this.weapon, this.transform);
			shootWeapon.GetComponent<WeaponManager>().Angle = Mathf.PI*2/2*i-
				this.stageObject.AngleRadian;
			shootWeapon.transform.parent = this.stageObject.transform;
		}
	}
}
