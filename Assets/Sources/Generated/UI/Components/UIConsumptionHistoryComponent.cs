//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UIContext {

    public UIEntity consumptionHistoryEntity { get { return GetGroup(UIMatcher.ConsumptionHistory).GetSingleEntity(); } }
    public ConsumptionHistoryComponent consumptionHistory { get { return consumptionHistoryEntity.consumptionHistory; } }
    public bool hasConsumptionHistory { get { return consumptionHistoryEntity != null; } }

    public UIEntity SetConsumptionHistory(System.Collections.Generic.List<ConsumptionEntry> newHistoryCosump) {
        if (hasConsumptionHistory) {
            throw new Entitas.EntitasException("Could not set ConsumptionHistory!\n" + this + " already has an entity with ConsumptionHistoryComponent!",
                "You should check if the context already has a consumptionHistoryEntity before setting it or use context.ReplaceConsumptionHistory().");
        }
        var entity = CreateEntity();
        entity.AddConsumptionHistory(newHistoryCosump);
        return entity;
    }

    public void ReplaceConsumptionHistory(System.Collections.Generic.List<ConsumptionEntry> newHistoryCosump) {
        var entity = consumptionHistoryEntity;
        if (entity == null) {
            entity = SetConsumptionHistory(newHistoryCosump);
        } else {
            entity.ReplaceConsumptionHistory(newHistoryCosump);
        }
    }

    public void RemoveConsumptionHistory() {
        consumptionHistoryEntity.Destroy();
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

    public ConsumptionHistoryComponent consumptionHistory { get { return (ConsumptionHistoryComponent)GetComponent(UIComponentsLookup.ConsumptionHistory); } }
    public bool hasConsumptionHistory { get { return HasComponent(UIComponentsLookup.ConsumptionHistory); } }

    public void AddConsumptionHistory(System.Collections.Generic.List<ConsumptionEntry> newHistoryCosump) {
        var index = UIComponentsLookup.ConsumptionHistory;
        var component = CreateComponent<ConsumptionHistoryComponent>(index);
        component.historyCosump = newHistoryCosump;
        AddComponent(index, component);
    }

    public void ReplaceConsumptionHistory(System.Collections.Generic.List<ConsumptionEntry> newHistoryCosump) {
        var index = UIComponentsLookup.ConsumptionHistory;
        var component = CreateComponent<ConsumptionHistoryComponent>(index);
        component.historyCosump = newHistoryCosump;
        ReplaceComponent(index, component);
    }

    public void RemoveConsumptionHistory() {
        RemoveComponent(UIComponentsLookup.ConsumptionHistory);
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

    static Entitas.IMatcher<UIEntity> _matcherConsumptionHistory;

    public static Entitas.IMatcher<UIEntity> ConsumptionHistory {
        get {
            if (_matcherConsumptionHistory == null) {
                var matcher = (Entitas.Matcher<UIEntity>)Entitas.Matcher<UIEntity>.AllOf(UIComponentsLookup.ConsumptionHistory);
                matcher.componentNames = UIComponentsLookup.componentNames;
                _matcherConsumptionHistory = matcher;
            }

            return _matcherConsumptionHistory;
        }
    }
}
