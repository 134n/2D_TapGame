using System.Threading;
using UniRx.Async;
using UnityEngine;

public class StartButtonSE : MonoBehaviour
{
    [SerializeField] private AudioSource startButtonAudioSource;

    public void StartButtonSoundToPlay()
    {
        startButtonAudioSource.Play();
    }
    
    public async UniTask WaitForButtonSoundToPlay(CancellationToken token)
    {
        await UniTask.WaitUntil(() => !startButtonAudioSource.isPlaying,cancellationToken:token);
    }
}
