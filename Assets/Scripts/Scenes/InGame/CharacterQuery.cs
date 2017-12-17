using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterQuery : Character {

	protected override void ShootFunction(){
		// Debug.Log("Call ShootFunction Query");
		// 全方位3WAY弾
		for (int i = 0; i < 3; i++){
			GameObject shootWeapon = Instantiate(this.weapon, this.transform);
			shootWeapon.GetComponent<WeaponManager>().Angle = Mathf.PI*2/3*i-
				this.stageObject.AngleRadian;
			shootWeapon.transform.parent = this.stageObject.transform;
		}
	}
}
