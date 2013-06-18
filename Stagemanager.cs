using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour {
  
	public int StageNum;
	
	public GUIText TimeText;
	
	public float Timemer;
	
	public GUITexture GameOverTexture;
	
	public AudioSource m_OverSound;
	
	public AudioClip OverSound;
	
	
	bool GameOverCheck;
	
	bool CanClick;
	
	
	// Use this for initialization
	void Start () {
		StageNum = 1;
		
		Timemer = 60;
		
		Time.timeScale = 1;
		
		m_OverSound = GameObject.Find("Hero").audio ;
		
		GameOverCheck = false;
		CanClick = false;
	
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButtonDown(0)) {
			if(GameOverTexture.HitTest(new Vector2(Input.mousePosition.x, Input.mousePosition.y)) && CanClick ) {
			
				Application.LoadLevel("Score");
			}
		}
		
		if(Timemer<0 && GameOverCheck == false) { //GameOver.
			Make2.canMake = false;
			GameOverCheck = true;
			StartCoroutine(TrueCanClick());
			Time.timeScale=0.0001f;
			
			if(GameManager.m_Score > PlayerPrefs.GetInt("BestScore"))  {
				PlayerPrefs.SetInt("BestScore",GameManager.m_Score);
				PlayerPrefs.SetInt("NowScore",GameManager.m_Score);
				
				}
			else 
				PlayerPrefs.SetInt("NowScore",GameManager.m_Score);
			
			
			m_OverSound.PlayOneShot(OverSound, 1f)	;			
			
			GameOverTexture.transform.position = new Vector3(0.5f,0.5f,0);
		}
		
		else {
			Timemer -= Time.deltaTime;
		}
			
		TimeText.guiText.text = "" + (int)Timemer;
		
	}
	
	
	//GameOver Gui 띄우기 시간 설정

	IEnumerator TrueCanClick() {
		yield return new WaitForSeconds(0.00025f);
		CanClick = true;
	}
	
	
}
