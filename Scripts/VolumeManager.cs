using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider SFXSlider;
    public AudioSource SFXSample;

    void Awake()
    {
        audioMixer.GetFloat("MusicVolume", out float musicVal);
        musicSlider.value = Mathf.Pow(10, musicVal/20);
        audioMixer.GetFloat("SFXVolume", out float SFXVal);
        SFXSlider.value = Mathf.Pow(10, SFXVal/20);
    }

    public void SetMusicVolume(float vol)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(vol)*20);
    }
    public void SetSFXVolume(float vol)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(vol)*20);
    }

    public void TestSFXVolume()
    {
        SFXSample.Play();
    }
}
