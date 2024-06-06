using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class keyBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject keys;
    private static bool hasKey = false;
    public Text keyText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        hasKey = true;
        keyText.text = "Key collected";
        gameObject.SetActive(false);
        AudioSource sound = keys.gameObject.GetComponent<AudioSource>();
        sound.Play();

    }
}
