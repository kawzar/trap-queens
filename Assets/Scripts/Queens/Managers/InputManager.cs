using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera camera;
    private QueensInputActions queensInputActions;
    
    public static InputManager Instance { get; set; }
    
    public delegate void StartTouch(Vector2 position, float time);

    public event StartTouch OnStartTouch;

    public delegate void EndTouch(Vector2 position, float time);

    public event EndTouch OnEndTouch;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        
        queensInputActions = new QueensInputActions();
    }

    private void OnEnable()
    {
        queensInputActions.Enable();
    }

    private void OnDisable()
    {
        queensInputActions.Disable();
    }

    private void Start()
    {
        queensInputActions.Gameplay.PrimaryContact.started += ctx => OnPrimaryContactStarted(ctx);
        queensInputActions.Gameplay.PrimaryContact.canceled += ctx => OnPrimaryContactEnded(ctx);
    }

    private void OnPrimaryContactStarted(InputAction.CallbackContext ctx)
    {
        if (OnStartTouch != null)
        {
            Vector2 position = queensInputActions.Gameplay.PrimaryPosition.ReadValue<Vector2>();
            OnStartTouch(camera.ScreenToWorldPoint(position), (float)ctx.startTime);
        }
    }
    
    private void OnPrimaryContactEnded(InputAction.CallbackContext ctx)
    {
        if (OnEndTouch != null)
        {
            Vector3 position = queensInputActions.Gameplay.PrimaryPosition.ReadValue<Vector2>();
            position.z = camera.nearClipPlane;
            OnEndTouch(camera.ScreenToWorldPoint(position), (float)ctx.time);
        }
    }

    public Vector2 GetPrimaryPosition()
    { 
        Vector3 position = queensInputActions.Gameplay.PrimaryPosition.ReadValue<Vector2>();
        position.z = camera.nearClipPlane;
        return camera.ScreenToWorldPoint(position);
    }
    
}
