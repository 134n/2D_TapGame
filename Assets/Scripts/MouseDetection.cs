using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class MouseDetection : MonoBehaviour
{
    [SerializeField] Camera cam;

    private readonly Subject<GameObject> purpleObjectSubject = new();

    public IObservable<GameObject> PurpleObjectObservable
    {
        get { return purpleObjectSubject; }
    }

    public void Start()
    {
        this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ =>
            {
                bool isClickedPurpleObject = SetPurpleObjectRaycastToRegenerateObject();
                if (!isClickedPurpleObject) return;
            });
    }

    private bool SetPurpleObjectRaycastToRegenerateObject()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D raycastHitObject = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, 10f);

        if (!raycastHitObject) return false;

        purpleObjectSubject.OnNext(raycastHitObject.collider.gameObject);

        return true;
    }
}