using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneCharaSelect : SceneBase {
	[SerializeField]
	Text textObject;
	[SerializeField]
	List<Button> buttons;
	[SerializeField]
	int state;

	// Use this for initialization
	protected override void Start () {
		base.Start();
		this.state = 0;
		this.SetText();
	}

	// Update is called once per frame
	protected override void Update () {
		
	}

	private void SetText(){
		/* switch(this.state){
			case 0:
				this.textObject.text = "Set Leader Character";
				break;
			case 1:
				this.textObject.text = "Set 2nd Character";
				break;
			case 2:
				this.textObject.text = "Set 3rd Character";
				break;
			default:
			break;
		}*/
	}

	// キャラ選択のボタンがクリックされると呼び出し
	public void OnCharacterButtonClicked(int index){
		this.buttons[index].gameObject.SetActive(false);
		this.gameManager.SetCharacter(this.state, index);
		this.state++;

		// 3人目が選択されれば,次のシーンへ移行
		if(this.state==3){
			this.ChangeScene("InGame");
		}
		
	}
}
