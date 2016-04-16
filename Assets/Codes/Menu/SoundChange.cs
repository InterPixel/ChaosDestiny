using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundChange : MonoBehaviour {

	public AudioMixer MixerSound;
	public Slider SoundSlider;

	public void SetSoundMixer (float SoundVol){
		MixerSound.SetFloat ("SoundVol", ((SoundSlider.value / 100 * 80)-80));
	}
}
