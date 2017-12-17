using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInGame : SceneBase {
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

	}
	
	// Update is called once per frame
	protected override void Update () {
		
	}
}
