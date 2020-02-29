using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOpenable
{
    bool IsOpening { get; }
    event Action OnOpen;
    event Action OnOpened;
    event Action OnClose;
    event Action OnClosed;
    void Open();
    void Close();
}
