using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SingletonMonobehaivor<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                Type type = typeof(T);
                _instance = FindObjectOfType(type) as T;
                if(_instance == null)
                {
                    Debug.LogError($"{type.Name}がシーンに見つかりませんでした。");
                }
            }
            return _instance;
        }
    }

}