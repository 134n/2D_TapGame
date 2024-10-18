using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToTitleButton : MonoBehaviour
{
    [SerializeField] private Button titleButton;

    private const string LoadTitleScene = "Title";

    private void Start()
    {
        titleButton.OnClickAsObservable()
            .Subscribe(_ => { SceneManager.LoadScene(LoadTitleScene); })
            .AddTo(this);
    }
}
