using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

/// <summary>
/// 消费水晶时触发  
/// </summary>
public class DestroySystem : ReactiveSystem<UIEntity>
{
    private Contexts _contexts;

    public DestroySystem(Contexts contexts) : base(contexts.uI)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<UIEntity> entities)
    {
        foreach (var item in entities)
        {
            item.Destroy();
        }
    }

    protected override bool Filter(UIEntity entity)
    {
        return entity.isDestroy;
    }

    protected override ICollector<UIEntity> GetTrigger(IContext<UIEntity> context)
    {
        return context.CreateCollector(UIMatcher.Destroy);
    }
}
