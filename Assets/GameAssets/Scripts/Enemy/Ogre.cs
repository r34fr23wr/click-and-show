using UnityEngine;

public class Ogre : Enemy
{
    [SerializeField, Min(0.05f)] private float _distance;
    [SerializeField] private LayerMask _targetLayer;

    public override void Collision()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, GameAssets.Instance.castle.transform.position - transform.position, _distance, _targetLayer);
        if(hit)
        {
            if(hit.collider.gameObject.TryGetComponent<Castle>(out Castle castle))
            {
                castle.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
