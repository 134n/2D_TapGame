using System.Threading;
using UniRx.Async;
using UnityEngine;

public class StartButtonSE : MonoBehaviour
{
    [SerializeField] private AudioSource startButtonAudioSource;

    public void Play()
    {
        startButtonAudioSource.Play();
    }
    
    public async UniTask WaitForPlay(CancellationToken token)
    {
        await UniTask.WaitUntil(() => !startButtonAudioSource.isPlaying,cancellationToken:token);
    }
}
