using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// シーン遷移,他のシーンへのデータ受け渡しを管理
public class GameManager : MonoBehaviour {
	[SerializeField]
	// List<int> useCharacter; // 使用キャラリスト
	int[] useCharacters; // 使用キャラリスト
	[SerializeField]
	int leader;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject); // 自身をシーン遷移で破棄されないオブジェクトに設定

		this.useCharacters = new int[3];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetCharacter(int index, int character){
		this.useCharacters[index] = character;
	}

	/*public void ChangeScene(string sceneName){
		SceneManager.LoadScene(sceneName);
	}*/
	

	public int[] UseCharacters{
		get { return this.useCharacters; }
	}

}
