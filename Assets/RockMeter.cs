using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMeter : MonoBehaviour {

	float rm;
	GameObject needle;
	void Start () {
		needle=GameObject.Find("Needle");
	}
	
	// Update is called once per frame
	void Update () {
		rm=PlayerPrefs.GetInt("RockMeter");
		needle.transform.localPosition=new Vector3(((rm-25)/25)+4.83f,-2.8f,0);	
	}
}
