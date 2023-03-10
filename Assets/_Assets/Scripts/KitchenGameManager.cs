using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenGameManager : MonoBehaviour
{
    public static KitchenGameManager Instance { get; private set; }
    public event EventHandler OnStateChanged;
    private enum State
    {
        WaitingToStart,
        CountDown,
        GamePlaying,
        GameOver,
    }
    private State state;
    private float waitingToStartTimer;
    private float countDownTimer;
    private float gamePlayingTimer;
    private float gamePlayingTimerMax;



    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        countDownTimer = 3f;
        gamePlayingTimerMax = 10f;
        gamePlayingTimer = 0;

        waitingToStartTimer = 1f;
        state = State.WaitingToStart;
    }
    private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if(waitingToStartTimer <= 0f)
                {
                    state = State.CountDown;
                }
                OnStateChanged?.Invoke(this, EventArgs.Empty);
                break;

            case State.CountDown:
                countDownTimer -= Time.deltaTime;
                if (countDownTimer <= 0f)
                {
                    state = State.GamePlaying;
                }
                OnStateChanged?.Invoke(this, EventArgs.Empty);
                gamePlayingTimer = gamePlayingTimerMax;
                break;

            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer <= 0f)
                {
                    state = State.GameOver;
                }
                OnStateChanged?.Invoke(this, EventArgs.Empty);

                break;

            case State.GameOver:
                OnStateChanged?.Invoke(this, EventArgs.Empty);

                break;
        }

        Debug.Log(state);
    }

    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }
    public bool IsCountDownActive()
    {
        return state == State.CountDown;
    }
    public float GetCountDownTimer()
    {
        return countDownTimer;
    }

    public bool IsGameOver()
    {
        return state == State.GameOver;
    }

    public float GetGamePlayingTimer()
    {
        return 1 - gamePlayingTimer / gamePlayingTimerMax;
    }
}
