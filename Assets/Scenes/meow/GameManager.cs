using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public c pool;
    public player player;

    private void Awake()
    {
        instance = this;
    }
}
