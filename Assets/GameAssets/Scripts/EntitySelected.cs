using UnityEngine;

public class EntitySelected : MonoBehaviour
{
    private Vector2 _mousePosition => Camera.main.ScreenToWorldPoint(Input.mousePosition);

    private Hero _hero;
    private Enemy _enemy;

    private void Update()
    {
        if(_hero) _hero.transform.position = _mousePosition;
        if(_enemy) _enemy.transform.position = _mousePosition;

        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(_mousePosition, Vector2.zero);

            if(hit.collider)
            {
                if(hit.collider.gameObject.TryGetComponent<Hero>(out Hero hero))
                {
                    _hero = hero;
                    _hero.isSelected = true;
                }
                if(hit.collider.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    _enemy = enemy;
                    _enemy.isSelected = true;
                }
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            if(_hero) _hero.isSelected = false;
            if(_enemy) _enemy.isSelected = false;
            _hero = null; _enemy = null;
        }
    }
}
