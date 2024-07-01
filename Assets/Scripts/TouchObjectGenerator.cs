using UnityEngine;

public class TouchObjectGenerator : MonoBehaviour
{
    [SerializeField] GameObject purplePointPrefab;
    private readonly bool isClickedObject;
    private readonly GameObject hitObject;

    public void Start()
    {
        GenerateObject();
    }

    public void Update()
    {
        ReGenerateObject(isClickedObject, hitObject);
    }

    public void GenerateObject()
    {
        Vector3 spawn = new(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f), 0);
        Instantiate(purplePointPrefab, spawn, Quaternion.identity);
    }

    public void ReGenerateObject(bool isClickedObject, GameObject hitObject)
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if (!hitObject) return;
        if (!isClickedObject) return;

        Destroy(hitObject);
        GenerateObject();
    }
}
