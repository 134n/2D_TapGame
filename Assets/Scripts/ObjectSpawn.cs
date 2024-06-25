using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    [SerializeField] GameObject purpurePointPrefub;

    public void Start()
    {
        RandomRespawn();
    }
    public void RandomRespawn()
        {
            Vector3 randomRespawn = new(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f), 0);
            Instantiate(purpurePointPrefub, randomRespawn, Quaternion.identity);
        }
}
