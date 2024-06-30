using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject purplePointPrefub;
    [SerializeField] Camera cam;

    private void Start()
    {
        ObjectSpawn objectSpawn = new(purplePointPrefub, cam);

        objectSpawn.Spawn();
    }

    private void Update()
    {
        ObjectSpawn objectSpawn = new(purplePointPrefub, cam);

        objectSpawn.MouseDetection();
    }

    private class ObjectSpawn
    {
        private readonly GameObject purplePointPrefub;
        private readonly Camera cam;

        public ObjectSpawn(GameObject purplePointPrefub, Camera cam)
        {
            this.purplePointPrefub = purplePointPrefub;
            this.cam = cam;
        }

        public void Spawn()
        {
            Vector3 spawn = new(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f), 0);
            Instantiate(purplePointPrefub, spawn, Quaternion.identity);
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
                    Spawn();
                }
            }
        }
    }
}
