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
                machine.ChangeState(new TestState.Up(machine));
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                machine.ChangeState(new TestState.Left(machine));
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
                machine.ChangeState(new TestState.Neutral(machine));
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
                machine.ChangeState(new TestState.Neutral(machine));
            }
        }
    }
}
