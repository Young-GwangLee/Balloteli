using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
  
	public static int m_Score = 0;
	
	
	//public GUIText ComboCheck;
	public GUIText ScoreText;
	public GUIText BestScoreText;
	public GUIText ComboText;
	
	float AccTime;
	public float Delay = 1;
	
	public static int BoatNum;
	
	public GameObject Boat1;
	public GameObject Boat2;
	public GameObject Boat3;
	
	public GUITexture ComboTexture;
	public GUITexture TimeTexture;
	public GUITexture ScoreTexture;
	
	// Use this for initialization
	void Start () {
		m_Score = 0;
		AccTime = 0;
		
		BestScoreText.guiText.text = "BestScore : "+PlayerPrefs.GetInt("BestScore");
		BoatNum = PlayerPrefs.GetInt("BoatNum");
		
		BoatChoice();
	}
	
	// Update is called once per frame
	void Update () {
		AccTime += Time.deltaTime;
		
		//combo text를 AccTime 에 의하여 on,off
		if(AccTime > Delay)	{
			ComboText.guiText.enabled = false;
			ComboTexture.guiTexture.enabled = false;
		}
		else {
			if(Combo.ComboNum > 0) {
				ComboText.guiText.enabled = true;
				ComboTexture.guiTexture.enabled = true;
			}
			
		}
				
		ScoreText.guiText.text = "" + m_Score;
		

	
			
		if(Input.GetKey(KeyCode.Escape)){
			Application.Quit();
		}
	//}
	}
	
	//combo 이미지 입력
	public void ComboTextCheck() {
		ComboText.guiText.text = Combo.ComboNum + "";
		AccTime = 0;
		
	}
	
	//보트 선택
	void BoatChoice() {
		switch(BoatNum) {
		case 1:
			Destroy(Boat2.transform.gameObject);
			Destroy(Boat3.transform.gameObject);
			break;
		case 2:
			Destroy(Boat1.transform.gameObject);
			Destroy(Boat3.transform.gameObject);
			break;
		case 3:
			Destroy(Boat1.transform.gameObject);
			Destroy(Boat2.transform.gameObject);
			break;
		}
		
	}
	
}
