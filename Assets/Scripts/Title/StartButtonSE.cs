using System.Threading;
using UniRx.Async;
using UnityEngine;

public class StartButtonSE : MonoBehaviour
{
    [SerializeField] private AudioSource startButtonAudioSource;

    public async UniTask WaitForButtonSoundToPlay(CancellationToken token)
    {
        startButtonAudioSource.Play();
        await UniTask.WaitUntil(() => !startButtonAudioSource.isPlaying,cancellationToken:token);
    }
}
