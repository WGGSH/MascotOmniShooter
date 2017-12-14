using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {
	[SerializeField]
	private float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += new Vector3(1,0,0) * this.speed * Time.deltaTime;

		if(this.transform.position.x>Const.CO.STAGE_WIDTH){
			Destroy(this.gameObject);
		}
	}
}
