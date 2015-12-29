using UnityEngine;
using System.Collections;

namespace VillagerAI
{
    public class Builder : IClass
    {
        private const string MAIN_TARGET = "Market";
        private const string IMAGE_PATH = "Materials/Characters/M_Builder";
        private Character parent;

        private Food food;
        //private Wood wood;
        //private Gold gold;

        public Builder(Character _parent)
        {
            parent = _parent;

            food = new Food();
            //wood = new Wood();
            //gold = new Gold();
        }
        public void SetStates()
        {
            parent.AddState(new ResetState(parent));
            parent.AddState(new ReturningState(parent));
            parent.AddState(new WalkingState(parent));
        }

        public void Update()
        {

        }

        public IResource GetResources()
        {
            return food;
        }

        public string GetMainTarget()
        {
            return MAIN_TARGET;
        }

        public void AddResources(int count = 1)
        {

        }

        public string GetImagePath()
        {
            return IMAGE_PATH;
        }
    }
}
