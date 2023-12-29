using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets Instance { get; set; }

    private void Awake() => Instance = this;

    public Transform damagePopupPrefab;
    public Castle castle;
    public CastleUpgrader castleUpgrader;
}
