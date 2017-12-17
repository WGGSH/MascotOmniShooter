using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	[SerializeField]
	private int life;
	private Transform trans;
	private Vector3 direction;

	// Use this for initialization
	void Start () {
		this.trans = this.transform;
		this.direction = -this.trans.localPosition.normalized*0.3f;
	}
	
	// Update is called once per frame
	void Update () {
		this.trans.localPosition += this.direction * Time.deltaTime;
	}

	public void Damage(int value){
		this.life -= value;
		if(this.life<=0){
			Destroy(this.gameObject);
		}
	}
	
}
