using UnityEngine;

public class TouchObjectGenerator : MonoBehaviour
{
    [SerializeField] GameObject purplePointPrefab;

    public void Start()
    {
        GenerateObject();
    }

    private void GenerateObject()
    {
        Vector3 spawn = new(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f), 0);
        Instantiate(purplePointPrefab, spawn, Quaternion.identity);
    }

    public void RegenerateObject(GameObject hitObject)
    {
        Destroy(hitObject);
        GenerateObject();
    }
}