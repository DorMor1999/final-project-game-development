using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joeEnd : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    public GameObject player;
    public GameObject playerHummer;
    AudioSource talkSound;
    bool isTalking = false; // Flag to track if NPC is already talking
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
            Vector3 target_dir = player.transform.position - transform.position;
            target_dir.y = 0;
            Vector3 temp_dir = Vector3.RotateTowards(transform.forward, target_dir, Time.deltaTime, 0);
            transform.rotation = Quaternion.LookRotation(temp_dir);
            animator.SetInteger("State", 1); //talking

            if (talkSound != null && !talkSound.isPlaying)
            {
                talkSound.PlayDelayed(2);
                isTalking = true; // Set isTalking flag to true
                playerHummer.SetActive(false);
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
