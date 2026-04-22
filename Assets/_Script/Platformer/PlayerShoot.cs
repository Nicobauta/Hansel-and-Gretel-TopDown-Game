using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject rockPrefab;
    public Transform firePoint;
    public float shootForce = 10f;

    private PlayerStats stats;
    private NewInput input;

    void Awake()
    {
        stats = GetComponent<PlayerStats>();
        input = GetComponent<NewInput>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Presionaste P");
            Shoot();
        }
    }

    void Shoot()
    {
        if (stats.rocas <= 0)
        {
            Debug.Log("Sin rocas!");
            return;
        }

        stats.rocas--;

        GameObject rock = Instantiate(rockPrefab, firePoint.position, Quaternion.identity);

        Rigidbody2D rb = rock.GetComponent<Rigidbody2D>();

        Vector2 direction = input.movement;

        if (direction == Vector2.zero)
        {
            direction = input.lastDirection;
        }

        // Por si nunca se ha movido
        if (direction == Vector2.zero)
        {
            direction = Vector2.up;
        }

        rb.velocity = direction.normalized * shootForce;
    }
}