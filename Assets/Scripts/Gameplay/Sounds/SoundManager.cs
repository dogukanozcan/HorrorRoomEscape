using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    private AudioSource audioSource2D;
    private List<AudioClip> clips;

    private void Awake()
    {
        clips = Resources.LoadAll<AudioClip>("Sounds").ToList();
        Debug.Log(clips.Count + " Clips loaded!");
        audioSource2D = GetComponent<AudioSource>();
    }
    public void PlayClip(string name)
    {
        var clip = GetClip(name);
        audioSource2D.PlayOneShot(clip);
    }

    public void PlayClip3D(string name, Vector3 position)
    {
        var clip = GetClip(name);
        
        AudioSource.PlayClipAtPoint(clip, position);
    }

    private AudioClip GetClip(string name) 
    {
        var clip = clips.Find(x => x.name.ToLower() == name.ToLower());
        if (clip == null)
        {
            Debug.Log(name + " not found!");
        }

        return clip;
    }
   
}
