using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	[SerializeField]
	public SceneInGame inGameManager;
	[SerializeField]
	protected int life;
	[SerializeField]
	protected float speed; // 接近速度
	protected Transform trans;
	protected Vector3 direction;

	// Use this for initialization
	protected virtual void Start () {
		this.trans = this.transform;
		this.direction = -this.trans.localPosition.normalized*this.speed;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		this.trans.localPosition += this.direction * Time.deltaTime;
	}

	// 被弾
	public void Damage(int value){
		this.life -= value;
		if(this.life<=0){
			Destroy(this.gameObject);
			this.inGameManager.AddScore(10);
		}
	}

	// プレイヤーとの接触
	public virtual void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Player"){
			other.GetComponent<Character>().Damage(1);
			Destroy(this.gameObject);
		}
	}
	
}
