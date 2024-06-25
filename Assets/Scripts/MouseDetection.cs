using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseDetection : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] ObjectSpawn objectSpawn;
    public void Update()
    {
        MousePoint();
    }
    public void MousePoint()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, 10f);

        if (!Input.GetMouseButtonDown(0)) return;
        {
            if (!hit.collider) return;
            {
                Destroy(hit.collider.gameObject);
                objectSpawn.RandomRespawn();
            }
        }
    }
}
