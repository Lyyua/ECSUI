using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

/// <summary>
/// 记录帧
/// </summary>
public class NotifyPauseListenerSystem : ReactiveSystem<UIEntity>
{
    private Contexts _contexts;
    IGroup<UIEntity> listeners;
    public NotifyPauseListenerSystem(Contexts contexts) : base(contexts.uI)
    {
        _contexts = contexts;
        listeners = contexts.uI.GetGroup(UIMatcher.PauseListener);
    }

    protected override void Execute(List<UIEntity> entities)
    {
        var e = entities[0];
        foreach (var item in listeners)
        {
            item.pauseListener.pauseListener.PauseStateChanged(e.isPause);
        }
    }

    /// <summary>
    /// 这一块需要注意，不论isPause为true 还是false，我们都要进行监听的回调
    ///     通过以下的重置操作，可以使得过滤器响应false操作，相比之下，我宁愿在一个Component中定义一个字段，通过Replace来进行响应
    ///    _contexts.uI.isPause = false;
    ///    _contexts.uI.isPause = true;
    ///    _contexts.uI.isPause = false;
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    protected override bool Filter(UIEntity entity)
    {
        return true;
    }

    protected override ICollector<UIEntity> GetTrigger(IContext<UIEntity> context)
    {
        return context.CreateCollector(UIMatcher.Pause);
    }
}
