using UnityEngine;
using UniRx;

public class TouchObjectGenerator : MonoBehaviour
{
    [SerializeField] MouseDetection mouseDetection;
    [SerializeField] GameObject purplePointPrefab;

    public void Start()
    {
        GenerateObject();

        mouseDetection.OnClickedPurpleObject
            .Subscribe(RegenerateObject);
    }

    private void GenerateObject()
    {
        Vector3 spawn = new(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f), 0);
        Instantiate(purplePointPrefab, spawn, Quaternion.identity);
    }

    private void RegenerateObject(GameObject hitObject)
    {
        Destroy(hitObject);
        GenerateObject();
    }
}