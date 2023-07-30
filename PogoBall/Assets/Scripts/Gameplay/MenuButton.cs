using System.Collections;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private HUD _hud;

    private void OnMouseDown()
    {
        _hud.Menu();
    }
}