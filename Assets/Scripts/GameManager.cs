using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject purplePointPrefab;
    [SerializeField] Camera cam;
    private TouchObjectGenerator touchObjectGenerator;

    private void Start()
    {
        touchObjectGenerator = new(purplePointPrefab, cam);
        touchObjectGenerator.GenerateObject();
    }

    private void Update()
    {
        touchObjectGenerator.IsClickedObject();
        touchObjectGenerator.ReGenerateObject();
    }

    private class TouchObjectGenerator
    {
        private readonly GameObject purplePointPrefab;
        private readonly Camera cam;
        private bool isClickedObject;
        private GameObject hitObject;

        public TouchObjectGenerator(GameObject purplePointPrefab, Camera cam)
        {
            this.purplePointPrefab = purplePointPrefab;
            this.cam = cam;
        }

        public void GenerateObject()
        {
            Vector3 spawn = new(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f), 0);
            Instantiate(purplePointPrefab, spawn, Quaternion.identity);
        }

        public void IsClickedObject()
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, 10f);

            if (!Input.GetMouseButtonDown(0)) return;
            if (!hit.collider) return;

            isClickedObject = true;
            hitObject = hit.collider.gameObject;
        }

        public void ReGenerateObject()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            if (!hitObject) return;
            if (!isClickedObject) return;

            Destroy(hitObject);
            GenerateObject();

        }
    }
}
