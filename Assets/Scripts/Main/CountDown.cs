using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    public ObjectScaleChange objectScaleChange;
    private float Count = 10;
    private const string loadResultScene = "Result";
    private void Start()
    {
        this.UpdateAsObservable()
            .Select(_=>  Count -= Time.deltaTime)
            .Where(_=> Count < 0)
            .Subscribe(_ =>{
            
            Debug.Log(Count);

            if (objectScaleChange.IsScaleChange) return;

            SceneManager.LoadScene(loadResultScene);
        });
    }
}
