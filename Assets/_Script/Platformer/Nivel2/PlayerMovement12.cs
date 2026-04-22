using UnityEngine;

public class PlayerMovement12 : MonoBehaviour
{
    private NewInput2 _newInput; 
    private Rigidbody2D _rigidbody;

    public float speed;
    
    void Start()
    {
        _newInput = GetComponent<NewInput2>(); // 
        _rigidbody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        PlayerMove();
    }

    public void PlayerMove()
    {
        _rigidbody.velocity = new Vector2(_newInput.inputX * speed, _rigidbody.velocity.y);
    }
}