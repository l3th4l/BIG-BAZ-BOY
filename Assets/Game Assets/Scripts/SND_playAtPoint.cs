using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SND_playAtPoint : MonoBehaviour {

    AudioSource source;
    public AudioClip[] clips;
    Vector3 myPos;
	// Use this for initialization
	void Start ()
    {
        myPos = gameObject.transform.position;
        AudioSource.PlayClipAtPoint(clips[Random.Range(0, clips.Length -1)], myPos);
    }
}
