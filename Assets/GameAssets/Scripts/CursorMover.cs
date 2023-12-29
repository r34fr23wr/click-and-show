using UnityEngine;

public class CursorMover : MonoBehaviour
{
    private Vector2 _mousePosition => Camera.main.ScreenToWorldPoint(Input.mousePosition);
    private Animator _animator;

    private readonly int clickKey = Animator.StringToHash("Click");
    private readonly int unClickKey = Animator.StringToHash("UnClick");

    private void Start()
    {
        Cursor.visible = false; 
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            _animator.SetTrigger(clickKey);
        }
        if(Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            _animator.SetTrigger(unClickKey);
        }
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(_mousePosition.x,_mousePosition.y);
    }
}
