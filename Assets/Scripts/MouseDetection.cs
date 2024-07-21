using UnityEngine;

public class MouseDetection : MonoBehaviour
{
    [SerializeField] Camera cam;
    private TouchObjectGenerator touchObjectGenerator;
    private RaycastHit2D raycastHitObject;

    public void Start()
    {
        touchObjectGenerator = GetComponent<TouchObjectGenerator>();
    }

    public void Update()
    {
        // if (!hitObject) return;
        // if (!isClickedObject) return;

        // RayCastHitObject();
        // IsClickedObject();
        // ClickedHitObject();
        // SetClickedObjectDataToTouchObjectGenerator();
        if (!Input.GetMouseButtonDown(0)) return;

        var isClickedPurpleObject = TryGetPurpleObjectByRaycast(out var purpleObject);
        if (!isClickedPurpleObject) return;
        
        RegenerateObject(purpleObject);
    }

    private bool TryGetPurpleObjectByRaycast(out GameObject purpleObject)
    {
        purpleObject = null;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        raycastHitObject = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, 10f);

        if (!raycastHitObject) return false;

        purpleObject = raycastHitObject.collider.gameObject;
        return true;
    }

    private void RegenerateObject(GameObject purpleObject)
    {
        touchObjectGenerator.RegenerateObject(purpleObject);
    }

    /*private void RayCastHitObject()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        raycastHitObject = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, 10f);
    }

    private bool IsClickedObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (raycastHitObject.collider)
            {  
                
            }
        }
        return isClickedObject;
    }

    private void ClickedHitObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (raycastHitObject.collider)
            {
                hitObject = raycastHitObject.collider.gameObject;
            }
        }
    }

    private void SetClickedObjectDataToTouchObjectGenerator()
    {
        touchObjectGenerator.RegenerateObject(hitObject);

        isClickedObject = false;
        hitObject = null;
    }*/
}
