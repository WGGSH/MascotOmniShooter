using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[SerializeField]
	List<Character> characterList; // 登録キャラリスト
	[SerializeField]
	int useCharacter; // 現在使用中のキャラ
	[SerializeField]
	SceneInGame inGame;


	void Awake(){
		this.characterList.Clear();
		this.inGame = GameObject.Find("InGameManager").GetComponent<SceneInGame>();
	}

	// Use this for initialization
	void Start () {
		// this.SetCharacter();
	}
	
	// Update is called once per frame
	void Update () {
		// キャラチェンジ
		if(Input.GetButtonDown("CharaRight")){
			this.characterList[this.useCharacter].WalkOut();
			this.useCharacter= (this.useCharacter+1)% this.characterList.Count;
			this.SetCharacter();
		}else if(Input.GetButtonDown("CharaLeft")){
			this.useCharacter= (this.useCharacter-1+this.characterList.Count)% this.characterList.Count;
			this.characterList[this.useCharacter].WalkOut();
			this.SetCharacter();
		}

		// キャラクターのダウン判定
		if(this.characterList[this.useCharacter].Life<=0){
			// ダウンしたキャラクターを右端の立ち絵から削除
			this.inGame.PlayerSpriteRemoeve(this.useCharacter);

			Destroy(this.characterList[this.useCharacter].gameObject);
			this.characterList.Remove(this.characterList[this.useCharacter]);


			// 最後尾のキャラクターがやられた場合,最前列のキャラに移行
			if(this.useCharacter==this.characterList.Count){
				this.useCharacter = 0;
			}

			this.SetCharacter();
			// 全てのキャラクターがダウンしたらゲームオーバー
			if(this.characterList.Count==0){
				// Debug.Log("Game Over");
				this.inGame.GameOver();
			}


		}
	}

	// キャラ変更時処理
	public void SetCharacter(){
		int size = this.characterList.Count;
		for (int i = 0; i < size;i++){
			if(i==this.useCharacter){
				this.characterList[i].gameObject.SetActive(true);
				this.characterList[i].Setup();
			} else{
				this.characterList[i].gameObject.SetActive(false);
			} 
		}
	}

	public void AddCharacter(GameObject character){
		GameObject chara = Instantiate(character.gameObject, this.transform);
		this.characterList.Add(chara.GetComponent<Character>());
	}
}
