using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    public AudioMixer _audioMixer;
    [SerializeField] private SettingsManager _settingManager;
    //[SerializeField] public Slider _sliderMaster;
    //[SerializeField] public Slider _sliderSoundFx;
    //[SerializeField] public Slider _sliderMusic;

    public float _masterVolume;
    public float _soundFxVolume;
    public float _musicVolume;

    private void Start()
    {
        _settingManager.LoadSettings();

        //SetSlider(_sliderMaster, _masterVolume);
        //SetSlider(_sliderSoundFx, _soundFxVolume);
        //SetSlider(_sliderMusic, _musicVolume);
    }
    public void SetMasterVolume (float volume)
    {
        _masterVolume = volume;
        _audioMixer.SetFloat("MasterVolume", Mathf.Log10(_masterVolume) * 20f);
    }

    public void SetSoundFxVolume(float volume)
    {
        _soundFxVolume = volume;
        _audioMixer.SetFloat("SoundFxVolume", Mathf.Log10(_soundFxVolume) * 20f);
    }

    public void SetMusicVolume(float volume)
    {
        _musicVolume = volume;
        _audioMixer.SetFloat("MusicVolume", Mathf.Log10(_musicVolume) * 20f);
    }

    //public void SetSlider(Slider channel, float volume)
    //{
    //    channel.value = volume;
    //}
}
