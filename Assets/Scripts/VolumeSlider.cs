using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{

    public void OnVolumeChanged(float volume)
    {
        AudioManager.Instance.SetVolume(volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }
}