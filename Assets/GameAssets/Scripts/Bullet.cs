using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField, Range(0,15)] private float _moveSpeed;
    [SerializeField, Min(0.05f)] private float _distance;
    [SerializeField] private LayerMask _enemyLayer;

    private Enemy _targetEnemy;
    private int _damage;

    public void Setup(Enemy enemy, int damage)
    {
        _targetEnemy = enemy;
        _damage = damage;
    }

    private void Update()
    {
        if(!_targetEnemy) Destroy(gameObject);
        else
             transform.position = Vector2.MoveTowards(transform.position, _targetEnemy.transform.position, _moveSpeed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, _distance, _enemyLayer);
        if(hit)
        {
            if(hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.TakeDamage(_damage);
            }
            Destroy(gameObject);
        }
    }
}
