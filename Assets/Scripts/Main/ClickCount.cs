using UniRx;
using UnityEngine;

public class ClickCount : MonoBehaviour
{
    [SerializeField] MouseDetection mouseDetection;

    [SerializeField] ClickCountUI clickCountUI;

    [SerializeField] private int addClickPoint;

    private void Start()
    {
        mouseDetection.OnClickedPurpleObject
            .Subscribe(_ =>
            {
                clickCountUI.AddPoint(addClickPoint);
            })
            .AddTo(this);
    }
}
