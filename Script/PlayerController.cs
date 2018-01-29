using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    // Déclarations de variables
    public int speed = 7;
    public int jump = 300;
    public bool isGrounded = false;

    private bool isJumping = false;
    private Animator Anim;

    // A l'initialisation du jeu
	void Start ()
    {
        Anim = GetComponent<Animator>();    
	}
	

    // Toute les frame
	void Update ()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * h * speed * Time.deltaTime);
	}


    //Pour lancer à un moment précis et éviter de surcharger le jeu
    void FixedUpdate ()
    {
        if(Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jump * Time.deltaTime;
        }
    }
}
