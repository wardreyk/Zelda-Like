using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class BAB_Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float picth;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

}
