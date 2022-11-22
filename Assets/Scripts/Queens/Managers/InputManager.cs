using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private QueensInputActions queensInputActions;
    
    public static InputManager Instance { get; set; }
    
    public delegate void StartTouch(Vector2 position, float time);

    public event StartTouch OnStartTouch;

    public delegate void EndTouch(Vector2 position, float time);

    public event EndTouch OnEndTouch;
    
    public delegate void PerformedTouch(Vector2 position, float time);

    public event PerformedTouch OnPerformedTouch;

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
        queensInputActions.Gameplay.PrimaryContact.performed += ctx => OnPrimaryContactPerformed(ctx);
    }

    private void OnPrimaryContactStarted(InputAction.CallbackContext ctx)
    {
        if (OnStartTouch != null)
        {
            Vector3 position = queensInputActions.Gameplay.PrimaryPosition.ReadValue<Vector2>();
            position.z = _camera.nearClipPlane;
            OnStartTouch(_camera.ScreenToWorldPoint(position), (float)ctx.startTime);
        }
    }
    
    private void OnPrimaryContactEnded(InputAction.CallbackContext ctx)
    {
        if (OnEndTouch != null)
        {
            Vector3 position = queensInputActions.Gameplay.PrimaryPosition.ReadValue<Vector2>();
            position.z = _camera.nearClipPlane;
            OnEndTouch(_camera.ScreenToWorldPoint(position), (float)ctx.time);
        }
    }
    
    private void OnPrimaryContactPerformed(InputAction.CallbackContext ctx)
    {
        if (OnPerformedTouch != null)
        {
            Vector3 position = queensInputActions.Gameplay.PrimaryPosition.ReadValue<Vector2>();
            position.z = _camera.nearClipPlane;
            OnPerformedTouch(_camera.ScreenToWorldPoint(position), (float)ctx.time);
        }
    }

    public Vector2 GetPrimaryPosition()
    { 
        Vector3 position = queensInputActions.Gameplay.PrimaryPosition.ReadValue<Vector2>();
        position.z = _camera.nearClipPlane;
        return _camera.ScreenToWorldPoint(position);
    }
    
}
