using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void open()
    {
        animator.SetBool("isOpen", true);
        SoundMgr.instance.PlaySoundOneShot(SoundMgr.instance.pickup);
    }
}
