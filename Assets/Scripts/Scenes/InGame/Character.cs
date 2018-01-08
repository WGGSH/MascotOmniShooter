using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {
	[SerializeField]
	protected StageController stageObject;
	protected float totalTime;
	[SerializeField]
	protected float shootCount; // 攻撃発射間隔
	[SerializeField]
	protected GameObject weapon; // 発射する武器
	[SerializeField]
	protected int life; // 体力

	public int Life{
		get { return this.life; }
	}

	// protected StageController stageObject;

	// キャラ出場時
	public virtual void Setup(){
		this.totalTime = 0;
	}

	// キャラ退場時
	public virtual void WalkOut(){
	}

	// Use this for initialization
	protected void Start () {
		this.stageObject = GameObject.FindGameObjectWithTag("Stage").GetComponent<StageController>();
	}
	
	// Update is called once per frame
	void Update () {
		// 一定時間ごとに武器を発射する
		this.totalTime += Time.deltaTime;
		if(this.totalTime>this.shootCount){
			this.totalTime -= this.shootCount;
			this.ShootFunction(); // キャラごとに固有の武器発射処理を行う
		}
	}

	// 各キャラごとの武器発射処理
	protected abstract void ShootFunction();

	// 被ダメージ
	public void Damage(int value){
		this.life -= value;
		// if(this.life<0){
		// 	Destroy(this.gameObject);
		// }
		// Debug.Log("damage");
	}
}
