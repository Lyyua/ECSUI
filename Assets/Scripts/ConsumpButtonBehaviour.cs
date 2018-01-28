using UnityEngine;
using Entitas.Unity;
using System.Collections;
using System;
using UnityEngine.UI;

public class ConsumpButtonBehaviour : MonoBehaviour, IPauseListener, IElixirListener
{
    Contexts _contexts;

    [SerializeField]
    private int consumptionAmount = 3;
    [SerializeField]
    private string skillName = "";
    UIEntity consumpEntity;
    Image _image;
    [SerializeField]
    Text _skillText;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _skillText.text = skillName;
        _contexts = Contexts.sharedInstance;
        consumpEntity = _contexts.uI.CreateEntity();
        consumpEntity.AddElixirListener(this);
        consumpEntity.AddPauseListener(this);
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonPressed);
    }
    public void ElixirAmountChanged(float amount)
    {
        _image.fillAmount = amount / consumptionAmount;
    }
    public void PauseStateChanged(bool isPause)
    {
        gameObject.GetComponent<Button>().enabled = !isPause;
    }

    public void ButtonPressed()
    {
        if (_image.fillAmount < 1) return;
        var e = _contexts.uI.CreateEntity();
        e.AddConsumpElixir(consumptionAmount);
        e.AddConsumpName(skillName);
    }
}
