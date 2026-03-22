using UnityEngine;

public class Projectile2D : MonoBehaviour
{
    [SerializeField] Transform shootpoint;
    [SerializeField] GameObject target;
    [SerializeField] Rigidbody2D bulletPrefab;

    private int shotCount = 0; // The counter

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                shotCount++; // Increment counter each time you shoot

                target.transform.position = new Vector2(hit.point.x, hit.point.y);
                Vector2 projectileVelocity = CalcualteprojectileVelocity(shootpoint.position, hit.point, 1f);

                Rigidbody2D shootbullet = Instantiate(bulletPrefab, shootpoint.position, Quaternion.identity);
                shootbullet.linearVelocity = projectileVelocity;
            }
        }
    }

    // Call this when the level ends to pass the total count to Analytics
   /* public void FinalizeShots(string levelName)
    {
        AnalyticManager.instance.SendLevelCompleteEvent(levelName, shotCount);
        shotCount = 0; // Reset for next level
    }*/

    Vector2 CalcualteprojectileVelocity(Vector2 origin, Vector2 target, float time)
    {
            Vector2 distance = target - origin;

            //find velocity of x and y axis
            float velocityX =  distance.x / time;
            float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

            //get projectile vector
            Vector2 projectileVelocity = new Vector2(velocityX, velocityY);

            return projectileVelocity;

    }

    public int GetShotCount()
    {
        return shotCount;
    }
}

