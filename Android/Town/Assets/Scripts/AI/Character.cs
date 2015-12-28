using UnityEngine;
using System.Collections;

namespace AI
{
	public class Character
	{
        private CharacterBehavior behavior;
        private IClass currentClass;
        private StackStateMachine states;

	    public Character(CharacterBehavior _behavior)
	    {
            behavior = _behavior;
            states = new StackStateMachine();
            SetClass(new Builder(this));
	    }
	
	    public void Update()
	    {
            currentClass.Update();

            states.Peek().Update();
	    }

        public DebugText GetDebugText()
        {
            DebugText result = new DebugText();

            result.ClassText = currentClass.ToString();
            result.StateText = states.Peek().ToString();
            result.ResourceCountText = currentClass.GetResources().GetCount().ToString();

            return result;
        }

        public void SetClass(IClass _class)
        {
            currentClass = _class;
            ResetState();
            behavior.OnClassChanged(currentClass.GetImagePath());
        }

        public void ResetState()
        {
            states.Clear();
            currentClass.SetStates();
        }

        public void AddState(IState _state)
        {
            states.Push(_state);
        }

        public void SetState(IState _state)
        {
            states.Push(_state);
            states.Peek().Start();
        }

        public void NextState()
        {
            states.Pop();
            states.Peek().Start();
        }

        public void MoveToTarget()
        {
            behavior.MoveToTarget();
        }

        public Vector3 GetPosition()
        {
            return behavior.GetTransform().position;
        }

        public Vector3 GetTargetPosition()
        {
            return behavior.GetTarget().position;
        }

        public void SetClassTarget()
        {
            behavior.SetTarget(currentClass.GetMainTarget());
        }

        public void SetTarget(string _tag)
        {
            behavior.SetTarget(_tag);
        }

        public void CollectResource()
        {
            currentClass.AddResources();
        }

        public void StoreResource()
        {
            currentClass.GetResources();
        }
	}
}
