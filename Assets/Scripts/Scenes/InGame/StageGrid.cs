using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGrid : MonoBehaviour {
	[SerializeField]
	Renderer mat;

	// Use this for initialization
	void Start () {
		this.mat = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		this.mat.material.SetColor("_EmissionColor", Color.HSVToRGB(0.55f+Mathf.Sin(Time.time)*0.1f, 1, 0.05f));
	}
}
