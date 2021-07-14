public class EnemyHealth : Variables
{
    private float _enemyHealth = EnemyHealth;
    private ObjectPool _pool;

    public void TakeDamage(float damage)
    {
        _enemyHealth -= damage;

        if (_enemyHealth <= 0f)
        {
            Die();
            PlayerPoints += 100;
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }
}
