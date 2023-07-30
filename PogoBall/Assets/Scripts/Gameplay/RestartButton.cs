using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private HUD _hud;

    private void OnMouseDown()
    {
        _hud.Restart();
    }
}
