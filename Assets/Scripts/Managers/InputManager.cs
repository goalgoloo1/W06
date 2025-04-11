using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager
{
    InputSystem_Actions _inputActions;

    public void Init()
    {
        _inputActions = new InputSystem_Actions();
        _inputActions.Enable();
        _inputActions.Control.LeftClick.performed += OnLeftClick;
        _inputActions.Control.RightClick.performed += OnRightClick;
    }

    void OnLeftClick(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Crew"))
            {
                Debug.Log("Clicked On Crew");
            }
        }
        else
        {
            Debug.Log("No object was hit by the raycast.");
        }
    }

    void OnRightClick(InputAction.CallbackContext context)
    {
    }

    public void CleanUp()
    {
        if (_inputActions != null) { 
            _inputActions.Control.LeftClick.performed -= OnLeftClick;
            _inputActions.Control.RightClick.performed -= OnRightClick;
            _inputActions.Disable();
        }
    }
}
