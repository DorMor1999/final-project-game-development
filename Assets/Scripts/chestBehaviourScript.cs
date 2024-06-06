using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class chestBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject chestOpen;
    public GameObject chestClose;
    public GameObject Coins;
    public GameObject player;
    public Text openText;
    public Text coinsText;
    public Text coinsAmountText;
    public bool afterOpen = false;
    public bool afterCoins = false;
    AudioSource sound;
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < 5)
        {
            if (!afterOpen)
            {
                openText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.O))
                {
                    chestClose.SetActive(false);
                    chestOpen.SetActive(true);
                    openText.gameObject.SetActive(false);
                    afterOpen = true;
                }
            }
            else
            {
                if (!afterCoins) {
                    coinsText.gameObject.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.C))
                    {
                        string coinAmountString = coinsAmountText.text.Split(' ')[1];
                        int numCoins = int.Parse(coinAmountString);
                        Coins.SetActive(false);
                        coinsText.gameObject.SetActive(false);
                        afterCoins = true;
                        sound.PlayDelayed(1);
                        coinsAmountText.text = "Gold: " + 1000000 + numCoins;
                    } 
                }
            }
        }
        else {
            openText.gameObject.SetActive(false);
            coinsText.gameObject.SetActive(false);
        }
        

    }
}
