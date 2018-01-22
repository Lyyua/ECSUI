using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class TimePickBehaviour : MonoBehaviour, IPauseListener
{
    [SerializeField]
    private Slider slider;
    Contexts _contexts;

    UIEntity jumpInTime = null;

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
        this.gameObject.SetActive(isPause);
        if (isPause)
        {
            if (_contexts.uI.hasJumpInTime)
            {
                jumpInTime = _contexts.uI.jumpInTimeEntity;
            }
            else
            {
                jumpInTime = _contexts.uI.CreateEntity();
            }
            slider.enabled = true;
            slider.value = 1;
            ChangeValue(1);
        }
        else
        {
            jumpInTime.Destroy();
            jumpInTime = null;
        }
    }
}
