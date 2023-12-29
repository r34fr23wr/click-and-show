using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    public static DamagePopup Create(Vector3 position, int damageValue, int direction)
    {
        Transform damagePopupTransform = Instantiate(GameAssets.Instance.damagePopupPrefab, position, Quaternion.identity);

        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageValue, direction);

        return damagePopup;
    }

    [SerializeField] private float moveSpeed;

    private const float DISAPPEAR_TIMER_MAX = 0.2f;

    private float _disappearTimer;

    private TextMeshPro _textMesh;
    private Color _textColor;
    private Vector3 _moveVector;

    private void Awake() => _textMesh = GetComponent<TextMeshPro>();

    public void Setup(int damageValue, int direction)
    {
        _textMesh.SetText(damageValue.ToString());
        _textColor = _textMesh.color;
        _disappearTimer = DISAPPEAR_TIMER_MAX;

        _moveVector = new Vector3(1.4f*direction,1f) * 3f;
    }

    private void Update()
    {
        transform.position += _moveVector * Time.deltaTime;
        _moveVector -= _moveVector * 8f * Time.deltaTime;

        if(_disappearTimer >  DISAPPEAR_TIMER_MAX * 0.5f)
        {
            float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        else
        {
            float decreaseScaleAmount = 1f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }

        _disappearTimer -= Time.deltaTime;
        if(_disappearTimer < 0)
        {
            float disappearSpeed = 3f;
            _textColor.a -= disappearSpeed * Time.deltaTime;
            _textMesh.color = _textColor;
            if(_textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
