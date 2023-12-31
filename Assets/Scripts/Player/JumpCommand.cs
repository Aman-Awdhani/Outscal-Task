using UnityEngine;
public class JumpCommand : MonoBehaviour , IInputCommand
{
    private Rigidbody2D rb;
    private float jumpForce;

    public JumpCommand(Rigidbody2D rb, float jumpForce)
    {
        this.rb = rb;
        this.jumpForce = jumpForce;
    }

    public void Execute()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
