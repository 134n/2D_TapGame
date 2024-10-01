using UnityEngine;
using UniRx;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UniRx.Async;

public class StartButtonUI : MonoBehaviour
{
    [SerializeField] private Button startButton;

    [SerializeField] private StartButtonSE startButtonSE;

    private const string MainSceneName = "Main";

    private void Start()
    {
        var token = this.GetCancellationTokenOnDestroy();

        startButton.OnClickAsObservable()
            .Subscribe(async _ =>
            {
                await startButtonSE.WaitForButtonSoundToPlay(token);
                SceneManager.LoadScene(MainSceneName);
            })
            .AddTo(this);
    }
}