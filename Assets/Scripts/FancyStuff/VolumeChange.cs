using System;
using DataBase;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace FancyStuff
{
    public class VolumeChange : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private Slider slider;
        [SerializeField] private GameObject pauseMenu;

        private void Start()
        {
            if (!slider) slider = GetComponent<Slider>();
            slider.value = Preferences.GetVolume();
            SetVolume(Preferences.GetVolume());
            pauseMenu.SetActive(false);
        
        
        }

        public void SetVolume(float volume)
        {
            audioMixer.SetFloat("Volume", (float)(Math.Log10(volume) * 20));
            Preferences.SetVolume(volume);
        }
    }
}
