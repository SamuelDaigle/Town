using UnityEngine;
using System.Collections;

namespace VillagerAI
{
	public interface IState 
	{
        void Start();
        void Update();
	}
}
