using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System;

namespace VillagerAI
{
	public class CollectingState : IState
	{
        private Timer timer;
        private Character parent;

        public CollectingState(Character _parent)
        {
            parent = _parent;
            timer = new Timer();
        }

        public void Start()
        {
            timer.Start(TimeSpan.FromSeconds(2));
        }

        public void Update()
        {
            if (timer.IsTimeFinished())
            {
                parent.CollectResource();
                parent.NextState();
            }
        }
	}
}

