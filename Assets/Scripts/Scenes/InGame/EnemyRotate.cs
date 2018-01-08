using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : Enemy {
	private float angle;
	[SerializeField]
	private float distance;
	[SerializeField]
	private float rotateSpeed;

	// Use this for initialization
	protected override void Start () {
		base.Start();
		this.distance = 10;
		this.angle = Random.Range(0, Mathf.PI * 2);
	}

	// Update is called once per frame
	protected override void Update () {
		base.Update();

		// 自身を少し回転
		this.angle += Time.deltaTime*this.rotateSpeed;
		this.distance -= Time.deltaTime*this.speed;
		this.trans.localPosition = new Vector3(
			this.distance * Mathf.Cos(this.angle),
			this.distance * Mathf.Sin(this.angle),
			0
		);

	}
}
