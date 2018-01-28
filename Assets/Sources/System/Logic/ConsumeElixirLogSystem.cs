using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

/// <summary>
/// 消费水晶时触发  
/// </summary>
public class ConsumeElixirLogSystem : ReactiveSystem<UIEntity>
{
    private Contexts _contexts;

    public ConsumeElixirLogSystem(Contexts contexts) : base(contexts.uI)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<UIEntity> entities)
    {
        foreach (var item in entities)
        {
            Debug.Log(item.consumpName.value);
            item.isDestroy = true;
        }
    }

    protected override bool Filter(UIEntity entity)
    {
        return entity.hasConsumpName;
    }

    protected override ICollector<UIEntity> GetTrigger(IContext<UIEntity> context)
    {
        return context.CreateCollector(UIMatcher.ConsumpElixir);
    }
}
