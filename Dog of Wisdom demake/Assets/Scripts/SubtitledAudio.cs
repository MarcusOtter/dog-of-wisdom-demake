using UnityEngine;

[CreateAssetMenu(menuName = "Subtitled audio")]
public class SubtitledAudio : ScriptableObject
{
    [Header("General settings")]
    [SerializeField] [TextArea(0,2)] internal string Subtitles;
    [SerializeField] internal AudioClip AudioClip;
    [SerializeField] [Range(0f, 1f)] internal float Volume = 1f;

    [Header("Delay")]
    [SerializeField] private float _delayToNextAudio = 0.3f;

    internal float Duration => AudioClip.length + _delayToNextAudio;
}
