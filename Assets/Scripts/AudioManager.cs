using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource musicSource, effectsSource;

    [SerializeField] UnityEngine.UI.Slider masterVolume, effectsVolume, musicVolume;

    [SerializeField] AudioClip testClip;

    [SerializeField] bool playSFX = true;
    [SerializeField] UnityEngine.UI.Image redplaySFXImage;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else { Destroy(this.gameObject); }
    }

    private void Start()
    {
        redplaySFXImage.gameObject.SetActive(false);
    }
    public void PlaySound(AudioClip clip, bool loop = false)
    {
        if (loop)
        {
            effectsSource.clip = clip;
            effectsSource.loop = true;
            effectsSource.Play();
        }
        else
        {
            effectsSource.PlayOneShot(clip);
        }
    }

    public void StopSound(AudioClip clip)
    {
        effectsSource.Stop();
    }

    public void ChangeMasterVolume()
    {
        AudioListener.volume = masterVolume.value;
      
    }

    
  public void MusicVolume()
    {
        musicSource.volume = musicVolume.value;
    
    }
    public void EffectsVolume()
    {
        effectsSource.volume = effectsVolume.value;
        if(!effectsSource.isPlaying && playSFX)
        {
            PlaySound(testClip, false);
        }
       
        
    }

    public void FlipPlaySFXButton()
    {
        playSFX = !playSFX;
        redplaySFXImage.gameObject.SetActive(!playSFX);
    }
    
}