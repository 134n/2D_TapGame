using UnityEngine;

public class MouseDetection : MonoBehaviour
{
    [SerializeField] Camera cam;
    private GameObject hitObject;
    private TouchObjectGenerator touchObjectGenerator;

    public void Start()
    {
        touchObjectGenerator = GetComponent<TouchObjectGenerator>();
    }

    public void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        var isClickedPurpleObject = TryGetPurpleObjectByRaycast(out var purpleObject);
        if (!isClickedPurpleObject) return;
        
        RegenerateObject(purpleObject);
    }

    private bool TryGetPurpleObjectByRaycast(out GameObject purpleObject)
    {
        purpleObject = null;

        var ray = cam.ScreenPointToRay(Input.mousePosition);
        var raycastHitObject = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, 10f);

        if (!raycastHitObject) return false;

        purpleObject = raycastHitObject.collider.gameObject;
        return true;
    }

    private void RegenerateObject(GameObject purpleObject)
    {
        touchObjectGenerator.RegenerateObject(purpleObject);
    }
}