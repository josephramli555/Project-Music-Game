using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

int multiplier=2;
int streak=1;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("Score",0);
		PlayerPrefs.SetInt("RockMeter",25);
		PlayerPrefs.SetInt("Streak",0);
		PlayerPrefs.SetInt("HighStreak",0);
		PlayerPrefs.SetInt("Mult",1);
		PlayerPrefs.SetInt("NotesHit",0);
		PlayerPrefs.SetInt("Start",1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		Destroy(col.gameObject);
		ResetStreak();
	}
	public int GetScore(){
			return 100*multiplier;
	}
	public void AddStreak(){
		if(PlayerPrefs.GetInt("RockMeter")+1<61)
			PlayerPrefs.SetInt("RockMeter",PlayerPrefs.GetInt("RockMeter")+5);
			
		streak++;
		if(streak>=10)
		{
			multiplier=16;
		}
		else if(streak>=6)
		{
			multiplier=8;
		}
		else if(streak>=2)
		{
			multiplier=4;
		}
		else 
			multiplier=1;

		if(streak>PlayerPrefs.GetInt("HighStreak"))
		{	
			PlayerPrefs.SetInt("HighStreak",streak);	
		}	
	PlayerPrefs.SetInt("NotesHit",PlayerPrefs.GetInt("NotesHit")+1);
	UpdateGui();
	}

	void UpdateGui(){
		PlayerPrefs.SetInt("Streak",streak);
		PlayerPrefs.SetInt("Mult",multiplier);


	}
	public void ResetStreak(){
		if(PlayerPrefs.GetInt("RockMeter")>-16)
			PlayerPrefs.SetInt("RockMeter",PlayerPrefs.GetInt("RockMeter")-5);
			Debug.Log("Julah rockmeter ="+PlayerPrefs.GetInt("RockMeter"));
		if(PlayerPrefs.GetInt("RockMeter")<-16)
			Lose();
		streak=0;
		multiplier=1;
		UpdateGui();
		
	}	
	void Lose(){
		PlayerPrefs.SetInt("Start",0);
		SceneManager.LoadScene(2);
	}
	public void Win(){
		PlayerPrefs.SetInt("Start",0);
		if(PlayerPrefs.GetInt("HighScore")<PlayerPrefs.GetInt("Score"))
			PlayerPrefs.SetInt("HighScore",PlayerPrefs.GetInt("Score"));
		SceneManager.LoadScene(1);
	}
}
