using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon4 : WeaponManager {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual void OnTriggerStay2D(Collider2D other){
		if(other.tag=="Enemy"){
			other.GetComponent<Enemy>().Damage(this.power);
			// Destroy(this.gameObject);
		}
	}

	public override void OnTriggerEnter2D(Collider2D other){
	}

}
