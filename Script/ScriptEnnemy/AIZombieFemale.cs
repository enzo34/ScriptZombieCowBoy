using UnityEngine;
using System.Collections;

public class AIZombieFemale : MonoBehaviour {

    public GameObject target;
    public float distance;
    public float RangeAttack = 5;
    public float speed = 0.5f;
    public AudioClip SoundDead, SoundHit;
    private Animator Anim;

	void Start () {
        Anim = GetComponent<Animator>();
	}
	
	void Update () {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance < RangeAttack)
        {
            Anim.SetBool("Walk", true);
            Attack();
        } else
        {
            Anim.SetBool("Walk", false);
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="Player")
        {
            Anim.SetTrigger("Dead");
            GetComponent<AudioSource>().PlayOneShot(SoundDead);
            GetComponent<AIZombieFemale>().enabled = false;
        }
    }

    public void DestroyGO()
    {
        Destroy(gameObject);
    }
}
