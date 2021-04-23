using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class usezip : MonoBehaviour
{
    public GameObject textprompt;
    public GameObject cube;
    private GameObject mPlayer;
    private bool inrange;
    private bool isdestroyed;
    public GameObject c1, c2, c3, aud;
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
                if (!mPlayer.GetComponent<PlayerController>().zip) return;
                //Destroy(cube);
                textprompt.SetActive(false);
                mPlayer.SendMessage("usezip");
                c1.SendMessage("ActivateZipline");
                c2.SendMessage("ActivateZipline");
                c3.SendMessage("ActivateZipline");
                aud.SetActive(true);
                //SoundMgr.instance.PlaySoundOneShot(SoundMgr.instance.zipline);
                isdestroyed = true;
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (isdestroyed) return;
        if (collision.gameObject.tag == "Player")
        {
            if(!mPlayer.GetComponent<PlayerController>().zip)
            {
                textprompt.SetActive(true);
                textprompt.GetComponent<TextMeshProUGUI>().color = Color.red;
            }
            else
            {
                textprompt.SetActive(true);
                textprompt.GetComponent<TextMeshProUGUI>().color = Color.white;
            }
            
            inrange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (isdestroyed) return;
        if (other.gameObject.tag == "Player")
        {
            inrange = false;
            if(!mPlayer.GetComponent<PlayerController>().isZipping)
            textprompt.SetActive(false);
        }
    }
}
