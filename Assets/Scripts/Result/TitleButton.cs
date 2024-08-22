using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButton : MonoBehaviour
{
    [SerializeField] private Button Title;

    private void Start()
    {
        Title.OnClickAsObservable()
            .Subscribe(_ => { SceneManager.LoadScene("Title"); })
            .AddTo(this);

    }
}
