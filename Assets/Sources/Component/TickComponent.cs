using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;

[UI, Unique]
public class TickComponent : IComponent
{
    public long tick;
}

