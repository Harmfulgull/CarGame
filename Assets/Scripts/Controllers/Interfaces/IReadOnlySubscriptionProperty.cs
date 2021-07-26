
using System;

public interface IReadOnlySubscriptionProperty <T>
{
    T Value { get; }
    void SubscribeOnChange(Action<T> subscribeOnChange);
    void UnSubscribeOnChange(Action<T> UnSubscribeOnChange);

}
