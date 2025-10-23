using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject head;
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float sensitivity = 200f;
    Vector2 moveInput;
    Vector2 lookInput;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        PlayerMove();
        HeadLook();
        BodyTurn();
    }

    void PlayerMove()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        rb.transform.Translate(new Vector3(moveInput.x, 0, moveInput.y) * movementSpeed * Time.deltaTime);
    }

    void BodyTurn()
    {
        lookInput.x = Input.GetAxis("Mouse X");
        rb.transform.Rotate(new Vector3(0, lookInput.x, 0) * sensitivity * Time.deltaTime);
    }

    void HeadLook()
    {
        lookInput.y = Input.GetAxis("Mouse Y");
        head.transform.Rotate(new Vector3(-lookInput.y, 0, 0) * sensitivity * Time.deltaTime);
    }

}
