using UnityEngine;
using Entitas.Unity;
using System.Collections;
using System;
using UnityEngine.UI;

public class TimeUpdateBehaviour : MonoBehaviour, ITickListener, IPauseListener
{
    Contexts _contexts;
    public Text timeText;
    int sTime;
    int mTime;
    private void Awake()
    {
        _contexts = Contexts.sharedInstance;
        var e = _contexts.uI.CreateEntity();
        e.AddTickListener(this);
        e.AddPauseListener(this);
    }

    public void PauseStateChanged(bool isPause)
    {
        if (isPause)
        {
            if (!_contexts.uI.hasJumpInTime)
            {
                _contexts.uI.CreateEntity().AddTickListener(this);
            }
            else
            {
                _contexts.uI.jumpInTimeEntity.AddTickListener(this);
            }
        }
    }

    public void TickChanged(long tick)
    {
        int second = (int)(tick / 50);
        sTime = second % 60;
        mTime = second / 60;
        string mTimeStr = "";
        if (mTime < 10)
        {
            mTimeStr = "0" + mTime.ToString();
        }
        else
        {
            mTimeStr = mTime.ToString();
        }
        string sTimeStr = "";
        if (sTime < 10)
        {
            sTimeStr = "0" + sTime.ToString();
        }
        else
        {
            sTimeStr = sTime.ToString();
        }
        timeText.text = mTimeStr + ":" + sTimeStr;

    }
}
