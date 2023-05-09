using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI descriptionText;

    UISelect GetCurrentUISelect()
    {
        return selectableOptions[currentIndex].GetComponent<UISelect>();
    }

    void ChangeSelection()
    {
        // Cursor
        selectIndicator.anchoredPosition = new Vector2(selectIndicator.anchoredPosition.x,
            selectableOptions[currentIndex].anchoredPosition.y);
        // Description
        descriptionText.text = GetCurrentUISelect()?.Description;
    }

    public void Navigate(InputAction.CallbackContext context)
    {
        if(context.action.phase == InputActionPhase.Started)
        {
            ...
            ChangeSelection();
        }
    }

    public void Confirm(InputAction.CallbackContext context)
    {
        if(context.action.phase == InputActionPhase.Performed)
        {
            ...
            GetCurrentUISelect()?.OnSelectEvent.Invoke();
        }
    }
}
