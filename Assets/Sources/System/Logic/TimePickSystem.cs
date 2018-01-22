using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

/// <summary>
///  回放时定位帧数
/// </summary>
public class TimePickSystem : ReactiveSystem<UIEntity>
{
    private Contexts _contexts;

    public TimePickSystem(Contexts contexts) : base(contexts.uI)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<UIEntity> entities)
    {
        var e = entities[0];
        int t = (int)e.jumpInTime.targetTick;
        float amount = _contexts.uI.consumptionHistory.historyCosump[t].amount;
        _contexts.uI.ReplaceElixir(amount);
        _contexts.uI.jumpInTimeEntity.tickListener.listener.TickChanged(e.jumpInTime.targetTick);
    }

    protected override bool Filter(UIEntity entity)
    {
        return entity.hasJumpInTime;
    }

    protected override ICollector<UIEntity> GetTrigger(IContext<UIEntity> context)
    {
        return context.CreateCollector(UIMatcher.JumpInTime);
    }
}
