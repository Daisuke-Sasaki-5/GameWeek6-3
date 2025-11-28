using UnityEngine;

public class EnvironmentAudioManager : MonoBehaviour
{
    [Header("メイン環境音")]
    public AudioSource windSource;

    [Header("サブ環境音")]
    public AudioSource leafSource;

    [Header("虫の環境音")]
    public AudioSource ambientSource;

    // 音揺れ用
    private float windBaseVolume;
    private float leafBaseVolume;

    void Start()
    {
        windBaseVolume = windSource.volume;
        leafBaseVolume = leafSource.volume;

        // ループ開始
        windSource.Play();
        leafSource.Play();
        ambientSource.Play();
    }

    
    void Update()
    {
        // ==== 音量を自然に揺らす ====
        windSource.volume = windBaseVolume + Mathf.Sin(Time.time * 0.2f) * 0.03f;
        leafSource.volume = leafBaseVolume + Mathf.Sin(Time.time * 0.35f + 1.5f) * 0.2f;

        // ピッチもわずかに揺らす
        windSource.pitch = 1.0f + Mathf.Sin(Time.time * 0.15f) * 0.02f;
    }
}
