using System;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public static MainController Instance { get; set; }
    public event Action OnUpdate;
    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        OnUpdate?.Invoke();
    }
}
