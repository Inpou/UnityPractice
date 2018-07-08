using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    private PlayerHP _playerHealth;
    public GameObject Enemy;
    public float SpawnTime = 3f;
    public Transform[] SpawnPoints;
    private GameObject _enemyParentObj;


    private void Start()
    {
        InvokeRepeating("Spawn", SpawnTime, SpawnTime);
        GameObject player = GameObject.FindGameObjectWithTag ("Player");
        _playerHealth = player.GetComponent<PlayerHP>();
        _enemyParentObj = GameObject.FindGameObjectWithTag("Enemy");
    }


    private void Spawn()
    {
        if (_playerHealth.CurrentHealth <= 0f)
            return;
        int spawnPointIndex = Random.Range(0, SpawnPoints.Length);
        GameObject currentEnemy = Instantiate(Enemy, SpawnPoints[spawnPointIndex].position,
            SpawnPoints[spawnPointIndex].rotation);
        currentEnemy.transform.SetParent(_enemyParentObj.transform);
    }
}