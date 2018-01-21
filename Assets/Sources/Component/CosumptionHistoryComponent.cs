using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;

/// <summary>
/// 消费记录
/// </summary>
[UI, Unique]
public class ConsumptionHistoryComponent : IComponent
{
    public List<ConsumptionEntry> historyCosump;
}

public class ConsumptionEntry
{
    public readonly long tick;
    public readonly float amount;

    public ConsumptionEntry(long _tick, float _amount)
    {
        tick = _tick;
        amount = _amount;
    }
}

