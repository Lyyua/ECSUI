using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class TimePickBehaviour : MonoBehaviour, IPauseListener
{
    [SerializeField]
    private Slider slider;
    Contexts _contexts;

    UIEntity jumpInTime;

    private void Awake()
    {
        _contexts = Contexts.sharedInstance;
        _contexts.uI.CreateEntity().AddPauseListener(this);

        slider.onValueChanged.AddListener(ChangeValue);
        this.gameObject.SetActive(false);
    }


    public void ChangeValue(float value)
    {
        float targetTick = value * _contexts.uI.tick.tick;
        jumpInTime.ReplaceJumpInTime((long)targetTick);
    }

    public void PauseStateChanged(bool isPause)
    {
        if (isPause)
        {
            jumpInTime = _contexts.uI.CreateEntity();
            slider.value = 1;
        }
        else
        {
            jumpInTime.Destroy();
        }
        this.gameObject.SetActive(isPause);
    }
}
