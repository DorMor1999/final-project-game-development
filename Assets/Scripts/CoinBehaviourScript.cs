using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinBehaviourScript : MonoBehaviour
{
    public GameObject coins;
    public static int numCoins = 0;
    public Text coinText;
    public GameObject player;
    public bool exists = true;
    // Start is called before the first frame update
    void Start()
    {
        if (!exists) {
            gameObject.SetActive(false);    
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject) {
            numCoins++;
            coinText.text = "Gold: " + numCoins;
            exists = false;
            PersistentObjectManager.Instance.setHasCoin(false);
            gameObject.SetActive(false);
            AudioSource sound = coins.GetComponent<AudioSource>();
            sound.Play(); 
        }
    }
}
