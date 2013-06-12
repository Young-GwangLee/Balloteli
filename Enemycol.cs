using UnityEngine;
using System.Collections;

public class EnemyCol : MonoBehaviour {
  
	public GameObject m_Effact;
	
	public AudioSource m_Sound;
	
	public AudioClip CrashSound;
	public AudioClip ComboSound;
	
	public GameObject Level1;
	public GameObject Level2;
	public GameObject Level3;
	public GameObject Level4;
	
	
	void OnTriggerEnter(Collider col){
	if(col.tag == "hero" ) {
			m_Sound.PlayOneShot(CrashSound, 1f);
			
			Instantiate(m_Effact, transform.position, m_Effact.transform.rotation);
			Combo.ComboNum = 0;
			Make2.EnemyLevel = 1;
			Destroy(gameObject);
			}
	if(col.tag == "delete") {
			//Debug.Log("delete");
			Destroy(gameObject);
		}
	if(col.tag == "combo") {
			m_Sound.PlayOneShot(ComboSound, 1f);
			//Debug.Log("combo");
			Destroy(gameObject);
		}
	}
	
	// Use this for initialization
	void Start () {
		EnemyLevelCheck();
		
		m_Sound = GameObject.Find("Hero").audio ;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void EnemyLevelCheck() {
		switch(Make2.EnemyLevel) {
		case 1:			
			Destroy(Level2.transform.gameObject);
			Destroy(Level3.transform.gameObject);
			Destroy(Level4.transform.gameObject);			
			break;
		case 2:
			Destroy(Level1.transform.gameObject);
			Destroy(Level3.transform.gameObject);
			Destroy(Level4.transform.gameObject);	
			break;
		case 3:
			Destroy(Level1.transform.gameObject);
			Destroy(Level2.transform.gameObject);
			Destroy(Level4.transform.gameObject);
			break;
		case 4:
			Destroy(Level1.transform.gameObject);
			Destroy(Level2.transform.gameObject);
			Destroy(Level3.transform.gameObject);
			break;
			
		}
	}
	
}
