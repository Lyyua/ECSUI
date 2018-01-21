//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UIContext {

    public UIEntity tickEntity { get { return GetGroup(UIMatcher.Tick).GetSingleEntity(); } }
    public TickComponent tick { get { return tickEntity.tick; } }
    public bool hasTick { get { return tickEntity != null; } }

    public UIEntity SetTick(long newTick) {
        if (hasTick) {
            throw new Entitas.EntitasException("Could not set Tick!\n" + this + " already has an entity with TickComponent!",
                "You should check if the context already has a tickEntity before setting it or use context.ReplaceTick().");
        }
        var entity = CreateEntity();
        entity.AddTick(newTick);
        return entity;
    }

    public void ReplaceTick(long newTick) {
        var entity = tickEntity;
        if (entity == null) {
            entity = SetTick(newTick);
        } else {
            entity.ReplaceTick(newTick);
        }
    }

    public void RemoveTick() {
        tickEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UIEntity {

    public TickComponent tick { get { return (TickComponent)GetComponent(UIComponentsLookup.Tick); } }
    public bool hasTick { get { return HasComponent(UIComponentsLookup.Tick); } }

    public void AddTick(long newTick) {
        var index = UIComponentsLookup.Tick;
        var component = CreateComponent<TickComponent>(index);
        component.tick = newTick;
        AddComponent(index, component);
    }

    public void ReplaceTick(long newTick) {
        var index = UIComponentsLookup.Tick;
        var component = CreateComponent<TickComponent>(index);
        component.tick = newTick;
        ReplaceComponent(index, component);
    }

    public void RemoveTick() {
        RemoveComponent(UIComponentsLookup.Tick);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class UIMatcher {

    static Entitas.IMatcher<UIEntity> _matcherTick;

    public static Entitas.IMatcher<UIEntity> Tick {
        get {
            if (_matcherTick == null) {
                var matcher = (Entitas.Matcher<UIEntity>)Entitas.Matcher<UIEntity>.AllOf(UIComponentsLookup.Tick);
                matcher.componentNames = UIComponentsLookup.componentNames;
                _matcherTick = matcher;
            }

            return _matcherTick;
        }
    }
}