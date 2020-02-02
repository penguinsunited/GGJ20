using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public GameObject leakAsset;
    public GameObject uwlAsset;
    GameObject leakClone;
    GameObject uwlClone;
    ParticleSystem lParticle;
    ParticleSystem uwlParticle;
    bool leakOn = false;
    bool uwLeakOn = false;
    
    public Transform gasTank;
    public GameObject waterObject;
    
    Pipes pipesClass;
    bool isUnderwater = false;
    
    void Start()
    {
        pipesClass = this.GetComponentInChildren<Pipes>();
        
        leakClone = Instantiate(leakAsset);
        leakClone.transform.parent = this.transform.GetChild(0).GetChild(0);
        leakClone.transform.localPosition = Vector3.zero;
        leakClone.transform.LookAt(gasTank);
        leakClone.SetActive(true);
        lParticle = leakClone.GetComponent<ParticleSystem>();
        
        uwlClone = Instantiate(uwlAsset);
        uwlClone.transform.parent = this.transform.GetChild(0).GetChild(0);
        uwlClone.transform.localPosition = Vector3.zero;
        leakClone.transform.LookAt(gasTank);
        uwlClone.SetActive(true);
        uwlParticle = uwlClone.GetComponent<ParticleSystem>();
        
        waterObject = GameObject.FindWithTag("Water");
        
    }

    // Update is called once per frame
    void Update()
    {
        //Normal leak
        if(pipesClass.HasBurst)
        {
            if(!leakOn)
            {
                lParticle.Play();
                leakOn = true;
            }
        }
        else
        {
            if(leakOn)
            {
                lParticle.Stop();
                leakOn = false;
            }
        }
        
        //leak when underwater
        if(pipesClass.HasBurst && isUnderwater)
        {
            if(!uwLeakOn)
            {
                uwlParticle.Play();
                uwLeakOn = true;
            }
        }
        else
        {
            if(uwLeakOn)
            {
                uwlParticle.Stop();
                uwLeakOn = false;
            }
        }
        
        //are the cracks underwater?
        if(waterObject.transform.position.y > 1.2f)
        {
            isUnderwater = true;
        }
    }
}
