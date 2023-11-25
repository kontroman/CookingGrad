using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Cysharp.Threading.Tasks;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Devotion.Scripts.Audio
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance { get; private set; }

        [SerializeField] private GameObject _musicObject;
        [SerializeField] private GameObject _musicPrefab;

        private AudioSource _musicAC;
        private AudioSource _soundAC;

        //TODO: move it to CONSTANTS
        private string _musicPath = "Audio/Music/";
        private string _soundPath = "Audio/Sounds/";

        private List<AudioClip> _loadedMusic = new List<AudioClip>();
        private List<AudioClip> _loadedSounds = new List<AudioClip>();

        private void Awake()
        {
            if(Instance != null)
            {
                return;
            }
            else
            {
                Instance = this;
                _musicObject = Instantiate(_musicPrefab);
                DontDestroyOnLoad(gameObject);
            }

            Init();
        }

        private void Start()
        {
            PlayMusic("TestMusic1");
        }

        private void Init()
        {
            if (_musicAC == null)
            {
                _musicObject = FindObjectOfType<MusicPrefab>().gameObject;

                if (_musicObject == null)
                    _musicObject = Instantiate(_musicPrefab);

                _musicAC = _musicObject.GetComponent<AudioSource>();
                _soundAC = _musicObject.transform.GetChild(0).GetComponent<AudioSource>();
            }

        }

        public async void PlayMusic(string musicName)
        {
            Init();

            AudioClip loadedClip = null;

            if(!_loadedMusic.Contains(_loadedMusic.Find(x => x.name == musicName)))
            {
                AsyncOperationHandle<AudioClip> handle = Addressables.LoadAssetAsync<AudioClip>(_musicPath + musicName);
                loadedClip = await handle;

                _loadedMusic.Add(handle.Result);
            }

            _musicAC.loop = true;
            _musicAC.clip = loadedClip;
            _musicAC.Play();
        }

        public async void PlaySound(string soundName)
        {
            Init();

            AudioClip loadedClip = null;

            if (!_loadedSounds.Contains(_loadedSounds.Find(x => x.name == soundName)))
            {
                AsyncOperationHandle<AudioClip> handle = Addressables.LoadAssetAsync<AudioClip>(_soundPath + soundName);
                loadedClip = await handle;

                _loadedSounds.Add(handle.Result);
            }

            _soundAC.loop = true;
            _soundAC.PlayOneShot(loadedClip);
        }
    }
}