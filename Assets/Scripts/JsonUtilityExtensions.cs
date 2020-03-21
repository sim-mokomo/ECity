using UnityEngine;

public static class JsonUtilityExtensions
{
    public static T FunctionResult2Instance<T>(object functionResult, T writeObj)
    {
        var json = functionResult.ToString();
        Debug.Log(json);
        JsonUtility.FromJsonOverwrite(json, writeObj);
        return writeObj;
    }

    public static T FunctionResult2Instance<T>(object functionResult)
    {
        var json = functionResult.ToString();
        Debug.Log(json);
        return JsonUtility.FromJson<T>(json);
    }
}