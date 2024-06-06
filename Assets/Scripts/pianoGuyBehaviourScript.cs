using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pianoGuyBehaviourScript : MonoBehaviour
{
    Animator animator;
    AudioSource pianoSound;
    public int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();// cnnect to unity component
        pianoSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (state == 0)
            {
                state = 1;
                animator.SetInteger("state", state);
                pianoSound.Play();
            }
            else {
                state = 0;
                animator.SetInteger("state", state);
                pianoSound.Stop();
            }
        }
    }
}
