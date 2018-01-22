using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

/// <summary>
/// 清除记录，如果需要的话
/// </summary>
public class CleanUpConsumptionHistorySystem : ReactiveSystem<UIEntity>
{
    private Contexts _contexts;

    public CleanUpConsumptionHistorySystem(Contexts contexts) : base(contexts.uI)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<UIEntity> entities)
    {
        int maxIndex = _contexts.uI.consumptionHistory.historyCosump.Count - 1;
        int count = maxIndex - (int)_contexts.uI.tick.tick;
        _contexts.uI.consumptionHistory.historyCosump.RemoveRange((int)_contexts.uI.tick.tick + 1, count);
    }

    protected override bool Filter(UIEntity entity)
    {
        return !entity.isPause;
    }

    protected override ICollector<UIEntity> GetTrigger(IContext<UIEntity> context)
    {
        return context.CreateCollector(UIMatcher.Pause);
    }
}
