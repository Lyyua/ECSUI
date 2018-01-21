using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;

[Game, Unique]
public class GlobalComponent : IComponent
{
    public Global global;
}

