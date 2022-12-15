using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase<T> where T :StateMachineBase<T>
{
	protected T player;
	private bool test;
	public StateBase(T _machine) { player = _machine; }
	//開始時に1回　初期化
	public virtual void OnEnterState() { }
	//毎フレーム呼ばれる　通常のアップデートと同じタイミングで
	public virtual void OnUpdate() { }
	//状態の切り替え時1回　別の状態に遷移するタイミングで呼ばれる
	public virtual void OnExitState() { }
}
