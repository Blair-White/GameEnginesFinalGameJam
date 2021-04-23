using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doublejumppickup : MonoBehaviour
{
    public GameObject textprompt;
    public GameObject cube;
    private bool inrange;
    private bool isdestroyed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inrange)
        {
            if (InputManager.Instance.Interacted())
            {
                Destroy(cube);
                
                textprompt.SetActive(false);
                GameObject.Find("Player").SendMessage("pickupjump");
                isdestroyed = true;
                inrange = false;
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (isdestroyed) return;
        if(collision.gameObject.tag == "Player")
        {
            textprompt.SetActive(true);
            inrange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (isdestroyed) return;
        if (other.gameObject.tag == "Player")
        {
            inrange = false;
            textprompt.SetActive(false);
        }
    }
}
