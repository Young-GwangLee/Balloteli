using UnityEngine;
using System.Collections;

public class Make2 : MonoBehaviour {
  
	
	public GameObject[] m_Item;
	
	public GameObject m_Enemy1;
	public GameObject m_Enemy2;
	public GameObject m_Enemy3;
	public GameObject m_Enemy4;
	public GameObject m_Enemy5;
	public GameObject m_Enemy6;
	public GameObject m_Enemy7;
	
	public GameObject m_GoodItem;
	public GameObject m_BadItem;
	
	public GameObject m_Rainbow;
	
	public GameObject[] m_Point;	

	public float m_Force;
	
	public int NextBlockNum;
	
	public static bool GoodItm;
	
	public float m_Speed ;
	
	public static int EnemyLevel;
	
	public static bool canMake;
	
	// Use this for initialization
	void Start () {
		canMake = true;
		GoodItm = false;
		NextMake();	
		EnemyLevel = 1;	
		

	}
	
	//객체 생성
	public void NextMake() {
		if(canMake) {
			for(int i=0; i<5; i++) {
				
				int r = Random.Range(0,24);
			
				if(r<3) {
					m_Item[i] = m_Enemy1;
				}
				else if (r<6){
					m_Item[i] = m_Enemy2;
				}
				else if (r<9){
					m_Item[i] = m_Enemy3;
				}
				else if (r<12){
					m_Item[i] = m_Enemy4;
				}
				else if (r<15){
					m_Item[i] = m_Enemy5;
				}
				else if (r<18){
					m_Item[i] = m_Enemy6;
				}
				else if (r<21){
					m_Item[i] = m_Enemy7;
				}
				else if (r<23){
					m_Item[i] = m_BadItem;
				}
				else if(r<24){
					m_Item[i] = m_GoodItem;
				}
			}
			int r2 = Random.Range(0,5);
			for(int i=0; i<5; i++) {
				m_Speed = 400;
				if(Combo.ComboNum <3)	m_Speed =420;
				else if(Combo.ComboNum <5) m_Speed =430;
				else if(Combo.ComboNum <7) m_Speed =470;
				else if(Combo.ComboNum <9) m_Speed =530;
				else if(Combo.ComboNum <11) m_Speed =550;
				else if(Combo.ComboNum <13) m_Speed =570;
				else if(Combo.ComboNum <15) m_Speed =590;
				else if(Combo.ComboNum <17) m_Speed =600;
				else if(Combo.ComboNum <19) m_Speed =630;
				else if(Combo.ComboNum <21) m_Speed =650;
				else m_Speed =660;
				
				if(GoodItm==false){
					if(r2 == i) {
						NextBlockNum = Combo.ComboNum%7;					
						
						if(NextBlockNum == 0 && Combo.ComboNum != 0) {
							NextBlockNum =0;
							EnemyLevel ++;
						}
						
						
						
						switch(NextBlockNum) {
						case 0:					
							GameObject go1 = (GameObject) Instantiate(m_Enemy1, m_Point[i].transform.position, m_Enemy1.transform.rotation);
							go1.rigidbody.AddForce(-transform.forward * m_Speed);
							break;
						case 1:
							GameObject go2 = (GameObject) Instantiate(m_Enemy2, m_Point[i].transform.position, m_Enemy2.transform.rotation);
							go2.rigidbody.AddForce(-transform.forward * m_Speed);
							break;
						case 2:
							GameObject go3 = (GameObject) Instantiate(m_Enemy3, m_Point[i].transform.position, m_Enemy3.transform.rotation);
							go3.rigidbody.AddForce(-transform.forward * m_Speed);
							break;
						case 3:
							GameObject go4 = (GameObject) Instantiate(m_Enemy4, m_Point[i].transform.position, m_Enemy4.transform.rotation);
							go4.rigidbody.AddForce(-transform.forward * m_Speed);
							break;
						case 4:
							GameObject go5 = (GameObject) Instantiate(m_Enemy5, m_Point[i].transform.position, m_Enemy5.transform.rotation);
							go5.rigidbody.AddForce(-transform.forward * m_Speed);
							break;
						case 5:
							GameObject go6 = (GameObject) Instantiate(m_Enemy6, m_Point[i].transform.position, m_Enemy6.transform.rotation);
							go6.rigidbody.AddForce(-transform.forward * m_Speed);
							break;
						case 6:
							GameObject go7 = (GameObject) Instantiate(m_Enemy7, m_Point[i].transform.position, m_Enemy7.transform.rotation);
							go7.rigidbody.AddForce(-transform.forward * m_Speed);
							break;
						
						}
					}
					else {
						GameObject go = (GameObject) Instantiate(m_Item[i], m_Point[i].transform.position, m_Item[i].transform.rotation);
						go.rigidbody.AddForce(-transform.forward * m_Speed);
					}
				}
				else {
					GameObject go = (GameObject) Instantiate(m_Rainbow, m_Point[i].transform.position, m_Item[i].transform.rotation);
					go.rigidbody.AddForce(-transform.forward * m_Speed);
				}
			}
		}
	}
	
	
	
	//void EnemyLevelCheck (){
	//	if(
}
