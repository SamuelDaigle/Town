using UnityEngine;
using System.Collections;

public interface IClass 
{
    void SetStates();
    void AddResources(int count = 1);
    IResource GetResources();
    void Update();
    string GetMainTarget();
    string GetImagePath();
}
