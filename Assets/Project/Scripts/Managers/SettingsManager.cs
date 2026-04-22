using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private SoundMixerManager _soundMixerManager;
    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("VolumeMaster", _soundMixerManager._masterVolume);
        PlayerPrefs.SetFloat("VolumeSoundFx", _soundMixerManager._soundFxVolume);
        PlayerPrefs.SetFloat("VolumeMusic", _soundMixerManager._musicVolume);
    }

    public void LoadSettings()
    {
        _soundMixerManager._masterVolume = PlayerPrefs.GetFloat("VolumeMaster", 1);
        _soundMixerManager._soundFxVolume = PlayerPrefs.GetFloat("VolumeSoundFx", 1);
        _soundMixerManager._musicVolume = PlayerPrefs.GetFloat("VolumeMusic", 1);

        //_soundMixerManager.SetSlider(_soundMixerManager._sliderMaster, _soundMixerManager._masterVolume);
        //_soundMixerManager.SetSlider(_soundMixerManager._sliderSoundFx, _soundMixerManager._soundFxVolume);
        //_soundMixerManager.SetSlider(_soundMixerManager._sliderMusic, _soundMixerManager._musicVolume);
    }
}
