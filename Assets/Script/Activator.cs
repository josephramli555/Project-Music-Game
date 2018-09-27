using System.Collections;
using UnityEngine;
using TMPro;
public class Activator : MonoBehaviour {


	public GameObject floatingtext;
	SpriteRenderer sr;
	public KeyCode key;
	bool active=false;
	GameObject note,gm;
	Color old;
	public bool createMode;
	public GameObject n;

	public GameObject skor;
	void Start () {
		old=sr.color;
		gm=GameObject.Find("GameManager");
	}  

	void Awake()
	{
		sr=GetComponent<SpriteRenderer>();
	}
	// Update is called once per frame
	void Update () {
		if(createMode)
		{
			if(Input.GetKeyDown(key))
			{
				Instantiate(n,transform.position,Quaternion.identity);
			}
		}else{
			
		
			if(Input.GetKeyDown(key))
			{
				StartCoroutine(Pressed());
			}
			if(Input.GetKeyDown(key)&& active)
			{
				Destroy(note);
				gm.GetComponent<GameManager>().AddStreak(); 
				AddScore();	
				createfloatingtext(skor);
				active=false;
			}	
			else if(Input.GetKeyDown(key) && !active)
			{
			gm.GetComponent<GameManager>().ResetStreak();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag=="WinNote")
		{
			gm.GetComponent<GameManager>().Win();
		}
		if(col.gameObject.tag=="Note")
		{
			note=col.gameObject;
			active=true;
		}
	}

	void AddScore(){
			PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score")+gm.GetComponent<GameManager>().GetScore());
	}
	void OnTriggerExit2D(Collider2D col)
	{
		active=false;
 		
	
	}

	void createfloatingtext(GameObject floatingtext)
	{
		GameObject cube=Instantiate(floatingtext,floatingtext.transform.position,Quaternion.identity);
		cube.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform,false);
		cube.GetComponent<TextMeshProUGUI>().text=PlayerPrefs.GetInt("Score").ToString();
	}
IEnumerator Pressed()
	{
		sr.color=new Color(0,0,0);
		yield return new WaitForSeconds(0.05f);
		sr.color=old;
	}

}

	

