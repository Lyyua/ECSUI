//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UIEntity {

    public PauseListenerComponent pauseListener { get { return (PauseListenerComponent)GetComponent(UIComponentsLookup.PauseListener); } }
    public bool hasPauseListener { get { return HasComponent(UIComponentsLookup.PauseListener); } }

    public void AddPauseListener(IPauseListener newPauseListener) {
        var index = UIComponentsLookup.PauseListener;
        var component = CreateComponent<PauseListenerComponent>(index);
        component.pauseListener = newPauseListener;
        AddComponent(index, component);
    }

    public void ReplacePauseListener(IPauseListener newPauseListener) {
        var index = UIComponentsLookup.PauseListener;
        var component = CreateComponent<PauseListenerComponent>(index);
        component.pauseListener = newPauseListener;
        ReplaceComponent(index, component);
    }

    public void RemovePauseListener() {
        RemoveComponent(UIComponentsLookup.PauseListener);
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

    static Entitas.IMatcher<UIEntity> _matcherPauseListener;

    public static Entitas.IMatcher<UIEntity> PauseListener {
        get {
            if (_matcherPauseListener == null) {
                var matcher = (Entitas.Matcher<UIEntity>)Entitas.Matcher<UIEntity>.AllOf(UIComponentsLookup.PauseListener);
                matcher.componentNames = UIComponentsLookup.componentNames;
                _matcherPauseListener = matcher;
            }

            return _matcherPauseListener;
        }
    }
}
