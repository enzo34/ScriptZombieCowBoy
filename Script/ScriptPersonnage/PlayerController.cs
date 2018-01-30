using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    // Déclarations de variables
    public int speed = 7;
    public int jump = 300;
    public bool isGrounded = false;

    public AudioClip soundJump;
    public AudioClip soundDead;

    private bool isJumping = false;

    private Animator Anim;
    private AudioSource Audio;

    // A l'initialisation du jeu
	void Start ()
    {
        Anim = GetComponent<Animator>();
        Audio = GetComponent<AudioSource>();
	}
	

    // Toute les frame
	void Update ()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * h * speed * Time.deltaTime);

        if(h > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            Anim.SetBool("Walk", true);
        }
        if(h < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            Anim.SetBool("Walk", true);
        }
        if(h == 0)
        {
            Anim.SetBool("Walk", false);
        }

        // Méthode temporaire pour tester la mort du personnage
        if (Input.GetKeyDown(KeyCode.O))
        {
            PlayerDead();
        }
	}


    //Pour lancer à un moment précis et éviter de surcharger le jeu
    void FixedUpdate ()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            Audio.PlayOneShot(soundJump);
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jump * Time.deltaTime;
            Anim.SetTrigger("Jump");
            Anim.SetBool("Walk", false);
        }
    }

    public void PlayerDead ()
    {
        Anim.SetTrigger("Dead");
        Audio.PlayOneShot(soundDead);
    }
}
