//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UIContext {

    public UIEntity jumpInTimeEntity { get { return GetGroup(UIMatcher.JumpInTime).GetSingleEntity(); } }
    public JumpInTimeComponent jumpInTime { get { return jumpInTimeEntity.jumpInTime; } }
    public bool hasJumpInTime { get { return jumpInTimeEntity != null; } }

    public UIEntity SetJumpInTime(long newTargetTick) {
        if (hasJumpInTime) {
            throw new Entitas.EntitasException("Could not set JumpInTime!\n" + this + " already has an entity with JumpInTimeComponent!",
                "You should check if the context already has a jumpInTimeEntity before setting it or use context.ReplaceJumpInTime().");
        }
        var entity = CreateEntity();
        entity.AddJumpInTime(newTargetTick);
        return entity;
    }

    public void ReplaceJumpInTime(long newTargetTick) {
        var entity = jumpInTimeEntity;
        if (entity == null) {
            entity = SetJumpInTime(newTargetTick);
        } else {
            entity.ReplaceJumpInTime(newTargetTick);
        }
    }

    public void RemoveJumpInTime() {
        jumpInTimeEntity.Destroy();
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

    public JumpInTimeComponent jumpInTime { get { return (JumpInTimeComponent)GetComponent(UIComponentsLookup.JumpInTime); } }
    public bool hasJumpInTime { get { return HasComponent(UIComponentsLookup.JumpInTime); } }

    public void AddJumpInTime(long newTargetTick) {
        var index = UIComponentsLookup.JumpInTime;
        var component = CreateComponent<JumpInTimeComponent>(index);
        component.targetTick = newTargetTick;
        AddComponent(index, component);
    }

    public void ReplaceJumpInTime(long newTargetTick) {
        var index = UIComponentsLookup.JumpInTime;
        var component = CreateComponent<JumpInTimeComponent>(index);
        component.targetTick = newTargetTick;
        ReplaceComponent(index, component);
    }

    public void RemoveJumpInTime() {
        RemoveComponent(UIComponentsLookup.JumpInTime);
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

    static Entitas.IMatcher<UIEntity> _matcherJumpInTime;

    public static Entitas.IMatcher<UIEntity> JumpInTime {
        get {
            if (_matcherJumpInTime == null) {
                var matcher = (Entitas.Matcher<UIEntity>)Entitas.Matcher<UIEntity>.AllOf(UIComponentsLookup.JumpInTime);
                matcher.componentNames = UIComponentsLookup.componentNames;
                _matcherJumpInTime = matcher;
            }

            return _matcherJumpInTime;
        }
    }
}