using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField, Range(0f,10f)] private float _moveSpeed;
    [SerializeField] private int _health;
    public int damage;

    private SpriteRenderer _spriteRenderer;
    public bool isSelected;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if(GameAssets.Instance.castle && 
        GameAssets.Instance.castle.transform.position.x < transform.position.x) Flip();
    }

    private void Update()
    {
        if(!GameAssets.Instance.castle) Destroy(gameObject);
        Collision();
        if(!isSelected)
            transform.position = Vector2.MoveTowards(transform.position, GameAssets.Instance.castle.transform.position, _moveSpeed * Time.deltaTime);
    }

    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            if(_health <= 0)
            {
                Die();
            }
        }
    }

    public virtual void TakeDamage(int damageValue)
    {
        Health -= damageValue;
    }

    public virtual void Die()
    {
        Money.AddMoney(5);
        Destroy(gameObject);
    }

    public virtual void Collision() {}

    private void Flip()
    {
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
