using UnityEngine;
using UnityEngine.UI;

public class SoundEffectManager : MonoBehaviour
{
    private static SoundEffectManager instance;

    private static AudioSource audioSourse;
    private static SoundEffects soundEffect;
    [SerializeField] private Slider sfxSlider;

    private void Awake() //this is a use of Singleton because only one instance of sound manger can exist
    {
        if (instance == null)
        {
            instance = this;
            audioSourse = GetComponent<AudioSource>();
            soundEffect = GetComponent<SoundEffects>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void Play(string soundName)
    {
        AudioClip audioClip = soundEffect.GetRandomClip(soundName);
        if (audioClip != null)
        {
            audioSourse.PlayOneShot(audioClip);

        }
    }
    private void Start()
    {
        sfxSlider.onValueChanged.AddListener(delegate { OnValueChanged(); });
    }

    public static void SetVolume(float volume)
    {
        audioSourse.volume = volume;
    }
    public void OnValueChanged()
    {
        SetVolume(sfxSlider.value);
    }
}
