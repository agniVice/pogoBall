using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings Instance;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else 
            Instance = this;

        DontDestroyOnLoad(gameObject);
    }
}
