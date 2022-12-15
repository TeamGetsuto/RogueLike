using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : StateMachineBase<Player>
{
    public float speed = 4.0f;
    private bool isChecked_Input = false;
    private bool isChecked_MoveKey = false;
    KeyCode key;

    private Rigidbody2D objRigidbody;


    private void Start()
    {
        ChangeState(new Player.Idle(this));
    }

    //何もしていない
    private class Idle : StateBase<Player>
    {
        public Idle(Player _machine) : base(_machine)
        {
        }

        //開始時1回
        public override void OnEnterState()
        {
            player.objRigidbody = player.GetComponent<Rigidbody2D>();
            Debug.Log("Idle開始");
            
        }

        //毎フレーム呼ばれる
        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.W))
            {
                player.ChangeState(new Player.Walk(player));
            }
            if (Input.GetKey(KeyCode.S))
            {
                player.ChangeState(new Player.Walk(player));
            }
            if (Input.GetKey(KeyCode.A))
            {
                player.ChangeState(new Player.Walk(player));
            }
            if (Input.GetKey(KeyCode.D))
            {
                player.ChangeState(new Player.Walk(player));
            }
            if (Input.GetKey(KeyCode.F))
            {
                player.ChangeState(new Player.Attack(player));
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                player.ChangeState(new Player.Defense(player));
            }
        }
    }

    //歩行
    private class Walk : StateBase<Player>
    {
        public Walk(Player _machine) : base(_machine)
        {
        }

        //開始時1回
        public override void OnEnterState()
        {
            player.isChecked_Input = true;
            Debug.Log("歩行開始");
        }

        //毎フレーム呼ばれる
        public override void OnUpdate()
        {
            if (player.isChecked_Input)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        player.ChangeState(new Player.Defense(player));
                    }
                    if (Input.GetKey(KeyCode.F))
                    {
                        player.ChangeState(new Player.Attack(player));
                    }
                    if (Input.GetKey(KeyCode.A))
                    {
                        Debug.Log("左上");
                        player.MoveDirection(player, Vector3.Normalize(Vector3.up + Vector3.left));
                        return;
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        Debug.Log("右上");
                        player.MoveDirection(player, Vector3.Normalize(Vector3.up + Vector3.right));
                        return;
                    }

                    //Debug.Log("上");
                    player.MoveDirection(player, Vector3.up);
                }
                else if (Input.GetKeyUp(KeyCode.W))
                {
                    player.isChecked_Input = false;
                }

                if (Input.GetKey(KeyCode.S))
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        player.ChangeState(new Player.Defense(player));
                    }
                    if (Input.GetKey(KeyCode.F))
                    {
                        player.ChangeState(new Player.Attack(player));
                    }
                    if (Input.GetKey(KeyCode.A))
                    {
                        Debug.Log("左下");
                        player.MoveDirection(player, Vector3.Normalize(Vector3.down + Vector3.left));
                        return;
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        Debug.Log("右下");
                        player.MoveDirection(player, Vector3.Normalize(Vector3.down + Vector3.right));
                        return;
                    }

                    Debug.Log("下");
                    player.MoveDirection(player, Vector3.down);
                }
                else if (Input.GetKeyUp(KeyCode.S))
                {
                    player.isChecked_Input = false;
                }


                if (Input.GetKey(KeyCode.A))
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        player.ChangeState(new Player.Defense(player));
                    }
                    if (Input.GetKey(KeyCode.F))
                    {
                        player.ChangeState(new Player.Attack(player));
                    }
                    Debug.Log("左");
                    player.MoveDirection(player, Vector3.left);
                }
                else if (Input.GetKeyUp(KeyCode.A))
                {
                    player.isChecked_Input = false;
                }

                if (Input.GetKey(KeyCode.D))
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        player.ChangeState(new Player.Defense(player));
                    }
                    if (Input.GetKey(KeyCode.F))
                    {
                        player.ChangeState(new Player.Attack(player));
                    }
                    Debug.Log("右");
                    player.MoveDirection(player, Vector3.right);
                }
                else if (Input.GetKeyUp(KeyCode.D))
                {
                    player.isChecked_Input = false;
                }
            }
            else
            {
                player.ChangeState(new Player.Idle(player));
            }

        }

    }

    //攻撃
    private class Attack : StateBase<Player>
    {
        public Attack(Player _machine) : base(_machine)
        {
        }

        public override void OnEnterState()
        {
            player.isChecked_Input = true;
            Debug.Log("攻撃開始");
        }

        public override void OnUpdate()
        {
            if (player.isChecked_Input)
            {
                if (Input.GetKeyUp(KeyCode.F))
                {
                    if (Input.anyKey)
                    {
                        player.isChecked_MoveKey = true;
                    }
                    player.isChecked_Input = false;
                }
            }
            else if (!player.isChecked_Input && player.isChecked_MoveKey)
            {
                player.isChecked_MoveKey = false;
                player.ChangeState(new Player.Walk(player));
            }
            else if (!player.isChecked_Input && !player.isChecked_MoveKey)
            {
                player.ChangeState(new Player.Idle(player));
            }
        }
    }

    //防御
    private class Defense : StateBase<Player>
    {
        public Defense(Player _machine) : base(_machine)
        {
        }

        public override void OnEnterState()
        {
            player.isChecked_Input = true;
            Debug.Log("防御開始");
        }

        public override void OnUpdate()
        {
            if (player.isChecked_Input)
            {
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    if (Input.anyKey)
                    {
                        player.isChecked_MoveKey = true;
                    }
                    player.isChecked_Input = false;
                }
            }
            else if (!player.isChecked_Input && player.isChecked_MoveKey)
            {
                player.isChecked_MoveKey = false;
                player.ChangeState(new Player.Walk(player));
            }
            else if (!player.isChecked_Input && !player.isChecked_MoveKey)
            {
                player.ChangeState(new Player.Idle(player));
            }
        }
    }

    //移動
    public void MoveDirection(Player player, Vector3 vector)
    {
        player.objRigidbody.MovePosition(player.transform.position + vector * player.speed * Time.deltaTime);
    }

    //public void InputKey(Player player, KeyCode key)
    //{
    //    switch(key)
    //    {
    //        case KeyCode.W:
    //            MoveDirection(player, Vector3.up);
    //            break;
    //    }
    //}
}
