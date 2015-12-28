using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AI
{
    public class StackStateMachine
    {
        private Stack<IState> states;

        public StackStateMachine()
        {
            states = new Stack<IState>();
        }

        public void Clear()
        {
            states.Clear();
        }

        public void Push(IState _state)
        {
            states.Push(_state);
        }

        public void Pop()
        {
            if (states.Count > 0)
            {
                states.Pop();
            }
        }

        public IState Peek()
        {
            return states.Peek();
        }
    }
}
