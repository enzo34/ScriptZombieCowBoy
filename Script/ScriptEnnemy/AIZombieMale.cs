using UnityEngine;
using System.Collections;

public class AIZombieMale : MonoBehaviour {
    public Transform PtsA;
    public Transform PtsB;
    public float speed = 0.5f;
    private bool Retour = false;

    void Start () {
	
	}


    void Update () {
	    if (!Retour)
        {
            transform.position = Vector2.MoveTowards(transform.position, PtsB.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, PtsA.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name =="PtsA")
        {
            Retour = false;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (col.gameObject.name == "PtsB")
        {
            Retour = true;
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
