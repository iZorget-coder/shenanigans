using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsScript : MonoBehaviour
{
    public AudioMixer mixer;
    public void SetVolume(float volume)
    {
        mixer.SetFloat("volume", volume);
    }
}
