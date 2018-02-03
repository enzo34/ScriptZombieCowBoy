using UnityEngine;
using System.Collections;

public class AIZombieFemale : MonoBehaviour {

    public GameObject target;
    public float distance;
    public float RangeAttack = 5;
    public float speed = 0.5f;
    private Animator Anim;

	void Start () {
        Anim = GetComponent<Animator>();
	}
	
	void Update () {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance < RangeAttack)
        {
            Attack();
        }

        if (transform.position.x > target.transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
	}

    void Attack()
    {
        transform.position = Vector2.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
