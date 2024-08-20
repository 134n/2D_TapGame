using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class MouseDetection : MonoBehaviour
{
    [SerializeField] Camera cam;

    private readonly Subject<GameObject> purpleObjectSubject = new();

    public IObservable<GameObject> OnClickedPurpleObject => purpleObjectSubject;

    public void Start()
    {
        this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ =>
            {
                var isClickedPurpleObject = TryGetPurpleObjectByRaycast(out GameObject purpleObject);
                if(!isClickedPurpleObject) return;
                
                purpleObjectSubject.OnNext(purpleObject);
            })
            .AddTo(this);
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
}