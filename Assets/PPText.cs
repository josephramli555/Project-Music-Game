using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class PPText : MonoBehaviour {

public string name;
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text>().text=PlayerPrefs.GetInt(name)+"";
	}
}
