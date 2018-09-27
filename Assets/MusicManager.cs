using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
	bool called= false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("Start")==1 && !called)
	{
		GetComponent<AudioSource>().Play();
		called=true;
	}
	}
}
