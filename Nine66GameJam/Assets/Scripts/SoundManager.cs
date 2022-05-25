using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{	
    [SerializeField] private AudioSource audioSource;
    //[SerializeField] private AudioSource bgMusic;

	private bool isPlayed = false;
    private bool isDoorSound = false;

    public void playSound(AudioClip sound)
    {
		if (!isPlayed)
		{
            //bgMusic.volume = 0.5f;
            audioSource.PlayOneShot(sound);
            isPlayed = true;
            StartCoroutine(restartBGMusic());
        }
        StopCoroutine(restartBGMusic());
    }

    public void playDifferentSounds(AudioSource source, AudioClip clip)
	{
        if (!isPlayed) 
        { 
            source.PlayOneShot(clip);
            isPlayed = true;
            StartCoroutine(restartBGMusic());
        }
        StopCoroutine(restartBGMusic());
    }
    public void playDifferentSounds1(AudioSource source, AudioClip clip)
	{
        if (!isPlayed) 
        { 
            source.PlayOneShot(clip);
            isPlayed = true;
            StartCoroutine(restartBGMusic1());
        }
        StopCoroutine(restartBGMusic1());
    }

    private IEnumerator restartBGMusic()
	{
       
        //bgMusic.volume = 1; ;
        yield return new WaitForSeconds(.5f);
        isPlayed = false;
        isDoorSound = false;
	}
    private IEnumerator restartBGMusic1()
	{
       
        //bgMusic.volume = 1; ;
        yield return new WaitForSeconds(0.1f);
        isPlayed = false;
        isDoorSound = false;
	}
}
