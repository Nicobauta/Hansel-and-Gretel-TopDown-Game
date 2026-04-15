using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpDistance = 1f;   // tamaño del tile
    public float jumpSpeed = 8f;

    private bool isJumping = false;
    private Vector2 targetPosition;

    private NewInput _input;

    void Awake()
    {
        _input = GetComponent<NewInput>();
    }

    void Update()
    {
        // Movimiento hacia el destino
        if (isJumping)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                targetPosition,
                jumpSpeed * Time.deltaTime
            );

            if (Vector2.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                isJumping = false;
            }
        }
    }

    public void Jump()
    {
        if (isJumping) return;

        Vector2 direction = _input.movement;

        // Evitar diagonales (solo 4 direcciones)
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            direction = new Vector2(Mathf.Sign(direction.x), 0);
        else
            direction = new Vector2(0, Mathf.Sign(direction.y));

        if (direction == Vector2.zero) return;

        targetPosition = (Vector2)transform.position + direction * jumpDistance;
        isJumping = true;
    }
}