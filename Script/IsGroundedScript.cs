using UnityEngine;
using System.Collections;

public class IsGroundedScript : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col)
    {
        transform.parent.GetComponent<PlayerController>().isGrounded = true;
	}

    void OnTriggerExit2D (Collider2D col)
    {
        transform.parent.GetComponent<PlayerController>().isGrounded = false;
    }
}
