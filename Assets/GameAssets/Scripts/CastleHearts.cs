using UnityEngine;
using UnityEngine.UI;

public class CastleHearts : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] _heartSprites;
    [SerializeField] private Animator _animator;
    
    public void UpdateHeartImage(int currentHealth)
    {
        EnableAnimator();
        _spriteRenderer.sprite = _heartSprites[currentHealth];
    }

    public void EnableAnimator()
        => _animator.enabled = true;

    public void DisableAnimator()
        => _animator.enabled = false;
}
