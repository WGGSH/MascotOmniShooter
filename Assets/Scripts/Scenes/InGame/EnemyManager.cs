using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
	[SerializeField]
	SceneInGame inGameManager;
	private float totalTime;
	private int enemyGenerateCounter;

	[SerializeField]
	private float generateCount;
	[SerializeField]
	private int generateLoopCount;

	[SerializeField]
	GameObject[] enemy;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.totalTime += Time.deltaTime;
		if(this.totalTime>this.generateCount){
			this.totalTime -= this.generateCount;
			this.Generate(this.enemyGenerateCounter);

			this.enemyGenerateCounter++;
			if(this.enemyGenerateCounter==this.generateLoopCount){
				// 敵の発生ループをリセットし,発生周期を短くする
				this.enemyGenerateCounter = 0;
				this.generateCount *= 0.7f;
			}
		}
		/*
		if(this.totalTime>this.generateCount){
			this.totalTime -= this.generateCount;
			// 敵の発生
			GameObject enemy = Instantiate(this.enemy[0].gameObject,Quaternion.Euler(0,0,Random.Range(0,360)) * new Vector3(1, 0, 0)* 10, Quaternion.identity);
			enemy.transform.parent = this.transform;
			enemy.GetComponent<Enemy>().inGameManager = this.inGameManager;
		}
		*/
	}

	private void Generate(int counter){
		// 初め5回
		if(counter>=0 && counter<5){
			// ランダム 3体
			for (int i = 0; i < 3;i++){
				GameObject enemy = Instantiate(this.enemy[0].gameObject,Quaternion.Euler(0,0,Random.Range(0,360)) * new Vector3(1, 0, 0)* 10, Quaternion.identity);
				enemy.transform.parent = this.transform;
				enemy.GetComponent<Enemy>().inGameManager = this.inGameManager;
			}
		}else if(counter>=5 && counter<9){
			// ランダム5体
			for (int i = 0; i < 5;i++){
				GameObject enemy = Instantiate(this.enemy[0].gameObject,Quaternion.Euler(0,0,Random.Range(0,360)) * new Vector3(1, 0, 0)* 10, Quaternion.identity);
				enemy.transform.parent = this.transform;
				enemy.GetComponent<Enemy>().inGameManager = this.inGameManager;
			}
		}else if(counter==10){
			// 回転型3体
			for (int i = 0; i < 3;i++){
				GameObject enemy = Instantiate(this.enemy[1].gameObject,Quaternion.Euler(0,0,360.0f/3*i) * new Vector3(1, 0, 0)* 10, Quaternion.identity);
				enemy.transform.parent = this.transform;
				enemy.GetComponent<Enemy>().inGameManager = this.inGameManager;
			}
		}else if(counter>=11 && counter<14){
			// 雑魚6~9体
			for (int i = 0; i < counter-5;i++){
				GameObject enemy = Instantiate(this.enemy[0].gameObject,Quaternion.Euler(0,0,Random.Range(0,360)) * new Vector3(1, 0, 0)* 10, Quaternion.identity);
				enemy.transform.parent = this.transform;
				enemy.GetComponent<Enemy>().inGameManager = this.inGameManager;
			}
		}else if(counter==14){
			// 回転型7体
			for (int i = 0; i < 7;i++){
				GameObject enemy = Instantiate(this.enemy[1].gameObject,Quaternion.Euler(0,0,360.0f/7*i) * new Vector3(1, 0, 0)* 10, Quaternion.identity);
				enemy.transform.parent = this.transform;
				enemy.GetComponent<Enemy>().inGameManager = this.inGameManager;
			}
		}

	}
}
