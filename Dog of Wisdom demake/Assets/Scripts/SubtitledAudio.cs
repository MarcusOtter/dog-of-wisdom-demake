using UnityEngine;

[CreateAssetMenu(menuName = "Subtitled audio")]
public class SubtitledAudio : ScriptableObject
{
    [SerializeField] [TextArea(0,2)] internal string Subtitles;
    [SerializeField] internal AudioClip AudioClip;
    [SerializeField] private float _delayToNextAudio = 0.3f;

    internal float Duration => AudioClip.length + _delayToNextAudio;
}
