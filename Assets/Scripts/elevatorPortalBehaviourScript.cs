using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class elevatorPortalBehaviourScript : MonoBehaviour
{
    public GameObject player;
    public GameObject fade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (player.gameObject == other.gameObject)
        {
            //Before scene change update amount gold
            PersistentObjectManager.Instance.setGold(CoinBehaviourScript.numCoins);
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                //move to scene 2
                SceneManager.LoadScene(2);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 2) {
                PersistentObjectManager.Instance.setAfterAssinment(true);
                //move to scene 1
                SceneManager.LoadScene(1);
            }
        }
    }*/



    private void OnTriggerEnter(Collider other)
    {
        if (player.gameObject == other.gameObject)
        {
            StartCoroutine(SceneTransition());
        }
    }

    IEnumerator SceneTransition()
    {
        //before scene change update the amount of gold
        PersistentObjectManager.Instance.setGold(CoinBehaviourScript.numCoins);

        Animator a = fade.GetComponent<Animator>();
        a.SetBool("startFadeIn", true);

        //delay 3 seconds
        yield return new WaitForSeconds(5);

        //start scene transition
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            //move to scene 2
            SceneManager.LoadScene(2);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(1);
        }

    }
}
