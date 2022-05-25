using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bottons : MonoBehaviour
{
    public AudioSource AudioSource;
	public AudioClip Clip;
	public SoundManager soundManager;

    public GameObject settingWindow;

    public GameObject loseWindow;

    public void setting(){
        soundManager.playDifferentSounds(AudioSource,Clip);
        settingWindow.SetActive(true);
        Time.timeScale=0;

    }
    public void NewSecne(){
      Invoke("NewSceneInvok",0.1f);
    }
    
    public void PlayAgain(){
        Time.timeScale=1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        settingWindow.SetActive(false);
        Score.totalScore=0;

    }
    public void close(){
        soundManager.playDifferentSounds(AudioSource,Clip);
        Time.timeScale=1;
        settingWindow.SetActive(false);
        settingWindow.SetActive(false);

    }
    public void NewSceneInvok(){
         soundManager.playDifferentSounds(AudioSource,Clip);
        Time.timeScale=1;
        SceneManager.LoadScene(1);
        settingWindow.SetActive(false);
        Score.totalScore=0;

    }
}
