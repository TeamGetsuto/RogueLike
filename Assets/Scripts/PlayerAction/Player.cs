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

    //�������Ă��Ȃ�
    private class Idle : StateBase<Player>
    {
        public Idle(Player _machine) : base(_machine)
        {
        }

        //Idle�ɓ��������Ɉ��ʂ�
        public override void OnEnterState()
        {
            Debug.Log("Idle�J�n");
        }

        //Idle�̏�Ԃ̂Ƃ����t���[���Ă΂��
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

    //���s
    private class Walk : StateBase<Player>
    {
        public Walk(Player _machine) : base(_machine)
        {
        }

        //Walk�ɓ������Ƃ�1��ʂ�
        public override void OnEnterState()
        {
            player.isChecked_Input = true;
            Debug.Log("���s�J�n");
        }

        //Walk�̏�Ԃ̂Ƃ����t���[���Ă΂��
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
                        Debug.Log("����");
                        player.direction = Vector3.Normalize(Vector3.up + Vector3.left);
                        return;
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        Debug.Log("�E��");
                        player.direction = Vector3.Normalize(Vector3.up + Vector3.right);
                        return;
                    }

                    Debug.Log("��");
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
                        Debug.Log("����");
                        player.direction = Vector3.Normalize(Vector3.down + Vector3.left);
                        return;
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        Debug.Log("�E��");
                        player.direction = Vector3.Normalize(Vector3.down + Vector3.right);
                        return;
                    }

                    Debug.Log("��");
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
                    Debug.Log("��");
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
                    Debug.Log("�E");
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

    //�U��
    private class Attack : StateBase<Player>
    {
        public Attack(Player _machine) : base(_machine)
        {
        }

        //Attack�ɓ������Ƃ�1��ʂ�
        public override void OnEnterState()
        {
            player.isChecked_Input = true;
            Debug.Log("�U���J�n");
        }

        //Attack�̏�Ԃ̂Ƃ����t���[���Ă΂��
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

    //�h��
    private class Defense : StateBase<Player>
    {
        public Defense(Player _machine) : base(_machine)
        {
        }

        //Defence�ɓ������Ƃ�1��ʂ�
        public override void OnEnterState()
        {
            player.isChecked_Input = true;
            Debug.Log("�h��J�n");
        }

        //Defence�̏�Ԃ̂Ƃ����t���[���Ă΂��
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

    //�ړ�
    public void MoveDirection(Player player, Vector3 vector)
    {
        player.objRigidbody.MovePosition(player.transform.position + vector * player.speed * Time.deltaTime);
    }
}
