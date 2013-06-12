using UnityEngine;
using System.Collections;

public class GoodItemCol : MonoBehaviour {

  public AudioSource m_Sound;
	
	public AudioClip GoodSound;
	
	void OnTriggerEnter(Collider col){
	if(col.tag == "hero" ) {
			m_Sound.PlayOneShot(GoodSound, 1f);
			Destroy(gameObject);
			}
	if(col.tag == "delete") {
			Destroy(gameObject);
			}
	if(col.tag == "combo") {
			m_Sound.PlayOneShot(GoodSound, 1f);
			Destroy(gameObject);
			}
	}
	

	
	// Use this for initialization
	void Start () {
	
		m_Sound = GameObject.Find("Hero").audio ;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
