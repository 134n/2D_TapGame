using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class ClickCountUI : MonoBehaviour
{
    [SerializeField] private Text clickPointText;

    public readonly ReactiveProperty<int> clickPoint = new();

    private void Start()
    {
        clickPoint.Subscribe(_ =>
        {
            clickPointText.text = $"Point:{clickPoint}";
        })
        .AddTo(this);
    }
    
    public void AddPoint(int addClickPoint)
    {
        clickPoint.Value += addClickPoint;
    }
}
