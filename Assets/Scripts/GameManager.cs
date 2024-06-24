using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject purpurePointPrefub;

    private void Start()
    {
        ObjectSpawn objectSpawn = new(purpurePointPrefub);
        objectSpawn.RandomRespawn();
    }
    private class ObjectSpawn
    {
        private readonly GameObject purpurePointPrefub;
        public ObjectSpawn(GameObject purpurePointPrefub)
        {
            this.purpurePointPrefub = purpurePointPrefub;
        }
        public void RandomRespawn()
        {
            Vector3 randomRespawn = new(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f), 0);
            Instantiate(purpurePointPrefub, randomRespawn, Quaternion.identity);
        }
    }
}
