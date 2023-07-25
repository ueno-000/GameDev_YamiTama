using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestM
{
    public enum GameTurn
    {
        None,
        Selection,
        Battle,

    }

    public class BattleManager : MonoBehaviour
    {
        [SerializeField, Tooltip("")]
        GameTurn _currentTurn;

        void Start()
        {

        }

        void Update()
        {

        }
    }
}
