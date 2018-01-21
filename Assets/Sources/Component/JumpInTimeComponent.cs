using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;

[UI, Unique]
public class JumpInTimeComponent : IComponent
{
    public long targetTick;
}

