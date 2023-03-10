using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeSound : MonoBehaviour
{
    [SerializeField]private PlayerMovement player;
    private float footStepsTimer;
    private float footStepsTimerMax;
    private void Awake()
    {
        footStepsTimerMax = 0.1f;
    }
    // Update is called once per frame
    void Update()
    {
        footStepsTimer -= Time.deltaTime;
        {
            if (footStepsTimer < 0f)
            {
                footStepsTimer = footStepsTimerMax;

                if(player.IsWalking())
                    SoundManager.Instance.PLayFootSteps(player.transform.position, 1);
            }
        }
    }
}
