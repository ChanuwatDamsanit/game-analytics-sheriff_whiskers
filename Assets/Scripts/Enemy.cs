using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int enemyHp;

    public void TakeDamage(int damage)
    {
        enemyHp -= damage;
        if (enemyHp <= 0) 
        { 
            Destroy(gameObject);
        }
    }
}
