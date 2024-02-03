using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AudioManager : MonoBehaviour {
    private static AudioManager instance;

    public static AudioManager Instance{
        get{
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("AudioManager");
                    instance = go.AddComponent<AudioManager>();
                }
            }
            return instance;
        }
    }

    private AudioSource audioSource;
    void Awake(){
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    void Start(){
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = Resources.Load<AudioClip>("AudioTrack");
        audioSource.volume = PlayerPrefs.GetFloat("Volume");
        audioSource.Play();
    }
    public void SetVolume(float volume){
        audioSource.volume = volume;
    }
}