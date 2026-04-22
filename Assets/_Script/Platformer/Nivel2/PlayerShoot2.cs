using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot2 : MonoBehaviour
{
    public GameObject rockPrefab;
    public Transform firePoint;

    private NewInput2 input;
    private float lastDirection = 1f; // 1 = derecha, -1 = izquierda

    private PlayerInput playerInput;
    private InputAction shootAction;

    void Start()
    {
        input = GetComponent<NewInput2>();

        playerInput = GetComponent<PlayerInput>();
        shootAction = playerInput.actions["Fire"];
    }

    void Update()
    {
        HandleDirection();
        HandleShoot();
    }

    void HandleDirection()
    {
        if (input.inputX > 0)
        {
            lastDirection = 1f;
            transform.localScale = new Vector3(2.6f, 2.6f, 1f);
        }
        else if (input.inputX < 0)
        {
            lastDirection = -1f;
            transform.localScale = new Vector3(-2.6f, 2.6f, 1f);
        }
    }

    void HandleShoot()
    {
        if (shootAction.triggered)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector2 dir = new Vector2(input.inputX, input.inputY);

        // Si no hay input vertical, usar última dirección horizontal
        if (dir == Vector2.zero)
        {
            dir = new Vector2(lastDirection, 0);
        }

        // Si solo presiona arriba
        if (dir.y > 0)
        {
            dir = Vector2.up;
        }

        // Normalizar para velocidad uniforme
        dir = dir.normalized;

        GameObject rock = Instantiate(rockPrefab, firePoint.position, Quaternion.identity);

        rock.GetComponent<Rock2>().Init(dir);
    }
}