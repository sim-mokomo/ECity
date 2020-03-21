using System;

public interface IOpenable
{
    bool IsOpening { get; }
    event Action OnOpen;
    event Action OnOpened;
    event Action OnClose;
    event Action OnClosed;
    void Open(bool immediately = false);
    void Close(bool immediately = false);
}