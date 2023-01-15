using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class InputManager : MonoBehaviour
{
    public float touchSpeed = 10f;

    public static InputManager Instance { get; set; }

    public Action<Vector3> OnMovedToPosition;
    public Action<Vector3> OnFingerReleased;

    private bool isTouchSupportEnabled = false;
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        if (UnityEngine.InputSystem.Touchscreen.current != null)
        {
            EnhancedTouchSupport.Enable();
            isTouchSupportEnabled = true;
        }
        else
        {
            isTouchSupportEnabled = false;
        }
    }

    private void Update()
    {
        if (isTouchSupportEnabled && Touch.activeTouches.Any())
        {
            MoveCard(Touch.activeTouches[0]);
        }
        else
        {
            MoveCardMouseVersion(UnityEngine.InputSystem.Mouse.current.leftButton);
        }
    }

    private void MoveCard(Touch touch)
    {
        if (touch.phase is TouchPhase.Canceled or TouchPhase.Ended)
        {
            OnFingerReleased?.Invoke(touch.screenPosition);
        }
        else if (touch.phase == TouchPhase.Moved)
        {
            OnMovedToPosition?.Invoke(touch.screenPosition);
        }
    }

    private void MoveCardMouseVersion(ButtonControl leftButton)
    {
        if (leftButton.wasReleasedThisFrame)
        {
            OnFingerReleased?.Invoke(UnityEngine.InputSystem.Mouse.current.position.ReadValue());
        }
        else if(leftButton.isPressed)
        {
            OnMovedToPosition?.Invoke(UnityEngine.InputSystem.Mouse.current.position.ReadValue());
        }
    }
}
