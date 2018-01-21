using UnityEngine;
using Entitas.Unity;
using System.Collections;
using System;
using UnityEngine.UI;

public class ElixirBarBehaviour : MonoBehaviour, IElixirListener
{
    Contexts _contexts;

    public Image _image;
    public Text elixirText;
    private void Awake()
    {
        _contexts = Contexts.sharedInstance;
        var e = _contexts.uI.CreateEntity();
        e.AddElixirListener(this);
    }
    public void ElixirAmountChanged(float amount)
    {
        _image.fillAmount = amount / _contexts.game.global.global.elixirCapcity;
        elixirText.text = Math.Floor(amount).ToString();
    }
}
