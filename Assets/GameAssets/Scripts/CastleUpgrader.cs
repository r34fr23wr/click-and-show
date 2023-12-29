using UnityEngine;
using TMPro;

public class CastleUpgrader : MonoBehaviour
{
    [SerializeField] private Castle _castle;
    [SerializeField] private TextMeshProUGUI _upgradeText;
    [SerializeField] private int _cost;
    [SerializeField] private int _costIncreases = 10;

    private int _upgradesCount;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            BuyUpgrade();
        }
    }

    private void BuyUpgrade()
    {
        if(Money.amount < _cost) return;
        _upgradesCount++;
        _castle.EnableAnimator();

        if(_upgradesCount == 3)
        {
            _castle.damage++;
            _upgradesCount = 0;
        }

        Money.RemoveMoney(_cost);
        _cost+=_costIncreases;
        _castle.fireCooldown -= 0.1f;
        _upgradeText.text = "Upgrade costs: " + _cost + "<br>press 'e' to upgrade";
    }

    public void ToggleVisibility(bool value)
    {
        _upgradeText.gameObject.SetActive(value);
        _upgradeText.text = "Upgrade costs: " + _cost + "<br>press 'e' to upgrade";
    }
}
