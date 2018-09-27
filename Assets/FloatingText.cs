using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour {

	public GameObject floatingtext;
	public float destroytime=3f;
	void Start () {
		Destroy(gameObject,0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
