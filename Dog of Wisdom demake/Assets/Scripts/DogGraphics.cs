using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class DogGraphics : MonoBehaviour
{
    [SerializeField] private AudioPlayer _borkingAudioPlayer;
    [SerializeField] private Sprite _normalSprite;
    [SerializeField] private Sprite _borkSprite;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _spriteRenderer.sprite = _borkingAudioPlayer.IsBorking
            ? _borkSprite
            : _normalSprite;
    }
}
