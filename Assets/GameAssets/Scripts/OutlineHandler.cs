using UnityEngine;

public class OutlineHandler : MonoBehaviour
{
    [SerializeField] private GameObject _outlines;

    private Vector2 _mousePosition => Camera.main.ScreenToWorldPoint(Input.mousePosition);
    private Transform _hitTransform;
    private Castle _castle;

    private void Update()
    {
        if(_hitTransform) ShowOutlines(_hitTransform);
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(_mousePosition, Vector2.zero);

            if(hit.collider)
            {
                if(hit.collider.gameObject.GetComponent<Hero>() || hit.collider.gameObject.GetComponent<Enemy>())
                {
                    _hitTransform = hit.collider.gameObject.transform;
                }
                if(hit.collider.gameObject.TryGetComponent<Castle>(out Castle castle))
                {
                    _castle = castle;
                    _hitTransform = hit.collider.gameObject.transform;
                    _castle.ToggleSelected(true);
                }
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            if(_castle) _castle.ToggleSelected(false);
            _hitTransform = null;
            HideOutlines();
        }
    }

    public void ShowOutlines(Transform _transform)
    {
        _outlines.transform.position = _transform.position;
        _outlines.SetActive(true);
    }

    public void HideOutlines()
        => _outlines.SetActive(false);
}
