using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public AudioSource eggOneAudioSource, eggTwoAudioSource, eggThreeAudioSource;
    public void PlayEggSFX()
    {
        var sfxToPlay = Random.Range(0, 2);
        if (sfxToPlay == 1)
        {
            eggTwoAudioSource.Play();
        }
        else
        {
            eggOneAudioSource.Play();
        }
        
    }
    public void PlayBopSFX()
    {
        eggThreeAudioSource.Play();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
