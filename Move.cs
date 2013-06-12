using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

  int Combo;
	
	public bool canJump;
	public static bool BadMove;
	
	public GameObject m_Boat;
	public Animation m_Ani;
	
	public GUITexture m_left;
	public GUITexture m_right;
	
	public GameObject Boat1;
	public GameObject Boat2;
	public GameObject Boat3;
	
	void OnCollisionStay(Collision col){
		if(col.collider.tag == "land"){
			canJump = true;
			transform.tag = "hero";
			
		
	}}
	
	void OnCollisionExit(Collision col){
		if(col.collider.tag == "land"){
			canJump = false;
			transform.tag = "hero_jump";
					
	}}

    void OnTriggerEnter(Collider col) {
	
        if(col.tag == "gooditem") {
            StartCoroutine(goodstate());
        }
		
		
        if(col.tag == "baditem") {
            StartCoroutine(badstate());	
        		
        }
    }



    // Use this for initialization
	void Start () {
		canJump = true;
		BadMove	= false;
		
		switch(PlayerPrefs.GetInt("BoatNum")) {
		case 1:
			m_Boat = Boat1;
			break;
		case 2:
			m_Boat = Boat2;
			break;
		case 3:
			m_Boat = Boat3;
			break;
		}
		Debug.Log(""+GameManager.BoatNum);
		
		m_Ani =  m_Boat.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Application.isEditor) {
		
			if(Input.GetKeyDown(KeyCode.LeftArrow)  && canJump) {
				LeftMove();
			}
	
			if(Input.GetKeyDown(KeyCode.RightArrow)  && canJump ) {
				RightMove();
			}
	
			if(Input.GetKeyDown(KeyCode.Space) && canJump) {
				JumpMove();				
			}	
		}
		
		else {
			
			if(Input.touchCount > 0 ) {
				Touch touch = Input.GetTouch(0);
				if(touch.phase == TouchPhase.Began) {
					if(m_left.HitTest(new Vector2(Input.mousePosition.x, Input.mousePosition.y))  && canJump )
					{ 
						LeftMove();
					}
						
					if(m_right.HitTest(new Vector2(Input.mousePosition.x, Input.mousePosition.y))  && canJump )
					{
						RightMove();
					}
					if(Input.mousePosition.y > Screen.height/3  && canJump ) {
						JumpMove();
					}
					
				}
				
			}
		}
	}
	
	void LeftMove(){
		if(BadMove == false && transform.position.x>-4 ) 
			{				
					transform.Translate(-2,0,0);
			}
		else if(BadMove == true && transform.position.x<4)
			{
				transform.Translate(2,0,0);
			}
	}
	
	void RightMove(){
		if(BadMove == false && transform.position.x<4 )
			{
					transform.Translate(2,0,0);
			}
		else if(BadMove == true && transform.position.x>-4 )
			{
					transform.Translate(-2,0,0);
			}
	}
	
	void JumpMove(){
		transform.rigidbody.AddForce(transform.up * 270);
		m_Ani.Play("jump");
	}

	IEnumerator badstate() {
		BadMove = true;
		yield return new WaitForSeconds(5f);
		BadMove = false;
		
	}
	
	IEnumerator goodstate() {
		Make2.GoodItm = true;
		yield return new WaitForSeconds(10f);
		Make2.GoodItm = false;
		
	}
}

	
