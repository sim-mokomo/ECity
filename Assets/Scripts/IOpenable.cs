using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOpenable
{
    bool IsOpening { get; }
    event Action OnOpen;
    event Action OnClose;
    void Open();
    void Close();
}
