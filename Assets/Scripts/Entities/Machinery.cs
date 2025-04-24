using MiseEnPlace.Core.Interfaces;
using MiseEnPlace.Core.Managers;
using System;
using System.Collections;
using UnityEngine;

namespace MiseEnPlace.Core.Entities
{
    public class Machinery : MonoBehaviour
    {
        private IMachineState _state;
        public void Update() => _state.Handle(this);
        public void ChangeState(IMachineState newState)
        {

            //Observer para notificar al RestaurantManager cuando cambie de estado y afecte reputación o producción.}
        }
    }
}