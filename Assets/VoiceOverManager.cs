using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverManager : MonoBehaviour
{
    public AudioClip[] sequence;
    public AudioSource source;
    public int seqIndex;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
        seqIndex = 0;
    }
    private void Start()
    {
        source.clip = sequence[seqIndex];
        source.Play();
    }
    public void PlayNextVoice()
    {
        seqIndex++;
        if (source.isPlaying)
        {
            source.Stop();
            source.clip = sequence[seqIndex];
            source.Play();
        }
        else source.Play();

    }

    public void StartPlaying() => source.Play();
}
