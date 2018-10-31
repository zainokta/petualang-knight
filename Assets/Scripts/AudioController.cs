using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour {
    public Slider volumeSlider;

    void Start(){
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
    }

	void Update()
    {
        AudioListener.volume = PlayerPrefsManager.GetMasterVolume();
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
	}
}
