using UnityEngine;
using System.Collections;

namespace VillagerAI
{
	public class Blacksmith : IClass
	{
        private const string MAIN_TARGET = "Forge";
        private const string IMAGE_PATH = "Materials/Characters/M_Blacksmith";
        private Character parent;
        private Food resource;

        public Blacksmith(Character _parent)
	    {
            parent = _parent;
            resource = new Food();
	    }

        public void SetStates()
        {
            parent.AddState(new ResetState(parent));
            parent.AddState(new ReturningState(parent));
            parent.AddState(new CollectingState(parent));
            parent.AddState(new WalkingState(parent));
        }
	
	    public void Update()
	    {
            
	    }

        public IResource GetResources()
        {
            return resource;
        }

        public string GetMainTarget()
        {
            return MAIN_TARGET;
        }

        public void AddResources(int count = 1)
        {
            resource.Add(count);
        }

        public string GetImagePath()
        {
            return IMAGE_PATH;
        }
	}
}
