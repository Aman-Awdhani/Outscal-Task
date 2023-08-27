using UnityEngine;

public class MoveCommand : MonoBehaviour , IInputCommand
{
    private Rigidbody2D rb;
    private float moveInput;
    private float moveSpeed;

    public MoveCommand(Rigidbody2D rb, float moveInput, float moveSpeed)
    {
        this.rb = rb;
        this.moveInput = moveInput;
        this.moveSpeed = moveSpeed;
    }

    public void Execute()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
}
