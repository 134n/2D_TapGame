using UniRx;
using DG.Tweening;
using UnityEngine;
using UniRx.Async;

public class ObjectScaleChange : MonoBehaviour
{
    [SerializeField] MouseDetection mouseDetection;

    private Vector3 endScale = Vector3.zero;

    private bool isScaleChange;

    public bool IsScaleChange { get => isScaleChange; }

    public int changeTime = 2;

    public void Start()
    {
        mouseDetection.OnClickedPurpleObject
            .Subscribe(purpleObject =>
            {
                isScaleChange = true;
                ScaleChangeAsync(purpleObject).Forget();
            })
            .AddTo(this);
    }

    private async UniTask ScaleChangeAsync(GameObject purpleObject)
    {
        await purpleObject.transform.DOScale(endScale, changeTime).AsyncWaitForCompletion();
        isScaleChange = false;
    }
}