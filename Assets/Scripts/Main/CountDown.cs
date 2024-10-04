using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using UniRx.Triggers;

public class CountDown : MonoBehaviour
{
    private float Count = 10;

    private const string ResultSceneName = "Result";
    
    private void Start()
    {
        this.UpdateAsObservable()
            .Select(_=>  Count -= Time.deltaTime)
            .Where(_=> Count < 0)
            .Subscribe(_ =>SceneManager.LoadScene(ResultSceneName))
            .AddTo(this);
    }
}
