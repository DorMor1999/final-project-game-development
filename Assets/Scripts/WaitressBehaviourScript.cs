using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaitressBehaviourScript : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    public GameObject target;
    public GameObject point1;
    public GameObject point2;
    bool goes_to_pt1 = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();//connection to unity component
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if(Input.GetKeyDown(KeyCode.Q)) {
            animator.SetInteger("State", 1);
            //compute the path to the target and start moving npc towrds the target
            agent.SetDestination(target.transform.position);
            if (agent.isStopped) { 
                agent.isStopped = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.X) || distance < 2)
        {
            animator.SetInteger("State", 0);
            agent.isStopped = true;
        }
        if (distance < 3) {//goes constantly from pt1 to pt2 and back
            if (goes_to_pt1)
            {
                target.transform.position = point2.transform.position;
                goes_to_pt1 = false;
                //compute the path
                agent.SetDestination(target.transform.position);
            }
            else {
                target.transform.position = point1.transform.position;
                goes_to_pt1 = true;
                //compute the path 
                agent.SetDestination(target.transform.position);
            }
        }
    }
}
