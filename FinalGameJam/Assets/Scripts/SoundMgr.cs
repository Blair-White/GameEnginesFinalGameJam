using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
    public static SoundMgr instance = null;
    public AudioClip pickup, zipline, jump;
    public AudioSource AudSrc;
    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void PlaySoundOneShot(AudioClip clip)
    {
        AudSrc.PlayOneShot(clip);
    }
}
