using UnityEngine;
using System.Collections;

public interface IResource
{
    int GetCount();
    void Add(int count = 1);
}
