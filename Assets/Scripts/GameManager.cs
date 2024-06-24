using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject purpurePointPrefub;
[SerializeField] Camera cam;
    private void Start()
    {
        ObjectSpawn objectSpawn = new(purpurePointPrefub, cam);
        objectSpawn.RandomRespawn();
    }
    private void Update()
    {
        ObjectSpawn objectSpawn = new(purpurePointPrefub, cam);
        objectSpawn.MouseDetection();
    }
    private class ObjectSpawn
    {
        private readonly GameObject purpurePointPrefub;
        private readonly Camera cam;
        public ObjectSpawn(GameObject purpurePointPrefub, Camera cam)
        {
            this.purpurePointPrefub = purpurePointPrefub;
            this.cam = cam;
        }
        public void RandomRespawn()
        {
            Vector3 randomRespawn = new(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f), 0);
            Instantiate(purpurePointPrefub, randomRespawn, Quaternion.identity);
        }
        public void MouseDetection()
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, 10f);

            if (!Input.GetMouseButtonDown(0)) return;
            {
                if (!hit.collider) return;
                {
                    Destroy(hit.collider.gameObject);
                    RandomRespawn();
                }
            }
        }
    }
}
