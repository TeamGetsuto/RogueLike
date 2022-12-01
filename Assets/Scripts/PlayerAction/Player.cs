using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : StateMachineBase<Player>
{
    public float speed = 4.0f;

    private void Start()
    {
        ChangeState(new Player.Idle(this));
    }

    private class Idle : StateBase<Player>
    {
        public Idle(Player _machine) : base(_machine)
        {
        }

        //開始時1回
        public override void OnEnterState()
        {
            Debug.Log("Idle開始");
        }

        //毎フレーム呼ばれる
        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.W))
            {
                machine.ChangeState(new Player.Walk(machine));
            }
            if (Input.GetKey(KeyCode.S))
            {
                machine.ChangeState(new Player.Walk(machine));
            }
            if (Input.GetKey(KeyCode.A))
            {
                machine.ChangeState(new Player.Walk(machine));
            }
            if (Input.GetKey(KeyCode.D))
            {
                machine.ChangeState(new Player.Walk(machine));
            }
        }
    }

    private class Walk : StateBase<Player>
    {
        public Walk(Player _machine) : base(_machine)
        {
        }

        //開始時1回
        public override void OnEnterState()
        {
            Debug.Log("歩行開始");
        }

        //毎フレーム呼ばれる
        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    machine.transform.Translate(Vector3.Normalize(Vector3.up + Vector3.left) * machine.speed * Time.deltaTime);
                    return;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    machine.transform.Translate(Vector3.Normalize(Vector3.up + Vector3.right) * machine.speed * Time.deltaTime);
                    return;
                }
                Debug.Log("↑");
                machine.transform.Translate(Vector3.up * machine.speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    machine.transform.Translate(Vector3.Normalize(Vector3.down + Vector3.left) * machine.speed * Time.deltaTime);
                    return;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    machine.transform.Translate(Vector3.Normalize(Vector3.down + Vector3.right) * machine.speed * Time.deltaTime);
                    return;
                }

                Debug.Log("↓");
                machine.transform.Translate(Vector3.down * machine.speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("←");
                machine.transform.Translate(Vector3.left * machine.speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Debug.Log("→");
                machine.transform.Translate(Vector3.right * machine.speed * Time.deltaTime);
            }
            
        }

        public override void OnExitState()
        {
            machine.ChangeState(new Player.Idle(machine));
        }
    }

    private class Attack : StateBase<Player>
    {
        public Attack(Player _machine) : base(_machine)
        {
        }
    }
}
