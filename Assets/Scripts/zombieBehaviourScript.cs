using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombieBehaviourScript : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    public GameObject point1;
    public GameObject point2;
    bool goes_to_pt1 = true;
    public GameObject hammerPlayer;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();//connection to unity component
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check the distance to the current target
        float distanceToTarget = Vector3.Distance(transform.position, agent.destination);

        // If the NPC is very close to the current target
        if (distanceToTarget < 1.5 && !isDead)
        {
            // Switch to the other point
            if (goes_to_pt1)
            {
                agent.SetDestination(point2.transform.position);
            }
            else
            {
                agent.SetDestination(point1.transform.position);
            }

            // Toggle goes_to_pt1 for the next iteration
            goes_to_pt1 = !goes_to_pt1;
        }

        // Check if the left mouse button is held down
        if (Input.GetMouseButton(0)) // 0 for left mouse button, 1 for right, 2 for middle
        {
            PerformAttack();
        }
        else {
            if (hammerPlayer != null && hammerPlayer.activeSelf)
            {
                // Get the Animator component from the hammerPlayer
                Animator hammerAnimator = hammerPlayer.GetComponent<Animator>();
                if (hammerAnimator != null)
                {
                    hammerAnimator.SetBool("attack", false);   
                }
            }
        }
    }

    // Method to perform attack action
    void PerformAttack()
    {
        // Check if the hammerPlayer is not null and active
        if (hammerPlayer != null && hammerPlayer.activeSelf)
        {
            // Get the Animator component from the hammerPlayer
            Animator hammerAnimator = hammerPlayer.GetComponent<Animator>();
            if (hammerAnimator != null)
            {
                // Trigger the attack animation on the hammerPlayer
                AudioSource soundHammer = hammerPlayer.gameObject.GetComponent<AudioSource>();
                soundHammer.PlayDelayed(0);
                hammerAnimator.SetBool("attack", true);
                float distanceToHammerPlayer = Vector3.Distance(transform.position, hammerPlayer.transform.position);
                if (distanceToHammerPlayer < 5 && !isDead) {
                    AudioSource sound = gameObject.GetComponent<AudioSource>();
                    sound.PlayDelayed(2);
                    isDead = true;
                    animator.SetBool("dead", isDead);
                    agent.isStopped = true;
                }
                // Add your attack logic here
            }
        }
    }
}
