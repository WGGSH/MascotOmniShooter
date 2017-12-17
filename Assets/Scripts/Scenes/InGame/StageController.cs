using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour {
	[SerializeField]
	private float rotateDegreePerSecond;
	[SerializeField]
	private float angleRadian;
	private float ROT_SPEED;
	float scale;

	// Use this for initialization
	void Start () {
		this.ROT_SPEED= Mathf.PI / 180 * this.rotateDegreePerSecond;
		this.scale = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("TurnRight")){
			this.angleRadian -= this.ROT_SPEED * Time.deltaTime;
			this.transform.rotation = Quaternion.Euler(0, 0, this.angleRadian * Mathf.Rad2Deg);
			// this.transform.Rotate(0, 0, -this.rotateSpeed);
		}else if(Input.GetButton("TurnLeft")){
			this.angleRadian += this.ROT_SPEED * Time.deltaTime;
			this.transform.rotation = Quaternion.Euler(0, 0, this.angleRadian * Mathf.Rad2Deg);
			// this.transform.Rotate(0, 0, this.rotateSpeed);
		}
		/* this.scale += 0.4f*Time.deltaTime;
		this.transform.localScale = new Vector3(this.scale, this.scale, 1);
		this.transform.lossyScale.Set(1/this.scale, 1/this.scale, 1);*/
	}

	public float AngleRadian{
		get { return this.angleRadian; }
	}
}
