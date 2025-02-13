using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.U2D;

public class Music : MonoBehaviour
{

    private AudioSource audioSource;
    public bool fadeOut = false;
    public int fadeOutTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeOut)
        {
            StartCoroutine(FadeMusic(audioSource));
        }
    }

    IEnumerator FadeMusic(AudioSource audioSource)
    {
        fadeOut = false;

        float tempVolume = audioSource.volume;

        while (tempVolume > 0)
        {
            tempVolume -= Time.deltaTime / fadeOutTime;
            audioSource.volume = tempVolume;
            yield return null;
        }
        audioSource.volume = tempVolume;
    }
}
