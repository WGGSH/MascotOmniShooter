using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private float totalTime;

	[SerializeField]
	private float shootCount;

	[SerializeField]
	private GameObject weapon;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.totalTime += Time.deltaTime;
		if(this.totalTime>this.shootCount){
			this.totalTime -= this.shootCount;

			// 弾の発射
			Instantiate(this.weapon.gameObject, this.transform);
		}

	}
}
