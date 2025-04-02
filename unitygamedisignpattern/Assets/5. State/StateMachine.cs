using UnityEngine;

//상태변경 스크립트
public class StateMachine
{
    private IState currentState;

    public void ChangeState(IState newState)
    {
        currentState?.Exit();   //이전상태 Exit
        currentState = newState;    //새상태 변경
        currentState.Enter();
    }

    public void Update()
    {
        currentState?.Update(); //현재상태 Update()
    }

}
