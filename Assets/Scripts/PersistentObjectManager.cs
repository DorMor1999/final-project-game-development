using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// based on Singleton
public class PersistentObjectManager : MonoBehaviour
{
    public static PersistentObjectManager Instance = null;
    private static int gold = 0;
    private static bool hasCoin = true;
    private Vector3 SpawnPoint;
    public Text goldText;
    public CoinBehaviourScript aCoin;
    public GameObject player;
    public static bool afterAssinment = false;
    public GameObject elavatorPortal;
    //runs before start
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else {
            Destroy(gameObject);
            if(SceneManager.GetActiveScene().buildIndex == 0) {
                player.transform.position = SpawnPoint;
                player.transform.Rotate(new Vector3(0, -90, 0));
            }
            else if (SceneManager.GetActiveScene().buildIndex == 1 && afterAssinment) {
                elavatorPortal.SetActive(false);
            }
            
        }
        goldText.text = "Gold: " + gold;
        aCoin.exists = hasCoin;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setGold(int num) { 
        gold = num;
    }

    public void setHasCoin(bool value) { 
        hasCoin = value;
    }

    public void setAfterAssinment(bool value) { 
        afterAssinment = value;
    }

    public void setSpawnPoint(Vector3 sp) {
        SpawnPoint = sp;
    }
}
