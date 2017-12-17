using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character4 : Character {
	private GameObject ShootedWeapon;

	public override void Setup(){
		// 出場時に弾を発射する
		this.totalTime=0;
		this.ShootFunction();
	}


	public override void WalkOut(){
		Destroy(this.ShootedWeapon.gameObject);
	}

	protected override void ShootFunction(){
		// Debug.Log("Call ShootFunction Character4");
		this.ShootedWeapon = Instantiate(this.weapon,this.transform);
		this.ShootedWeapon.GetComponent<WeaponManager>().Angle=-this.stageObject.AngleRadian;
	}
}
