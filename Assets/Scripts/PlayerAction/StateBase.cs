using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase<T> where T :StateMachineBase<T>
{
	protected T machine;
	public StateBase(T _machine) { machine = _machine; }
	//�J�n����1��@������
	public virtual void OnEnterState() { }
	//���t���[���Ă΂��@�ʏ�̃A�b�v�f�[�g�Ɠ����^�C�~���O��
	public virtual void OnUpdate() { }
	//��Ԃ̐؂�ւ���1��@�ʂ̏�ԂɑJ�ڂ���^�C�~���O�ŌĂ΂��
	public virtual void OnExitState() { }
}
