using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] TextMeshProUGUI buttonText;
    public List<SoundEffect> soundEffects;


    public static AudioManager instance;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public void Play(string label)
    {
        SoundEffect effect = soundEffects.Find(s => s.label == label);
        if (effect == null) return;
        audioSource.clip = effect.clip;
        buttonText.text = "Playing: " + label;
        audioSource.Play();
    }


}
