using UnityEngine;
using System.Collections;

namespace VillagerAI
{
	public class ResetState : IState
	{
	    private Character parent;
	
	    public ResetState(Character _parent)
	    {
	        parent = _parent;
	    }

        public void Start()
        {
            // Changes state to the first state while resetting everything.
            parent.ResetState();
        }

        public void Update()
        {
        }
	}
}
