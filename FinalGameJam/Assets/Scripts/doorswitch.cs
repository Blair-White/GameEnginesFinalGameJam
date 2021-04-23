using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorswitch : MonoBehaviour
{
    public GameObject textprompt;
 
    private GameObject mPlayer;
    public GameObject door;
    private bool inrange;
    private bool isdestroyed;
    // Start is called before the first frame update
    void Start()
    {
        mPlayer = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (inrange)
        {
            if (InputManager.Instance.Interacted())
            {

                //Destroy(cube);
                SoundMgr.instance.PlaySoundOneShot(SoundMgr.instance.pickup);
                textprompt.SetActive(false);
                door.SendMessage("open");
                isdestroyed = true;
                inrange = false;
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (isdestroyed) return;
        if (collision.gameObject.tag == "Player")
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
