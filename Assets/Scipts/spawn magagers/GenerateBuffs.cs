using UnityEngine;

public class GenerateBuffs : MonoBehaviour
{
    public GameObject BuffPrefab; 
    public float SpawnTime = 30;
    public float ActiveTimeOfBuff = 15f;
    
    private const float MaxXz = 45f;
    private Vector3 _position;
    private GameObject _parentObj;

    private void Start()
    {
        _parentObj = GameObject.FindGameObjectWithTag("Buff");
        InvokeRepeating("Spawn", SpawnTime, SpawnTime);
    }


    private void Spawn()
    {
        _position.Set(Random.Range(0, MaxXz), -4.2f, Random.Range(0, MaxXz));
        GameObject obj = Instantiate(BuffPrefab, _position, BuffPrefab.transform.rotation);
        obj.transform.SetParent(_parentObj.transform);
        Destroy(obj, ActiveTimeOfBuff);
    }

}