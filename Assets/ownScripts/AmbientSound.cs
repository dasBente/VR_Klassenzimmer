using System;
using UnityEngine;

public class AmbientSound : MonoBehaviour {
    private int CurrentNoiseLevel;

    private float[] NoiseLevels = { 0.5f, 0.7f, 0.8f, 1.0f };
    public AudioClip[] NoiseLevelAudio;
    private AudioSource source;

    void Start()
    {
        CurrentNoiseLevel = 0;
        source = GetComponent<AudioSource>();
        source.enabled = true;
        source.Play();
    }

    public void SoundLevel(bool up)
    {
        string currClip = source.clip.name;

        CurrentNoiseLevel += up ? 1 : -1;
        if (CurrentNoiseLevel < 0)
            CurrentNoiseLevel = 0;
        else if (CurrentNoiseLevel >= NoiseLevels.Length)
            CurrentNoiseLevel = NoiseLevels.Length - 1;

        Debug.Log("Audio Level: " + CurrentNoiseLevel);
        source.volume = NoiseLevels[CurrentNoiseLevel];
        source.clip = NoiseLevelAudio[CurrentNoiseLevel];
        if (source.clip.name != currClip) source.Play();
    }
}
