using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] Rigidbody rb;

    [Tooltip("Reference to a Vector2 'Move' action in the Input Actions asset. If empty, legacy Input.GetAxis is used as fallback.")]
    [SerializeField] InputActionReference moveAction;

    Vector3 movement;
    Vector2 moveInput;

    void OnEnable()
    {
        if (moveAction != null && moveAction.action != null)
            moveAction.action.Enable();
    }

    void OnDisable()
    {
        if (moveAction != null && moveAction.action != null)
            moveAction.action.Disable();
    }

    void Update()
    {
        // Read input from new Input System if available, otherwise fallback to legacy Input
        if (moveAction != null && moveAction.action != null)
        {
            moveInput = moveAction.action.ReadValue<Vector2>();
        }
        else
        {
            moveInput.x = Input.GetAxis("Horizontal");
            moveInput.y = Input.GetAxis("Vertical");
        }

        movement = new Vector3(moveInput.x, 0f, moveInput.y);
    }

    void FixedUpdate()
    {
        if (rb == null)
        {
            Debug.LogWarning("PlayerMovement: Rigidbody reference is missing.");
            return;
        }

        Vector3 delta = movement * movementSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + delta);
    }
}
