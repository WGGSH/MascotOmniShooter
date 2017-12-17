using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[SerializeField]
	List<Character> characterList; // 登録キャラリスト
	[SerializeField]
	int useCharacter; // 現在使用中のキャラ

	void Awake(){
		this.characterList.Clear();
	}

	// Use this for initialization
	void Start () {
		this.setCharacter();
	}
	
	// Update is called once per frame
	void Update () {
		// キャラチェンジ
		if(Input.GetButtonDown("CharaRight")){
			this.characterList[this.useCharacter].WalkOut();
			this.useCharacter= (this.useCharacter+1)% this.characterList.Count;
			this.setCharacter();
		}else if(Input.GetButtonDown("CharaLeft")){
			this.characterList[this.useCharacter].WalkOut();
			this.useCharacter = (this.useCharacter - 1 + this.characterList.Count) % this.characterList.Count;
			this.setCharacter();
		}
	}

	// キャラ変更時処理
	private void setCharacter(){
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
