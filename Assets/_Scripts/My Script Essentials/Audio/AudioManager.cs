using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource _musicSource, _musicSource2, _sfxSource;

    private bool _firstMusicSourceIsPlaying;
    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }

    public void PlayMusic(AudioClip clip)
    {
        _musicSource.PlayOneShot(clip);
    }

    public void PlayMusicWithFade(AudioClip clip, float transitionTime = 1.0f)
    {
        AudioSource activeSource = (_firstMusicSourceIsPlaying) ? _musicSource : _musicSource2;
        StartCoroutine(UpdateMusicWithFade(activeSource, clip, transitionTime));
    }

    public void PlayMusicWithCrossFade(AudioClip audioClip, float transitionTime = 1.0f)
    {
        AudioSource activeSource = (_firstMusicSourceIsPlaying) ? _musicSource : _musicSource2;
        AudioSource newSource = (_firstMusicSourceIsPlaying) ? _musicSource2 : _musicSource;

        _firstMusicSourceIsPlaying = !_firstMusicSourceIsPlaying;

        newSource.clip = audioClip;
        newSource.Play();
        StartCoroutine(UpdateMusicWithCrossFade(activeSource, newSource, transitionTime));
    }

    private IEnumerator UpdateMusicWithFade(AudioSource activeSource,  AudioClip clip, float transitionTime)
    {
        if (!activeSource.isPlaying) activeSource.Play();

        float t = 0.0f;

        for (t = 0; t < transitionTime; t += Time.deltaTime)
        {
            activeSource.volume = (1 - (t / transitionTime));
            yield return null;
        }

        activeSource.Stop();
        activeSource.clip = clip;
        activeSource.Play();
    }

    private IEnumerator UpdateMusicWithCrossFade(AudioSource original, AudioSource newSource, float transitionTime)
    {
        float t = 0.0f;

        for (t = 0.0f; t < transitionTime; t += Time.deltaTime)
        {
            original.volume = (1 - (t / transitionTime));
            newSource.volume = (t / transitionTime);
            yield return null;
        }

        original.Stop();
    }

    public void PlaySFX(AudioClip clip)
    {
        _sfxSource.PlayOneShot(clip);
    }

    public void PlaySFX(AudioClip clip, float volume)
    {
        _sfxSource.PlayOneShot(clip, volume);
    }
}
 