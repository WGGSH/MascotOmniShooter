using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponConoha : WeaponManager {
	private float totalTime;
	[SerializeField]
	private float finishTime;

	// Use this for initialization
	void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update();

		// 指定時間で消滅する
		this.totalTime+=Time.deltaTime;
		if(this.totalTime>this.finishTime){
			Destroy(this.gameObject);
		}
	}
}
