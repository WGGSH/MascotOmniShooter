using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInGame : SceneBase {
	[SerializeField]
	private float limitTime; // 制限時間
	[SerializeField]
	private float totalTime; // 経過時間
	[SerializeField]
	private float score; // 獲得スコア
	[SerializeField]
	PlayerController player;
	[SerializeField]
	public GameObject stagePrefab;
	[SerializeField]
	List<GameObject> characterPrefabList;

	// Use this for initialization
	protected override void Start () {
		base.Start();


		// GameManagerから受け取った使用キャラリストを反映させる
		int[] useCharacters = this.gameManager.UseCharacters;
		foreach(int val in useCharacters){
			this.player.AddCharacter(this.characterPrefabList[val]);
		}

		this.totalTime = 0;
		this.score = 0;
	}
	
	// Update is called once per frame
	protected override void Update () {
		this.totalTime += Time.deltaTime;
		if(this.totalTime>this.limitTime){
			// ゲーム終了
			naichilab.RankingLoader.Instance.SendScoreAndShowRanking (this.score);
			this.totalTime -= this.limitTime;
		}
	}

	// スコアの加算
	public void AddScore(int value){
		this.score += value;
	}
}
