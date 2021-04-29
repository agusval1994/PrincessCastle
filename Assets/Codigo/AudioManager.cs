using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public string tema;

    public Sound[] sounds;

    public static AudioManager instance;

    AudioClip[] listaSonidos;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
    }

    private void Start()
    {
        Play(tema);
    }

    public void Play(string name)
    {
        //Sound s = Array.Find(sounds, sound => sound.name == name);

        Sound s = null;

        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == name)
            {
                s = sounds[i];

                int rand = Random.Range(0, s.listaDeSonidos.Length);
                s.source.clip = s.listaDeSonidos[rand];

                break;
            }
        }

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = null;

        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == name)
            {
                s = sounds[i];

                int rand = Random.Range(0, s.listaDeSonidos.Length);
                s.source.clip = s.listaDeSonidos[rand];

                s.source.Stop();

                break;
            }
        }
    }
}
