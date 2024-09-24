using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButtonUI : MonoBehaviour
{
    [SerializeField] private Button Title;

    private const string LoadTitleScene = "Title";

    private void Start()
    {
        Title.OnClickAsObservable()
            .Subscribe(_ => { SceneManager.LoadScene(LoadTitleScene); })
            .AddTo(this);
    }
}
