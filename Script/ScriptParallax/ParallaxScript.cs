using UnityEngine;
using System.Collections;

public class ParallaxScript : MonoBehaviour {

    private float offset;
    public GameObject Player;
    public int speed;
	
	void Update ()
    {
        offset = Player.transform.position.x / speed;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
