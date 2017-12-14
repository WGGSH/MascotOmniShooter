using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
	private float totalTime;

	[SerializeField]
	private float generateCount;

	[SerializeField]
	GameObject enemy;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.totalTime += Time.deltaTime;
		if(this.totalTime>this.generateCount){
			this.totalTime -= this.generateCount;
			// 敵の発生
			GameObject enemy = Instantiate(this.enemy.gameObject,Quaternion.Euler(0,0,Random.Range(0,360)) * new Vector3(1, 0, 0)* 10, Quaternion.identity);
			enemy.transform.parent = this.transform;
		}
	}
}
