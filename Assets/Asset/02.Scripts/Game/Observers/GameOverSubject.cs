using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSubject
{
    private List<IGameOverObserver> _observers = new List<IGameOverObserver>();

    public void AddObserver(IGameOverObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IGameOverObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.GameOver();
        }
    }
}
