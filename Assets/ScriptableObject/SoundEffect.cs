using UnityEngine;

[CreateAssetMenu(fileName = "SoundEffect", menuName = "AudioManager/SoundEffect")]
public class SoundEffect : ScriptableObject
{
    public string label;
    public AudioClip clip;
}
