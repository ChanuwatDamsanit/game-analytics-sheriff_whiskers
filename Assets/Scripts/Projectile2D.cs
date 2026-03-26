using UnityEngine;

public class Projectile2D : MonoBehaviour
{
    [SerializeField] Transform shootpoint;
    [SerializeField] GameObject target; // This is your crosshair
    [SerializeField] Rigidbody2D bulletPrefab;

    [Header("Orbit Settings")]
    [SerializeField] float orbitRadius = 1.5f;

    private int shotCount = 0;

    void Update()
    {
        UpdateCrosshair(); // Always follow the mouse
        RotateShootPoint();

        if (Input.GetMouseButtonDown(0))
        {
            HandleShooting();
        }
    }

    void UpdateCrosshair()
    {
        // Get mouse position in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Ensure it stays on the 2D plane

        // Move the target (crosshair) to the mouse position
        target.transform.position = mousePos;
    }

    void RotateShootPoint()
    {
        // Use the crosshair's position as the target for rotation
        Vector2 direction = (target.transform.position - transform.position).normalized;

        shootpoint.position = (Vector2)transform.position + (direction * orbitRadius);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        shootpoint.rotation = Quaternion.Euler(0, 0, angle);
    }

    void HandleShooting()
    {
        // Since the crosshair is already at the mouse position, we use target.transform.position
        Vector2 hitPoint = target.transform.position;

        shotCount++;

        Vector2 projectileVelocity = CalcualteprojectileVelocity(shootpoint.position, hitPoint, 1f);

        Rigidbody2D shootbullet = Instantiate(bulletPrefab, shootpoint.position, shootpoint.rotation);
        shootbullet.linearVelocity = projectileVelocity;
    }

    Vector2 CalcualteprojectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;
        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        return new Vector2(velocityX, velocityY);
    }

    public int GetShotCount() => shotCount;
}