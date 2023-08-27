using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IInputCommand jumpCommand;
    private IInputCommand moveCommand;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        jumpCommand = new JumpCommand(rb, jumpForce);
        moveCommand = new MoveCommand(rb, 0f, moveSpeed);
    }

    private void Update()
    {
        if (!GameManager.instance.IsGameRunning()) return;

        float moveInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            jumpCommand.Execute();
        }

        moveCommand = new MoveCommand(rb, moveInput, moveSpeed);
        moveCommand.Execute();
    }
}
