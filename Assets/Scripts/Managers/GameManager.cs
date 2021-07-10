using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    static GameManager instance = null;

    public static GameManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        // Singleton
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
    }
    #endregion
    public enum PlayerStates
    {
        Idle,
        Walking,
        Running,
        Jumping,
        Inspect,
        Transport
    }
    public PlayerStates _playerStates;
/*
    public void ActivateLevel(GameObject levelPrefab, string desc)
    {
        Instantiate(levelPrefab);
        UIManager.Instance.InitPuzzleDescription(desc);
    }
    */
}
