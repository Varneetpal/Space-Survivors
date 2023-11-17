using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class Sound
{
    public string name; 
    public AudioClip clip;
    [Range(0f, 1f)] public float volume = 1f;
    [Range(0.1f, 3f)] public float pitch = 1f;
    public bool loop = false;
}

public class PlayerAudioManager : MonoBehaviour
{
    public List<Sound> sounds = new List<Sound>();
    private Dictionary<string, Sound> soundDictionary = new Dictionary<string, Sound>();
    private AudioSource audioSource;
    public static PlayerAudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        foreach (Sound sound in sounds)
        {
            soundDictionary.Add(sound.name, sound); // Updated from 'name' to 'soundName'
        }
    }

    public void PlaySound(string soundName)
    {
        if (soundDictionary.ContainsKey(soundName))
        {
            Sound sound = soundDictionary[soundName];
            audioSource.volume = sound.volume;
            audioSource.pitch = sound.pitch;
            audioSource.loop = sound.loop;
            audioSource.PlayOneShot(sound.clip);
        }
        else
        {
            Debug.LogWarning("Sound with name " + soundName + " not found!");
        }
    }

}
