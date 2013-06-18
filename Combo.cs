 
using UnityEngine;
using System.Collections;

public class Combo : MonoBehaviour {
 
	public int BlockNum;
	public static int ComboNum;
	

	
	
	void OnTriggerEnter(Collider col){
		if(col.tag == "e1" ) {
			BlockNum = 0;
			ComboCheck();
		}
			
		if(col.tag == "e2"){
			BlockNum = 1;
			ComboCheck();
		}
			
		if(col.tag == "e3"){
			BlockNum = 2;
			ComboCheck();
		}
					
		if(col.tag == "e4"){
			BlockNum = 3;
			ComboCheck();
		}
						
		if(col.tag == "e5"){
			BlockNum = 4;
			ComboCheck();
		}
					
		if(col.tag == "e6"){
			BlockNum = 5;
			ComboCheck();
		}
					
		if(col.tag == "e7"){
			BlockNum = 6;
			ComboCheck();
		}
		
		if(col.tag == "gooditem") {
            StartCoroutine(goodstate());
        }
		
		
        if(col.tag == "baditem") {
            StartCoroutine(badstate());	
        		
        }
		
	}
	
	void ComboCheck () {
		if(ComboNum %7 == BlockNum) {
			ComboNum ++;
			GameObject.Find("Main Camera").GetComponent<GameManager>().ComboTextCheck();
		}
		else {
			ComboNum = 0;
			Make2.EnemyLevel = 1;
		}
		
		if(PlayerPrefs.GetInt("BoatNum") == 1)
			GameManager.m_Score += ComboNum*100;
		else if(PlayerPrefs.GetInt("BoatNum") == 2)
			GameManager.m_Score += ComboNum*110;
		else if(PlayerPrefs.GetInt("BoatNum") == 3)
			GameManager.m_Score += ComboNum*120;
			
		
	}
	
	
	// Use this for initialization
	void Start () {
	 ComboNum = 0;

		
	}
	
	// Update is called once per frame
	void Update () {
      
	
}
	IEnumerator badstate() {
		Move.BadMove = true;
		yield return new WaitForSeconds(5f);
		Move.BadMove = false;
		
	}
	
	IEnumerator goodstate() {
		Make2.GoodItm = true;
		yield return new WaitForSeconds(10f);
		Make2.GoodItm = false;
		
	}


}
