using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	private Transform trans;
	private Vector3 direction;

	// Use this for initialization
	void Start () {
		this.trans = this.transform;
		this.direction = -this.trans.localPosition.normalized;
	}
	
	// Update is called once per frame
	void Update () {
		this.trans.localPosition += this.direction * Time.deltaTime;
	}
}
