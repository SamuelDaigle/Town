using UnityEngine;
using System.Collections;

public class Gold : IResource
{
    int quantity = 0;

    public int GetCount()
    {
        return quantity;
    }

    public void Add(int count = 1)
    {
        quantity += count;
    }
}
