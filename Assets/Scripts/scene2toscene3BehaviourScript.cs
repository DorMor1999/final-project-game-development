using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scene2toscene3BehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject fade;
    public Text coinsAmountText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        string coinAmountString = coinsAmountText.text.Split(' ')[1];
        int numCoins = int.Parse(coinAmountString);
        PersistentObjectManager.Instance.setGold(numCoins);

        Animator a = fade.GetComponent<Animator>();
        a.SetBool("startFadeIn", true);

        //delay 3 seconds
        yield return new WaitForSeconds(5);

        //start scene transition
        
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(3);
        }

    }
}
