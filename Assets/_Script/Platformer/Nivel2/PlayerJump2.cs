using UnityEngine;

public class PlayerJump2 : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float jumpForce;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (Mathf.Abs(_rigidbody.velocity.y) < 0.01f)
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}