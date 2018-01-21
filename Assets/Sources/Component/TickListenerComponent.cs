using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;

[UI]
public class TickListenerComponent : IComponent
{
    public ITickListener listener;
}

