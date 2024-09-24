using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    private float Count = 10;

    private const string LoadResultScene = "Result";

    private void Update()
    {
        Count -= Time.deltaTime;

        if (Count < 0) ToResult();

        Debug.Log((int)Count);
    }

    /// <summary>
    /// リザルトに遷移
    /// </summary>
    private void ToResult() => SceneManager.LoadScene(LoadResultScene);
}
