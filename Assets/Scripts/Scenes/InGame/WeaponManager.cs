using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {
	protected Transform trans;
	[SerializeField]
	protected float speed;
	// [SerializeField]
	protected Vector3 direction;
	// [SerializeField]
	protected float angle;
	[SerializeField]
	protected int power;

	// Use this for initialization
	protected void Start () {
		this.trans = this.transform;
		this.SetDirection();
	}
	
	// Update is called once per frame
	protected void Update () {
		// this.transform.localPosition += direction * Time.deltaTime;
		this.transform.localPosition += direction * Time.deltaTime;

		if(this.trans.position.x>Const.CO.STAGE_WIDTH || 
			this.trans.position.x< -Const.CO.STAGE_WIDTH || 
			this.trans.position.y>Const.CO.STAGE_HEIGHT || 
			this.trans.position.y<-Const.CO.STAGE_HEIGHT){
			Destroy(this.gameObject);
		}
	}

	private void SetDirection(){
		this.trans.rotation = Quaternion.identity;
		this.trans.localRotation = Quaternion.Euler(0, 0, this.angle * Mathf.Rad2Deg);
		// this.trans.Rotate(0, 0, this.angle * Mathf.Rad2Deg);
		this.direction =new Vector3(Mathf.Cos(this.angle),Mathf.Sin(this.angle),0) * this.speed;
	}

	public float Speed{
		set { this.speed = value; /*this.SetDirection();*/ }
	}

	public float Angle{
		set { this.angle = value; /*this.SetDirection();*/ }
	}

	public virtual void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Enemy"){
			other.GetComponent<Enemy>().Damage(this.power);
			Destroy(this.gameObject);
		}
	}

}
