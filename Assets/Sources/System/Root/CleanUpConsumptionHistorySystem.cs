using System;
using System.Collections.Generic;
using Entitas;

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
    }

    protected override bool Filter(UIEntity entity)
    {
        return true;
    }

    protected override ICollector<UIEntity> GetTrigger(IContext<UIEntity> context)
    {
        return null;
    }
}
