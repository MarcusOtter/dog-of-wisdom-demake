using UnityEngine;

[CreateAssetMenu(menuName = "Subtitled audio")]
public class SubtitledAudio : ScriptableObject
{
    [SerializeField] [TextArea(0,2)] internal string Subtitles;
    [SerializeField] internal AudioClip AudioClip;

    // array of floats of when to open the mouth: when an audio plays? or maybe make that dynamic?

    internal float Duration => AudioClip.length;
}
