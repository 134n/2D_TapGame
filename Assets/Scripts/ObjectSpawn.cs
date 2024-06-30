using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    [SerializeField] GameObject purplePointPrefub;

    public void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        Vector3 spawn = new(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f), 0);
        Instantiate(purplePointPrefub, spawn, Quaternion.identity);
    }
}
