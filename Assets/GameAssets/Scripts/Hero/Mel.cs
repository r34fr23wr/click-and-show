using UnityEngine;

public class Mel : Hero
{
    [SerializeField] private float _repelForce = 5f;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Rigidbody2D otherRigidbody = other.collider.GetComponent<Rigidbody2D>();
        if(other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Vector2 repelDirection = (otherRigidbody.transform.position - transform.position).normalized;
            _rigidbody.AddForce(-repelDirection * _repelForce, ForceMode2D.Impulse);
            otherRigidbody.AddForce(repelDirection * _repelForce, ForceMode2D.Impulse);

            int enemyDamage = enemy.damage; int direction = Random.Range(-1,1);
            DamagePopup.Create(other.gameObject.transform.position, damage, -direction);
            enemy.TakeDamage(damage);
            DamagePopup.Create(transform.position, enemyDamage, direction);
            TakeDamage(enemyDamage);
        }
    }
}
