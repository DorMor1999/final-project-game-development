using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawerBehaviourScript : MonoBehaviour
{
    public GameObject PlayerEye;
    public GameObject CrossHair;
    public GameObject CrossHairTouch;
    public Text openText;
    public Text closeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(PlayerEye.transform.position, PlayerEye.transform.forward, out hit)) {
            if (hit.collider == this.gameObject.GetComponent<Collider>())
            { // if ray hits the collider of the drawer
                CrossHair.gameObject.SetActive(false);
                CrossHairTouch.gameObject.SetActive(true);
                openText.gameObject.SetActive(true);
            }
            else {
                CrossHair.gameObject.SetActive(true);
                CrossHairTouch.gameObject.SetActive(false);
                openText.gameObject.SetActive(false);
            }
        }

    }
}
