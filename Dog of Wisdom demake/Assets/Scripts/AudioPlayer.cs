using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    internal bool IsBorking => _currentVolumeBeingPlayed > _borkVolumeThreshhold;

    [Header("Audio settings")]
    [SerializeField] private int _sampleRate = 1024;
    [SerializeField] private float _borkVolumeThreshhold = 0.2f;

    [Header("Subtitled audio to play")]
    [SerializeField] private SubtitledAudio[] _audioToPlay;

    private AudioSource _audioSource;

    private float _currentVolumeBeingPlayed;
    private float[] _samples;

    private void Awake()
    {
        _samples = new float[_sampleRate];
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _currentVolumeBeingPlayed = GetRMS(0) + GetRMS(1);
    }

    private float GetRMS(int channel)
    {
        _audioSource.GetOutputData(_samples, channel);

        float sum = 0;
        foreach (float f in _samples)
        {
            sum += f * f;
        }

        return Mathf.Sqrt(sum / _sampleRate);
    }
}
