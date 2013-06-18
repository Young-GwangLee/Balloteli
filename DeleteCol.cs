using UnityEngine;
using System.Collections;

public class DeleteCol : MonoBehaviour {
  
	public bool MakeBool;
	
	//
	void OnTriggerEnter(Collider col) {
		if(MakeBool == true) {	
			MakeBool = false;
			GameObject.Find("MakePoint").GetComponent<Make2>().NextMake();
			StartCoroutine(MakeDelay());
		}
	}
	// Use this for initialization
	void Start () {
		MakeBool = true;		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator MakeDelay() {		
		yield return new WaitForSeconds(0.5f);
		MakeBool = true;
	
	}
	
	
}
