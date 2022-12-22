using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestState : StateMachineBase<TestState>
{
    private void Start()
    {
        ChangeState(new TestState.Neutral(this));
    }

    private class Neutral : StateBase<TestState>
    {
        public Neutral(TestState _machine) : base(_machine)
        {
        }

        public override void OnEnterState()
        {
            Debug.Log("<color=red>OnEnter:Neutral!</color>");
        }
        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                player.ChangeState(new TestState.Up(player));
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                player.ChangeState(new TestState.Left(player));
            }
        }
    }

    private class Up : StateBase<TestState>
    {
        public Up(TestState _machine) : base(_machine)
        {
        }

        public override void OnEnterState()
        {
            Debug.Log("<color=blue>OnEnter:Up!</color>");
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                player.ChangeState(new TestState.Neutral(player));
            }
        }
    }

    private class Left : StateBase<TestState>
    {
        public Left(TestState _machine) : base(_machine)
        {
        }
        public override void OnEnterState()
        {
            Debug.Log("<color=purple>OnEnter:Left!</color>");
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                player.ChangeState(new TestState.Neutral(player));
            }
        }
    }
}
