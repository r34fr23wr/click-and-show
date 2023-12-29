using System.Collections;
using UnityEngine;
using System;

public class Castle : MonoBehaviour, IDamageable, ICastle
{
    [SerializeField] private CastleHearts _castleHearts;
    [SerializeField] private GameObject _radiusCircle;
    [Space]

    [SerializeField] private int _health;
    public int damage;
    [Space]

    [SerializeField] private Bullet _bullet;
    public float fireCooldown;
    [SerializeField, Min(0f)] private float _fireRange;
    [SerializeField] private LayerMask _enemyLayer;

    public event Action Kill;

    private Enemy _targetEnemy;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        StartCoroutine(Fire());
    }

    #region Interface

    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            _castleHearts.UpdateHeartImage(_health);
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
        Kill?.Invoke();
    }

    #endregion

    private void Update()
    {
        FindEnemies();
    }

    private IEnumerator Fire()
    {
        yield return new WaitForSeconds(fireCooldown);
        if(_targetEnemy)
        {
            Bullet currentBulet = Instantiate(_bullet, transform.position, Quaternion.identity);
            currentBulet.Setup(_targetEnemy, damage);
        }

        StartCoroutine(Fire());
    }

    private void FindEnemies()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, _fireRange, _enemyLayer);

        if(collider && collider.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _targetEnemy = enemy;
        }
    }

    public void ToggleSelected(bool value)
    {
        _radiusCircle.SetActive(value);
        GameAssets.Instance.castleUpgrader.ToggleVisibility(value);
    }

    public void EnableAnimator()
        => _animator.enabled = true;

    public void DisableAnimator()
        => _animator.enabled = false;
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _fireRange);
    }
}

public interface ICastle
{
    public event Action Kill;
}