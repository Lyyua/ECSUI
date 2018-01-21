using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;

/// <summary>
/// 消费水晶的回调
/// </summary>
[UI]
public class ElixirListenerComponent : IComponent
{
    public IElixirListener listener;
}

