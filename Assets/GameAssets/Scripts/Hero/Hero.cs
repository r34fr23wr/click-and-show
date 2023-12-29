using UnityEngine;

public class Hero : MonoBehaviour, IDamageable
{
    [SerializeField, Range(0f,10f)] private float _moveSpeed;
    [SerializeField] private int _health;
    [SerializeField] private float _agroRadius;
    [SerializeField] private LayerMask _enemyLayer;

    public int damage;

    private Enemy _targetEnemy;
    private SpriteRenderer _spriteRenderer;
    public bool _facingRight = false;
    public bool isSelected;

    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        FindEnemies();
        Move();
        HandlerFlip();
    }

    private void Move()
    {
        if(_targetEnemy && !isSelected)
            transform.position = Vector2.MoveTowards(transform.position, _targetEnemy.transform.position, _moveSpeed * Time.deltaTime);
    }

    private void HandlerFlip()
    {
        if(!_targetEnemy) return;
        if(!_facingRight && _targetEnemy.transform.position.x > transform.position.x)
            Flip();
        else if(_facingRight && _targetEnemy.transform.position.x < transform.position.x)
            Flip();
    }

    private void FindEnemies()
    {
        if(_targetEnemy) return;
        
        Collider2D collider = Physics2D.OverlapCircle(transform.position, _agroRadius, _enemyLayer);

        if(collider && collider.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _targetEnemy = enemy;
        }
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
        Destroy(gameObject);
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _agroRadius);
    }
    
}
