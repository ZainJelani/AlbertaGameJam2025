using Mono.Cecil;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float moveSpeed;
    private Vector2 _moveDirection;
    public InputActionReference move;
    public InputActionReference phase;

    //private PlayerInput playerInput;

    //public void Awake()
    //{
    //    playerInput = GetComponent<PlayerInput>();
    //}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        myRigidbody.linearVelocity = new Vector2(x: _moveDirection.x * moveSpeed, y: _moveDirection.y * moveSpeed);
    }

    private void OnEnable()
    {
        phase.action.started += Phase;
    }

    private void OnDisable()
    {
        phase.action.started -= Phase;
    }

    private void Phase(InputAction.CallbackContext obj)
    {
        Debug.Log(message: "Phase");
    }

    //private void SwitchActionMap(InputAction.CallbackContext obj)
    //{
    //    playerInput.SwitchCurrentActionMap("Game Over Screen");
    //}
}
