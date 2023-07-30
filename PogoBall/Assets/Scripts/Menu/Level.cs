using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public bool IsLocked { get; private set; }

    [SerializeField] private int _id;

    private GameObject _lock;
    private TextMeshProUGUI _idText;

    private void Start()
    {
        Initialize();
    }
    public void Initialize()
    {
        _lock = transform.GetChild(0).gameObject;
        _idText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        GetComponent<Button>().onClick.AddListener(LoadLevel);

        if(_id == 1) PlayerPrefs.SetInt("LevelLocked" + _id, 0);
        IsLocked = Convert.ToBoolean(PlayerPrefs.GetInt("LevelLocked" + _id, 1));

        _lock.SetActive(IsLocked);
        _idText.gameObject.SetActive(!IsLocked);
        _idText.text = _id.ToString();
    }
    public void LoadLevel()
    {
        LevelManager.Instance.LoadLevel(this);
    }
    public int Id() => _id;
}