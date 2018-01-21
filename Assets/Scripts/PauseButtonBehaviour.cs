using UnityEngine;
using Entitas.Unity;
using System.Collections;
using System;
using UnityEngine.UI;

public class PauseButtonBehaviour : MonoBehaviour, IPauseListener
{
    Contexts _contexts;

    UIEntity pauseEntity;
    public Text pauseText;

    private void Awake()
    {
        _contexts = Contexts.sharedInstance;
        _contexts.uI.CreateEntity().AddPauseListener(this);
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonPressed);
    }
    public void PauseStateChanged(bool isPause)
    {
        if (isPause)
        {
            pauseText.text = "Resume";
        }
        else
        {
            pauseText.text = "Pause";
        }
    }

    public void ButtonPressed()
    {
        if (!_contexts.uI.isPause)
        {
            _contexts.uI.isPause = true;
        }
        else
        {
            _contexts.uI.isPause = false;
            _contexts.uI.isPause = true;
            _contexts.uI.isPause = false;
        }
    }
}
