using UnityEngine;

public class MouseDetection : MonoBehaviour
{
    [SerializeField] Camera cam;
    private bool isClickedObject;
    private GameObject hitObject;
    private TouchObjectGenerator touchObjectGenerator;
    private RaycastHit2D raycastHitObject;

    public void Start()
    {
        touchObjectGenerator = GetComponent<TouchObjectGenerator>();
    }

    public void Update()
    {
        RayCastHitObject();
        IsClickedObject();
        ClickedHitObject();
        SetClickedObjectDataToTouchObjectGenerator();
    }

    private RaycastHit2D RayCastHitObject()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        raycastHitObject = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, 10f);

        return raycastHitObject;
    }

    private bool IsClickedObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (raycastHitObject.collider)
            {
                isClickedObject = true;
            }
        }
        return isClickedObject;
    }

    private GameObject ClickedHitObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (raycastHitObject.collider)
            {
                hitObject = raycastHitObject.collider.gameObject;
            }
        }
        return hitObject;
    }

    private void SetClickedObjectDataToTouchObjectGenerator()
    {
        if (!hitObject) return;
        if (!isClickedObject) return;

        touchObjectGenerator.RegenerateObject(isClickedObject, hitObject);

        isClickedObject = false;
        hitObject = null;
    }
}
