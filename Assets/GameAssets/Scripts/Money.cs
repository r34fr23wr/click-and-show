using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    private static TextMeshProUGUI _moneyText;
    public static int amount;

    private void Start()
    {
        _moneyText = GetComponent<TextMeshProUGUI>();
    }

    public static void AddMoney(int money)
    {
        amount += money;
        _moneyText.text = "money " + amount;
    }

    public static void RemoveMoney(int money)
    {
        amount -= money;
        _moneyText.text = "money " + amount;
    }
}
