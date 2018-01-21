using System;
using System.Collections.Generic;
using Entitas;

/// <summary>
/// 记录帧
/// </summary>
public class NotifyTickListenerSystem : ReactiveSystem<UIEntity>
{
    private Contexts _contexts;

    IGroup<UIEntity> listeners;
    public NotifyTickListenerSystem(Contexts contexts) : base(contexts.uI)
    {

        _contexts = contexts;
        listeners = contexts.uI.GetGroup(UIMatcher.TickListener);
    }

    protected override void Execute(List<UIEntity> entities)
    {
        var e = entities[0];
        foreach (var item in listeners)
        {
            item.tickListener.listener.TickChanged(e.tick.tick);
        }

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
