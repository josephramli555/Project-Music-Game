using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

	Rigidbody2D rb;
	public float speed;
	bool called=false;
	void Awake(){
		rb=GetComponent<Rigidbody2D>();
	}
	void Update () {
	if(PlayerPrefs.GetInt("Start")==1 && !called)
	{
		rb.velocity=new Vector2(0,-speed);
		called=true;
	}
	}
	// Update is called once per frame
	
		
	}

	

