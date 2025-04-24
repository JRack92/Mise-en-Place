using MiseEnPlace.Core.Interfaces;
using System.Collections;
using UnityEngine;

namespace MiseEnPlace.Core.Entities
{
    public class Machinery : MonoBehaviour
    {
        private IMachineState _state;
        public void Update() => _state.Handle(this);
        public void ChangeState(IMachineState newState) { }
    }
}