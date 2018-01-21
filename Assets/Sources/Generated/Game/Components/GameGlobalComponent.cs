//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity globalEntity { get { return GetGroup(GameMatcher.Global).GetSingleEntity(); } }
    public GlobalComponent global { get { return globalEntity.global; } }
    public bool hasGlobal { get { return globalEntity != null; } }

    public GameEntity SetGlobal(Global newGlobal) {
        if (hasGlobal) {
            throw new Entitas.EntitasException("Could not set Global!\n" + this + " already has an entity with GlobalComponent!",
                "You should check if the context already has a globalEntity before setting it or use context.ReplaceGlobal().");
        }
        var entity = CreateEntity();
        entity.AddGlobal(newGlobal);
        return entity;
    }

    public void ReplaceGlobal(Global newGlobal) {
        var entity = globalEntity;
        if (entity == null) {
            entity = SetGlobal(newGlobal);
        } else {
            entity.ReplaceGlobal(newGlobal);
        }
    }

    public void RemoveGlobal() {
        globalEntity.Destroy();
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
public partial class GameEntity {

    public GlobalComponent global { get { return (GlobalComponent)GetComponent(GameComponentsLookup.Global); } }
    public bool hasGlobal { get { return HasComponent(GameComponentsLookup.Global); } }

    public void AddGlobal(Global newGlobal) {
        var index = GameComponentsLookup.Global;
        var component = CreateComponent<GlobalComponent>(index);
        component.global = newGlobal;
        AddComponent(index, component);
    }

    public void ReplaceGlobal(Global newGlobal) {
        var index = GameComponentsLookup.Global;
        var component = CreateComponent<GlobalComponent>(index);
        component.global = newGlobal;
        ReplaceComponent(index, component);
    }

    public void RemoveGlobal() {
        RemoveComponent(GameComponentsLookup.Global);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGlobal;

    public static Entitas.IMatcher<GameEntity> Global {
        get {
            if (_matcherGlobal == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Global);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGlobal = matcher;
            }

            return _matcherGlobal;
        }
    }
}