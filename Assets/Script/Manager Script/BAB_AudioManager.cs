using UnityEngine.Audio;
using System;
using UnityEngine;

public class BAB_AudioManager : MonoBehaviour
{
    public BAB_Sound[] sounds;

    public static BAB_AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(BAB_Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.picth;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        BAB_Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

}
