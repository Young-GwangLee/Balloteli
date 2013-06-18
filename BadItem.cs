using UnityEngine;
using System.Collections;

public class BadItemCol : MonoBehaviour {
  
	
	public AudioSource m_BadSound;
	
	public AudioClip BadSound;
	
	//각 개체에 해당하는 Trigger 행동 
	void OnTriggerEnter(Collider col){
	if(col.tag == "hero" ) {
			m_BadSound.PlayOneShot(BadSound, 1f);
			Destroy(gameObject);
			}
	if(col.tag == "delete") {
			Destroy(gameObject);
			}
	if(col.tag == "combo") {
			m_BadSound.PlayOneShot(BadSound, 1f);
			Destroy(gameObject);
			}
	}

	
	// Use this for initialization
	void Start () {
		//BadSound 설정
		m_BadSound = GameObject.Find("Hero").audio ;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
