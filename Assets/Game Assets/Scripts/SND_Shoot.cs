using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SND_Shoot : MonoBehaviour {

    public AudioClip[] clips;
    AudioSource source;
    // Use this for initialization
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = clips[Random.Range(0, clips.Length)];
        source.PlayOneShot(source.clip);
    }

    // Update is called once per frame

    void Update() { 	
	}
}
