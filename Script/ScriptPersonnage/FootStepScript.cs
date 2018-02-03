using UnityEngine;
using System.Collections;

public class FootStepScript : MonoBehaviour {

    public AudioClip soundFootSteps;
    public float PitchMin = 1f;
    public float PitchMax = 1.5f;
    public float VolMin = 0.2f;
    public float VolMax = 0.5f;

    private AudioSource Audio;

	void Start ()
    {
        Audio = GetComponent<AudioSource>();
	}
	
	void Update ()
    {
	    if (Input.GetAxis("Horizontal") != 0)
        {
            if (!Audio.isPlaying && transform.parent.GetComponent<PlayerController>().isGrounded)
            {
                Audio.pitch = Random.Range(PitchMin, PitchMax);
                Audio.volume = Random.Range(VolMin, VolMax);
                Audio.PlayOneShot(soundFootSteps);
            }
        }
	}
}
