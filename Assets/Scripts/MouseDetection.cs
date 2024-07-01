using UnityEngine;

public class MouseDetection : MonoBehaviour
{
    [SerializeField] Camera cam;
    private bool isClickedObject;
    private GameObject hitObject;

    public void Update()
    {
        IsClickedObject();
        PassClickedObjectDate();
    }

    public void IsClickedObject()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, 10f);

        if (!Input.GetMouseButtonDown(0)) return;
        {
            if (!hit.collider) return;
            {
                isClickedObject = true;
                hitObject = hit.collider.gameObject;
            }
        }
    }

    public void PassClickedObjectDate()
    {
        TouchObjectGenerator touchObjectGenerator = GetComponent<TouchObjectGenerator>();
        touchObjectGenerator.ReGenerateObject(isClickedObject,hitObject);
    }
}
