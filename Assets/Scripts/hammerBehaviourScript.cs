using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hammerPlayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        hammerPlayer.SetActive(true);
    }
}
