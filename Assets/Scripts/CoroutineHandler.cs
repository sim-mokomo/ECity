using UnityEngine;

public class CoroutineHandler : SingletonMonobehaivor<CoroutineHandler>
{
    public void StopCoroutine(Coroutine handler)
    {
        if (handler == null)
            return;
        base.StopCoroutine(handler);
        handler = null;
    }
}