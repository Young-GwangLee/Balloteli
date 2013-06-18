using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour {

  public float scrollSpeed = 0.1f; //The speed the of the texture offset
	
    void Update()
	{
		//Make it smooth

	//강이 흘러가는 속도
        float offset = Time.time * scrollSpeed;
		
		//Set the texture offset //material에 속도 offset을 부여함
        renderer.material.mainTextureOffset = new Vector2(0,-offset);
    }
}
