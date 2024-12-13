using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioClip sliderReleaseSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (!PlayerPrefs.HasKey("soundVolume"))
        {
            PlayerPrefs.SetFloat("soundVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    public void PlayReleaseSound()
    {
        if (audioSource != null && sliderReleaseSound != null)
        {
            audioSource.PlayOneShot(sliderReleaseSound, volumeSlider.value);
        }
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("soundVolume", volumeSlider.value);
    }
}
