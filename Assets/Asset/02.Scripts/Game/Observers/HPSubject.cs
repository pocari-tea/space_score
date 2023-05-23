using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSubject
{
    private List<IHPObserver> _observers = new List<IHPObserver>();

    public void AddObserver(IHPObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IHPObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.HP();
        }
    }
}
