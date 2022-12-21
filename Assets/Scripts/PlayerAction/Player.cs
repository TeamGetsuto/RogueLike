using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : StateMachineBase<Player>
{
    public float speed = 4.0f;
    private bool isChecked_Input = false;
    private bool isChecked_MoveKey = false;

    private Rigidbody2D objRigidbody;

    private Vector3 direction;

    //hp, attackforce, defenceforce1, sword, shield


    private void Start()
    {
        objRigidbody = GetComponent<Rigidbody2D>();
        ChangeState(new Player.Idle(this));
    }

    //何もしていない
    private class Idle : StateBase<Player>
    {
        public Idle(Player _machine) : base(_machine)
        {
        }

        //Idleに入った時に一回通る
        public override void OnEnterState()
        {
            Debug.Log("Idle開始");
        }

        //Idleの状態のとき毎フレーム呼ばれる
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

        //Walkに入ったとき1回通る
        public override void OnEnterState()
        {
            player.isChecked_Input = true;
            Debug.Log("歩行開始");
        }

        //Walkの状態のとき毎フレーム呼ばれる
        public override void OnUpdate()
        {
            player.direction = Vector3.zero;
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
                        player.direction = Vector3.Normalize(Vector3.up + Vector3.left);
                        return;
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        Debug.Log("右上");
                        player.direction = Vector3.Normalize(Vector3.up + Vector3.right);
                        return;
                    }

                    Debug.Log("上");
                    player.direction = Vector3.up;
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
                        player.direction = Vector3.Normalize(Vector3.down + Vector3.left);
                        return;
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        Debug.Log("右下");
                        player.direction = Vector3.Normalize(Vector3.down + Vector3.right);
                        return;
                    }

                    Debug.Log("下");
                    player.direction = Vector3.down;
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
                    player.direction = Vector3.left;
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
                    player.direction = Vector3.right;
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

        public override void PhysicsUpdate()
        {
            player.MoveDirection(player, player.direction);
        }
    }

    //攻撃
    private class Attack : StateBase<Player>
    {
        public Attack(Player _machine) : base(_machine)
        {
        }

        //Attackに入ったとき1回通る
        public override void OnEnterState()
        {
            player.isChecked_Input = true;
            Debug.Log("攻撃開始");
        }

        //Attackの状態のとき毎フレーム呼ばれる
        public override void OnUpdate()
        {
            if (player.isChecked_Input)
            {
                if (Input.GetKeyUp(KeyCode.F))
                {
                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || 
                        Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
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

        //Defenceに入ったとき1回通る
        public override void OnEnterState()
        {
            player.isChecked_Input = true;
            Debug.Log("防御開始");
        }

        //Defenceの状態のとき毎フレーム呼ばれる
        public override void OnUpdate()
        {
            if (player.isChecked_Input)
            {
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||
                        Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
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
}
