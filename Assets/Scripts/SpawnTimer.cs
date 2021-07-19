using UnityEngine;

public class SpawnTimer : MonoBehaviour
{
    public string SpawnPoolTag = "EnemyPool";
    public float SpawnInterval = 5f;
    private ObjectPool _pool = null;

    private void Awake()
    {
        _pool = GameObject.FindWithTag(SpawnPoolTag).GetComponent<ObjectPool>();
    }
    public void Spawn()
    {
        _pool.Spawn(null, transform.position, transform.rotation, Vector3.one);
    }

    private void Start()
    {
        InvokeRepeating("Spawn", SpawnInterval, SpawnInterval);
    }
}
