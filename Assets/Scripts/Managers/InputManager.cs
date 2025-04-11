using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager
{
    InputSystem_Actions _inputActions;
    public Action<GameObject> selectCrewAction;
    public Action deselectCrewAction;
    public Action<GameObject> selectCellAction;
    public Action deselectCellAction;

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
                selectCrewAction.Invoke(hit.collider.gameObject);
            }
            else
            {
                if (CrewController.Instance.SelectedCrew != null)
                {
                    deselectCrewAction.Invoke();
                }
            }
        }
        else
        {
            Debug.Log("No object was hit by the raycast.");
            if (CrewController.Instance.SelectedCrew != null)
            {
                deselectCrewAction.Invoke();
            }
        }
    }

    void OnRightClick(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Cell") && CrewController.Instance.SelectedCrew != null)
            {
                if(hit.collider.GetComponent<Cell>().CrewInCell == null)
                {
                    Debug.Log("Selected Cell to Move");
                    selectCellAction.Invoke(hit.collider.gameObject);
                }
            }
        }
        else
        {
            Debug.Log("No object was hit by the raycast.");
            deselectCellAction.Invoke();
        }
    }

    public void CleanUp()
    {
        if (_inputActions != null)
        {
            _inputActions.Control.LeftClick.performed -= OnLeftClick;
            _inputActions.Control.RightClick.performed -= OnRightClick;
            _inputActions.Disable();
        }
    }
}
