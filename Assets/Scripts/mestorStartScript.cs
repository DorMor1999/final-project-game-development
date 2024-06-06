using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mestorStartScript : MonoBehaviour
{
    Animator animator;
    public GameObject player;//connect to player in unity
    AudioSource talkSound;
    bool isTalking = false; // Flag to track if NPC is already talking
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        talkSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        // Check if the player is within the specified distance and NPC is not already talking
        if (distance < 7 && !isTalking)
        {
            animator.SetInteger("State", 1); //talking

            if (talkSound != null && !talkSound.isPlaying)
            {
                talkSound.PlayDelayed(3);
                isTalking = true; // Set isTalking flag to true
            }

        }
        else if (distance >= 7 && isTalking) // If player is out of range and NPC is talking
        {
            animator.SetInteger("State", 0); // Stop talking animation
            talkSound.Stop(); // Stop the sound
            isTalking = false; // Set isTalking flag to false
        }
    }
}
