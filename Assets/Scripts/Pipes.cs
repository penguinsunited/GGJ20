using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float countdownUntilBurst = 10.0f;
    
    public bool HasBurst { get { return hasBurst; }}
    
    [SerializeField]
    bool isBursting = false;
    [SerializeField]
    bool hasBurst = false;
    [SerializeField]
    bool isFixed = false;
    [SerializeField]
    bool isAudioOn = false;

    public AudioClip[] clips;
    private AudioSource[] AudSources;
    
    void Start()
    {
        AudSources = new AudioSource[3];
        
        for (int i = 0; i < 3; i++)
        {
            AudSources[i] = gameObject.AddComponent<AudioSource>();
            AudSources[i].clip = clips[i];
            AudSources[i].volume = 0.8f;
            AudSources[i].spatialBlend = 1.0f;
        }
        
        AudSources[0].loop = false;
        AudSources[1].loop = true;
        AudSources[2].loop = false;
    }
    

    // Update is called once per frame
    void Update()
    {
        //play about to burst sound
        if(countdownUntilBurst < 0)
        {
            isBursting = true;
            isFixed = false;
            if(!isAudioOn)
            {
                AudioPlay();
                BurstingToBurst();
                isAudioOn = true;
            }
        }
        
        if(MiniGameManager.crackIsFixed)
        {
            isFixed = true;
        }
        
        if(isFixed)
        {
            AudioPlayFixedPipes();
            countdownUntilBurst = Random.Range(10, 20.0f);
            isAudioOn = false;
        }
        countdownUntilBurst -= Time.deltaTime;
    }
    
    
    void AudioPlay()
    {
        if(isBursting)
        {
            AudSources[0].Play();
            AudSources[1].PlayScheduled(AudioSettings.dspTime + AudSources[0].clip.length);
        }
    }
    
    void AudioPlayFixedPipes()
    {
        //AudSources[1].Stop();
        AudSources[2].Play();
        
    }
    
    
    void BurstingToBurst()
    {
        isBursting = false;
        hasBurst = true;
    }
    
}
