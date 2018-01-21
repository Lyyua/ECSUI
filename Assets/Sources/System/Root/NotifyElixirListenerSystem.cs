using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

/// <summary>
/// 响应水晶数量变化，图标更新
/// </summary>
public class NotifyElixirListenerSystem : ReactiveSystem<UIEntity>
{
    private Contexts _contexts;
    IGroup<UIEntity> listeners;
    public NotifyElixirListenerSystem(Contexts contexts) : base(contexts.uI)
    {
        _contexts = contexts;
        listeners = contexts.uI.GetGroup(UIMatcher.ElixirListener);
    }

    protected override void Execute(List<UIEntity> entities)
    {
        var e = entities[0];
        foreach (var item in listeners)
        {
            item.elixirListener.listener.ElixirAmountChanged(e.elixir.amount);
        }
        _contexts.uI.consumptionHistory.historyCosump.Add(new ConsumptionEntry(_contexts.uI.tick.tick, e.elixir.amount));
    }

    protected override bool Filter(UIEntity entity)
    {
        return entity.hasElixir;
    }

    protected override ICollector<UIEntity> GetTrigger(IContext<UIEntity> context)
    {
        return context.CreateCollector(UIMatcher.Elixir);
    }
}
