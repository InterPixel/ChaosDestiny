using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicChange : MonoBehaviour {

	public AudioMixer MixerMusic;
	public Slider MusicSlider;


	public void SetMusicVol (float MusicVol){
		MixerMusic.SetFloat ("MusicVol", ((MusicSlider.value / 100 * 80)-80));
	}
}
