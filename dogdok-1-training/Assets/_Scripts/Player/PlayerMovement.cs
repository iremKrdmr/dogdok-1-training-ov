using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float moveSpeed;
    public float jumpForce;

    float horizontalInput;
    float verticalInput;
    bool isGrounded;

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        float xMovement = moveDirection.x * moveSpeed;
        float zMovement = moveDirection.y * moveSpeed;

        Vector3 movement = transform.right * xMovement + transform.forward * zMovement;
        movement.y = Rigidbody.velocity.y;

        Rigidbody.velocity = movement;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }   
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
