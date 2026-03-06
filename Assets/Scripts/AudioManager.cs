using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance { get { return _instance; } }

    public int maxSounds;
    public GameObject soundPlayerPrefab;
    public Sound defaultMusic;
    public SoundPlayer musicPlayer;
    [NonSerialized] public SoundPlayer[] soundPlayers;

    private void Awake()
    {
        //singleton initialization
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }



        if (defaultMusic != null) SetMusic(defaultMusic);

        soundPlayers = new SoundPlayer[maxSounds];
        for (int i = 0; i < maxSounds; i++)
        {
            soundPlayers[i] = Instantiate(soundPlayerPrefab, transform).GetComponent<SoundPlayer>();
        }

        print(soundPlayers);

    }

    //should typically be used for non-spatial sounds since you can't pass in a position
    public void PlaySound(Sound sound)
    {
        PlayAudio(sound);
    }

    public void PlaySoundFromTransform(Sound sound, Transform target)
    {
        PlayAudio(sound, target);
    }

    void PlayAudio(Sound sound, Transform target = null)
    {
        bool queueFull = false;
        foreach (var player in soundPlayers)
        {
            if (!player.source.isPlaying)
            {
                player.SetFollowTarget(target);
                player.PlaySound(sound);

                break;
            }

            queueFull = true;
        }

        //if queue is full, do something about it like put sound in line to be played at next opening or smth idk
        if (queueFull)
        {
            //gfy ig
        }
    }

    public void SetMusic(Sound sound)
    {
        musicPlayer.PlaySound(sound);
    }
}
