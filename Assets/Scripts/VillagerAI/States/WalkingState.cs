using UnityEngine;
using System.Collections;

namespace VillagerAI
{
    public class WalkingState : IState
    {
        private Character parent;

        public WalkingState(Character _parent)
        {
            parent = _parent;
            parent.SetClassTarget();
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            parent.MoveToTarget();
            Vector3 distanceVector = parent.GetTargetPosition() - parent.GetPosition();
            if (distanceVector.magnitude < 1.0f)
            {
                parent.NextState();
            }
        }
    }
}

