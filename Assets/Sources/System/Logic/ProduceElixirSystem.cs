using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

/// <summary>
/// 生产水晶，更新所有技能图标
/// </summary>
public class ProduceElixirSystem : ReactiveSystem<UIEntity>, IInitializeSystem
{
    private Contexts _contexts;

    public ProduceElixirSystem(Contexts contexts) : base(contexts.uI)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        _contexts.uI.ReplaceElixir(0);
    }

    protected override void Execute(List<UIEntity> entities)
    {
        var newAmount = _contexts.uI.elixir.amount + 0.02f;
        float minAmount = Math.Min(_contexts.game.global.global.elixirCapcity, newAmount);
        _contexts.uI.ReplaceElixir(minAmount);
    }

    protected override bool Filter(UIEntity entity)
    {
        return entity.hasTick;
    }

    protected override ICollector<UIEntity> GetTrigger(IContext<UIEntity> context)
    {
        return context.CreateCollector(UIMatcher.Tick);
    }
}
