using System;
using System.Collections.Generic;
using Entitas;

/// <summary>
/// 更新帧数
/// </summary>
public class TickUpdateSystem : IExecuteSystem, IInitializeSystem
{
    private Contexts _contexts;


    public void Initialize()
    {
        _contexts = Contexts.sharedInstance;
        _contexts.uI.ReplaceTick(0);
        List<ConsumptionEntry> list = new List<ConsumptionEntry>();
        list.Add(new ConsumptionEntry(0, 0));
        _contexts.uI.SetConsumptionHistory(list);
    }

    public void Execute()
    {
        if (!_contexts.uI.isPause)
        {
            _contexts.uI.ReplaceTick(_contexts.uI.tick.tick + 1);
        }
    }
}
