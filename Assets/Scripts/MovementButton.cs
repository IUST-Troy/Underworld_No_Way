using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovementButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PlayerMovment playerMovement;
    private bool isLeftButtonDown = false;
    private bool isRightButtonDown = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name == "LeftButton")
        {
            isLeftButtonDown = true;
        }
        else if (eventData.pointerCurrentRaycast.gameObject.name == "RightButton")
        {
            isRightButtonDown = true;
        }

        UpdateMovement();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name == "LeftButton")
        {
            isLeftButtonDown = false;
        }
        else if (eventData.pointerCurrentRaycast.gameObject.name == "RightButton")
        {
            isRightButtonDown = false;
        }

        UpdateMovement();
    }

    private void UpdateMovement()
    {
        // Call the movement methods in PlayerMovement based on button states
        if (isLeftButtonDown && !isRightButtonDown)
        {
            playerMovement.Move(-1);
        }
        else if (isRightButtonDown && !isLeftButtonDown)
        {
            playerMovement.Move(+1);
        }
        else
        {
            playerMovement.Move(0);
        }
    }
}
