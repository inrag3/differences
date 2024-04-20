using System;
using Game.UI.Windows;
using UnityEngine;

public class Contoller : MonoBehaviour
{
    private Window _window;

    private void Awake()
    {
        _window = GetComponent<Window>();
    }

    private void OnEnable()
    {
        _window.Panel.Button.onClick.AddListener(OnRestartClicked);
    }

    private void OnDisable()
    {
        _window.Panel.Button.onClick.RemoveListener(OnRestartClicked);
    }
    
    private void OnRestartClicked()
    {
        print("Restart Clicked!");
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Show();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Hide();
        }
    }

    private void Show()
    {
        _window.Show();
    }

    private void Hide()
    {
        _window.Hide();
    }
}