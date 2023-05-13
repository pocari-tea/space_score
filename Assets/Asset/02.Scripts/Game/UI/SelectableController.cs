using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using System.Xml;
using UnityEngine.Serialization;

public class SelectableController : MonoBehaviour
{
    [SerializeField]
    List<RectTransform> selectableOptions;
    [SerializeField]
    RectTransform selectIndicator;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField] private AudioClip uiAudioClip;
    [SerializeField] private AudioClip scrollAudioClip;
    [SerializeField] private AudioClip confirmAudioClip;

    private int currentIndex;
    
    UISelect GetCurrentUISelect()
    {
        return selectableOptions[currentIndex].GetComponent<UISelect>();
    }

    private void ChangeSelection()
    {
        // x좌표는 화살표 위치에 두고 y좌표만 이동
        selectIndicator.anchoredPosition = new Vector2(selectIndicator.anchoredPosition.x, selectableOptions[currentIndex].anchoredPosition.y);
    }
    
    public void Navigate(InputAction.CallbackContext context)
    {
        if (context.action.phase == InputActionPhase.Started)
        {
            float y = context.ReadValue<Vector2>().y;

            if(y == -1 && currentIndex < selectableOptions.Count - 1)
            {
                currentIndex += 1;
            }
            else if(y == 1 && currentIndex > 0)
            {
                currentIndex -= 1;
            }
            else return;

            selectIndicator.anchoredPosition = new Vector2(selectIndicator.anchoredPosition.x, selectableOptions[currentIndex].anchoredPosition.y);
                                                    
            audioSource.PlayOneShot(scrollAudioClip);
        
            ChangeSelection();
        }
    }

    public void Confirm(InputAction.CallbackContext context)
    {
        if(context.action.phase == InputActionPhase.Performed)
        {
            audioSource.PlayOneShot(confirmAudioClip);
            
            GetCurrentUISelect()?.OnSelectEvent.Invoke();
        }
    }

    void Awake()
    {
        audioSource.ignoreListenerPause = true;
    }

    void OnEnable()
    {
        currentIndex = 0;

        if (uiAudioClip != null)
        {
            audioSource.PlayOneShot(uiAudioClip);
        }
    
        ChangeSelection();

        // InputAction navigateAction = GameManager.PlayerInput.actions.FindAction("Navigate");
        // navigateAction.started += Navigate;
        // InputAction submitAction = GameManager.PlayerInput.actions.FindAction("Submit");
        // submitAction.started += Confirm;
    }
}