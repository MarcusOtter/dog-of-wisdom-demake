using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    internal bool IsBorking => _currentVolumeBeingPlayed > _borkVolumeThreshhold;

    [Header("Audio settings")]
    [SerializeField] private int _sampleRate = 4096;
    [SerializeField] private float _borkVolumeThreshhold = 0.05f;

    [Header("Subtitled audio to play")]
    [SerializeField] private float _initialDelay;
    [SerializeField] private SubtitledAudio[] _audioToPlay;

    private AudioSource _audioSource;

    private float _currentVolumeBeingPlayed;
    private float[] _samples;

    private void Awake()
    {
        _samples = new float[_sampleRate];
        _audioSource = GetComponent<AudioSource>();

        StartCoroutine(PlaySubtitledAudio());
    }

    private IEnumerator PlaySubtitledAudio()
    {
        yield return new WaitForSeconds(_initialDelay);

        foreach (var audio in _audioToPlay)
        {
            _audioSource.PlayOneShot(audio.AudioClip);
            yield return new WaitForSeconds(audio.Duration);
        }
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
