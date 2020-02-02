using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float countdownUntilBurst = 10.0f;
    
    public bool IsBurst { get { return isBurst; }}
    
    [SerializeField]
    bool isBurst = false;
    [SerializeField]
    bool isFixed = false;
    [SerializeField]
    bool isAudioOn = false;
    
//    [SerializeField]
//    private AudioClip pipeThreatening = default;
//    [SerializeField]
//    private AudioClip pipeLeaking = default;
//    [SerializeField]
//    private AudioClip pipeFixed = default;

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
        if(countdownUntilBurst < 0)
        {
            isBurst = true;
            if(!isAudioOn)
            {
                AudioPlay();
                isAudioOn = true;
            }
        }
        if(isFixed)
        {
            AudioPlayFixedPipes();
            countdownUntilBurst = Random.Range(0, 10.0f);
            isAudioOn = false;
        }
        countdownUntilBurst -= Time.deltaTime;
    }
    
    void AudioPlay()
    {
        if(isBurst)
        {
            AudSources[0].Play();
            AudSources[1].PlayScheduled(AudioSettings.dspTime + AudSources[0].clip.length);
        }
    }
    
    void AudioPlayFixedPipes()
    {
        AudSources[1].Stop();
        AudSources[2].Play();
    }
    
    
}
