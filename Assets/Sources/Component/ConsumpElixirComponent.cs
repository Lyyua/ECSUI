using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;

/// <summary>
/// 可消费的总水晶数
/// </summary>
[UI]
public class ConsumpElixirComponent : IComponent
{
    public float amount;
}

