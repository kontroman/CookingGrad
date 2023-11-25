using UnityEngine;
using UnityEngine.Audio;

namespace Devotion.Scripts.Audio
{
    public class MusicPrefab : MonoBehaviour
    {
        [SerializeField] private AudioSource _musicAC;
        [SerializeField] private AudioSource _soundAC;
        [SerializeField] private AudioMixerGroup _mixer;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void OnEnable()
        {
            _musicAC.outputAudioMixerGroup = _mixer;
            _soundAC.outputAudioMixerGroup = _mixer;
        }
    }
}