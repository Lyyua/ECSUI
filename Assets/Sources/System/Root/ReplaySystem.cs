using System;
using System.Collections.Generic;
using Entitas;

/// <summary>
/// 如果回放系统比现在版本更复杂
/// </summary>
public class ReplaySystem : ReactiveSystem<UIEntity>
{
    private Contexts _contexts;

    public ReplaySystem(Contexts contexts) : base(contexts.uI)
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
