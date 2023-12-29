using UnityEngine;

public class UnitBuilder : MonoBehaviour
{
    [SerializeField] private GameObject _unit;
    [SerializeField] private int _unitCost;

    private Vector2 _mousePosition => Camera.main.ScreenToWorldPoint(Input.mousePosition);

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            BuildUnit();
        }
    }

    private void BuildUnit()
    {
        if(Money.amount < _unitCost) return;

        Money.RemoveMoney(_unitCost);
        Instantiate(_unit, _mousePosition, Quaternion.identity);
    }
}
