using UnityEngine;
using System.Collections;

public class CameraParallax : MonoBehaviour {

    public GameObject Player;
	
	void Update ()
    {
        transform.position = new Vector3(Player.transform.localPosition.x, transform.position.y, transform.position.z);	
	}
}
