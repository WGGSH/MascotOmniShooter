using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterConoha : Character {

	protected override void ShootFunction(){
		// Debug.Log("Call ShootFunction Conoha");
		// 前方に6発ずつ乱射する
		for(int i=0;i<6;i++){
			GameObject shootWeapon = Instantiate(this.weapon,this.transform.position+new Vector3(i*0.2f,0,0),Quaternion.identity);
			shootWeapon.GetComponent<WeaponManager>().Angle=Random.Range(-0.6f,0.6f)-
				this.stageObject.AngleRadian;
			shootWeapon.transform.parent=this.stageObject.transform;
		}
	}
}
