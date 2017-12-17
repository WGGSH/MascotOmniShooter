using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBase : MonoBehaviour {
	[SerializeField]
	protected GameManager gameManager;

	// Use this for initialization
	protected virtual void Start () {
		this.gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		
	}

	public void ChangeScene(string sceneName){
		SceneManager.LoadScene(sceneName);
	}

}
