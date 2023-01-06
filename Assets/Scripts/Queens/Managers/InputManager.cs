using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class InputManager : MonoBehaviour
{
    public float touchSpeed = 10f;

    public static InputManager Instance { get; set; }

    public Action<Vector3> OnMovedToPosition;
    public Action<Vector3> OnFingerReleased;
        
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        
        EnhancedTouchSupport.Enable();
    }

    private void Update()
    {
        if (Touch.activeTouches.Any())
        {
            MoveCard(Touch.activeTouches[0]);
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
}
