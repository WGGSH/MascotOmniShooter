using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	[SerializeField]
	List<Image> playerSpriteList;
	[SerializeField]
	List<Sprite> spriteList;
	[SerializeField]
	Button titleButton;

	private bool isGameOver;

	// Use this for initialization
	protected override void Start () {
		base.Start();
		this.isGameOver = false;


		// GameManagerから受け取った使用キャラリストを反映させる
		int[] useCharacters = this.gameManager.UseCharacters;
		foreach(int val in useCharacters){
			this.player.AddCharacter(this.characterPrefabList[val]);
		}

		// 左端の立ち絵を設定
		for (int i = 0; i < 3;i++){
			this.playerSpriteList[i].sprite = this.spriteList[useCharacters[i]];
			// キャラクターによって大きさを設定する
			switch(useCharacters[i]){
				case 0: // プロ生ちゃん
					this.playerSpriteList[i].transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
					break;
				case 1: // クエリちゃん
					this.playerSpriteList[i].transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					break;
				case 2: // このはちゃん
					this.playerSpriteList[i].transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					break;
				case 3: // あんずちゃん
					this.playerSpriteList[i].transform.localScale = new Vector3(0.2f, 0.20f, 0.2f);
					break;
				default:
					break;
			}
		}

		this.player.SetCharacter();

		this.totalTime = 0;
		this.score = 0;

		// タイトル画面へのボタンを非表示
		this.titleButton.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	protected override void Update () {
		this.totalTime += Time.deltaTime;
		if(this.totalTime>this.limitTime){
			// ゲーム終了
			// this.GameOver();
			this.totalTime -= this.limitTime;
		}
	}

	// スコアの加算
	public void AddScore(int value){
		this.score += value;
	}

	public void GameOver(){
		Debug.Log("GameOver");
		if(this.isGameOver==true)return;
		this.isGameOver = true;
		naichilab.RankingLoader.Instance.SendScoreAndShowRanking (this.score);
		// this.player.gameObject.SetActive(false);
		this.titleButton.gameObject.SetActive(true);

	}

	public void PlayerSpriteRemoeve(int index){
		Destroy(this.playerSpriteList[index].gameObject);
		this.playerSpriteList.Remove(this.playerSpriteList[index]);

	}
}
