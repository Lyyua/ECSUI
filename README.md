流程简介：随着时间的增加，不断的生产水晶，水晶充足时可以释放技能。暂停后，可以选择时间戳定位到某个时刻的记录，并且从当前时刻继续流程。

总水晶
>* ElixirComponent
>* 参与响应的System 
>>* NotifyElixirListenerSystem 水晶减少，触发消费回调，UI变化。

消费水晶的回调组件
>* ElixirListenerComponent

帧数组件
>* TickComponent
>* 参与响应的System 
>>* TickUpdateSystem
>>* ProduceElixirSystem   非暂停情况下，随着时间进行，不断的产生水晶。

释放技能消费水晶
>* ConsumpElixirComponent
>* 参与响应的System 
>>* ConsumeElixirSystem，点击按钮消费水晶，水晶数量减少。
>>* ConsumeElixirLogSystem 技能消费Log

技能名称
>* ConsumpNameComponent

消费记录组件
>* ConsumptionHistoryComponent

销毁组件
>* DestroyComponent
>* 参与响应的System 
>* DestroySystem 销毁集中在一帧处理

暂停
>* PauseComponent
>* 参与响应的System 
>>* NotifyPauseListenerSystem   触发暂停监听，比如UI变化
>>* CleanUpConsumptionHistorySystem   清空无用的消费记录

暂停回调组件
>* PauseListenerComponent

选定时间戳
>* JumpInTimeComponent
>* 参与响应的System 
>>* TimePickSystem   定位到某个时间点

帧数变化回调
>* TickListenerComponent
>* 参与响应的System 
>>* NotifyTickListenerSystem  帧数更新