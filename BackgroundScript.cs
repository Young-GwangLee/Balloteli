using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour {

  public float scrollSpeed = 0.1f; //The speed the of the texture offset
	
    void Update()
	{
		//Make it smooth

        float offset = Time.time * scrollSpeed;
		
		//Set the texture offset
        renderer.material.mainTextureOffset = new Vector2(0,-offset);
    }
}
