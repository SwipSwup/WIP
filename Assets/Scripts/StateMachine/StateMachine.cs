using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State initialState;
    [SerializeField] private State state;

    private void OnEnable()
    {
        state = initialState;
    }

    void Update()
    {
        if (state.OnTransition(out State newState, this))
        {
            state = newState;
        }
    }
}
