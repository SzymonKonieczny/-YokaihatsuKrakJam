using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    public AudioSource tesciowa;
    public AudioSource panna;
    public AudioSource AudioSourcePref;
    public List<ItemAudio> audios;

    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        tesciowa.volume = 0;
        panna.volume = 0;
    }

    public void PlayItemMusic(ItemID id, Vector3 pos)
    {
        var instance = Instantiate(AudioSourcePref, pos, Quaternion.identity);
        instance.clip = audios.Find(p => p.id == id).clip;
        Destroy(instance.gameObject, 4f);
    }

    public void PlayMusic(PlayerType type)
    {
        if (type == PlayerType.Panna)
        {
            tesciowa.volume = 0;
            panna.volume = 1;
        }
        else
        {
            tesciowa.volume = 1;
            panna.volume = 0;
        }
    }

    [Serializable]
    public struct ItemAudio
    {
        public ItemID id;
        public AudioClip clip;
    }
}
