using System;
using System.Collections.Generic;
using Entitas;

/// <summary>
/// 消费水晶时触发  
/// </summary>
public class ConsumeElixirSystem : ReactiveSystem<UIEntity>
{
    private Contexts _contexts;

    public ConsumeElixirSystem(Contexts contexts) : base(contexts.uI)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<UIEntity> entities)
    {
        foreach (var item in entities)
        {
            var newAmount = _contexts.uI.elixir.amount - item.consumpElixir.amount;
            _contexts.uI.ReplaceElixir(newAmount);
            item.Destroy();
        }
    }

    protected override bool Filter(UIEntity entity)
    {
        return entity.hasConsumpElixir;
    }

    protected override ICollector<UIEntity> GetTrigger(IContext<UIEntity> context)
    {
        return context.CreateCollector(UIMatcher.ConsumpElixir);
    }
}
