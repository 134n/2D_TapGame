using UnityEngine;
using UniRx;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private Button startButton;

    private void Start()
    {
        startButton.OnClickAsObservable()
            .Subscribe(_ => { SceneManager.LoadScene("Main"); })
            .AddTo(this);
    }
}
