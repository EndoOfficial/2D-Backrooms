using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private bool timerDone;
    private void OnEnable()
    {
        Events.TimerOn += TimerStart;
    }
    private void OnDisable()
    {
        Events.TimerOn -= TimerStart;
    }
    private void TimerStart(bool spacePressed)
    {
        timerDone = false;
        LeanTween.scaleY(gameObject, 0, 0);
        LeanTween.scaleY(gameObject, 160, 1.5f)
            .setOnComplete(() => timerDone = true)
            .setOnComplete(() => Events.TimerDone?.Invoke(timerDone));
    }
}
