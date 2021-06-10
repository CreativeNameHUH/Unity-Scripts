using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent OnHealthChanged;
    public string SpawnPoolTag = string.Empty;

    [SerializeField] private float _healthPoints = 100f;
    private ObjectPool _pool;
    public float HealthPoints
    {
        get => _healthPoints;
        set
        {
            _healthPoints = value;
            OnHealthChanged?.Invoke();
            if (_healthPoints <= 0f)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        if (_pool == null) return;
        _pool.DeSpawn(transform);
        HealthPoints = 100f;
    }

    void Awake()
    {
        if (SpawnPoolTag.Length <= 0) return;
        _pool = GameObject.FindWithTag(SpawnPoolTag).GetComponent<ObjectPool>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            HealthPoints = 0;
        }
    }
}
