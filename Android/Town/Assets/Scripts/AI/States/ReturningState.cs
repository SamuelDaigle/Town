using UnityEngine;
using System.Collections;

namespace AI
{
    public class ReturningState : IState
    {
        private Character parent;

        public ReturningState(Character _parent)
        {
            parent = _parent;
        }

        public void Start()
        {
            parent.SetTarget("TownHall");
        }

        public void Update()
        {
            parent.MoveToTarget();
            Vector3 distanceVector = parent.GetTargetPosition() - parent.GetPosition();
            if (distanceVector.magnitude < 1.0f)
            {
                parent.SetClassTarget();
                parent.StoreResource();
                parent.NextState();
            }
        }
    }
}
