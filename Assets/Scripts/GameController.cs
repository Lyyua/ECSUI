using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Systems _systems;
    private Contexts _contexts;
    public Global global;
    private void Awake()
    {
        _contexts = Contexts.sharedInstance;
        _contexts.game.SetGlobal(global);
        _systems = CreateSystems(_contexts);
        _systems.Initialize();
    }

    private void FixedUpdate()
    {
        _systems.Execute();
        _systems.Cleanup();
    }

    private void OnDestroy()
    {
        _systems.TearDown();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("ECSUI")
          .Add(new TickUpdateSystem())
          .Add(new NotifyTickListenerSystem(contexts))
           .Add(new NotifyPauseListenerSystem(contexts))
          .Add(new ProduceElixirSystem(contexts))
            .Add(new NotifyElixirListenerSystem(contexts))
                .Add(new TimePickSystem(contexts))
              .Add(new ConsumeElixirSystem(contexts))
            ;
    }
}
