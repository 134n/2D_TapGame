using UnityEngine;
using UniRx;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButtonUI : MonoBehaviour
{
    [SerializeField] private Button startButton;

    private const string MainSceneName = "Main";

    private void Start()
    {
        startButton.OnClickAsObservable()
            .Subscribe(_ => { SceneManager.LoadScene(MainSceneName); })
            .AddTo(this);
    }
}
