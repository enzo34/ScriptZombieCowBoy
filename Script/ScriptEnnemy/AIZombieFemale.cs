using UnityEngine;
using System.Collections;

public class AIZombieFemale : MonoBehaviour {

    public GameObject target;
    public float distance;
    public float RangeAttack = 5;
    public float speed = 0.5f;
    public AudioClip SoundDead, SoundHit;

    private Animator Anim;
    private bool pause = false;
    private bool dead = false;

	void Start () {
        Anim = GetComponent<Animator>();
	}
	
	void Update () {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance < RangeAttack && !pause)
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
        if(col.gameObject.tag=="Player" && !dead)
        {
            Anim.SetTrigger("Dead");
            GetComponent<AudioSource>().PlayOneShot(SoundDead);
            dead = true;
            GetComponent<AIZombieFemale>().enabled = false;
        }
    }

    public void DestroyGO()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player" && !dead)
        {
            StartCoroutine(Hit(col.gameObject));
        }
    }

    IEnumerator Hit(GameObject col)
    {
        Debug.Log("Player touched");
        GetComponent<AudioSource>().PlayOneShot(SoundHit);
        pause = true;
        if (transform.position.x > target.transform.position.x)
        {
            col.GetComponent<Rigidbody2D>().velocity = (-Vector2.right * 200 * Time.deltaTime);
        }
        else
        {
            col.GetComponent<Rigidbody2D>().velocity = (Vector2.right * 200 * Time.deltaTime);
        }
        yield return new WaitForSeconds(1);
        pause = false;
    }
}
