using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPronama : Character {

	protected override void ShootFunction(){
		// Debug.Log("Call ShootFunction Pronama");
		// 前方に2発ずつ
		for (int i = 0; i < 2; i++){
			GameObject shootWeapon = Instantiate(this.weapon, this.transform.position+
				new Vector3(0,(i*2-1),0)*0.2f,Quaternion.identity);
			shootWeapon.GetComponent<WeaponManager>().Angle = -this.stageObject.AngleRadian;
			shootWeapon.transform.parent = this.stageObject.transform;
		}
	}
}
