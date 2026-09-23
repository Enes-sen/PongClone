using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Ball _Ball;
    [SerializeField] private PlayerController _Pl;
    [SerializeField] private UiController _UIController;
    private ScoreController _scoreController;
    private void Start() 
    {
        Time.timeScale = 1;
        _scoreController = GetComponent<ScoreController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _Pl.enabled = true;
        _Ball.OnStart(); 
    }
    private void OnEnable()
    {
      if(_Ball)  _Ball.OnGoal += GBall_OnGoals;
    }
    private void OnDisable()
    {
        if (_Ball) _Ball.OnGoal -= GBall_OnGoals;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            _Ball.OnStart();
    }
    private void GBall_OnGoals(Side side)
    {
        if (!_scoreController.IsWin())
            HandleScore(side);
    }

    void HandleScore(Side side)
    {
        _scoreController.IncreaseSide(side);
        _UIController.UpdateScore(side, _scoreController);
        if (!_scoreController.IsWin())
            _Ball.OnStart();
        else if (_scoreController.IsWin())
        {
            _Pl.enabled = false;
            _UIController.ShowWiner(_scoreController.Winside());
            return;
        }

    }
}
