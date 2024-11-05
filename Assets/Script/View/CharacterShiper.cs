using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using gaw241020.Presenter;
using LitMotion;
using LitMotion.Extensions;

namespace gaw241020.View
{
    public class CharacterShiper : ICharacterMover
    {
        Transform m_CharacterTransform;
        Animator m_CharacterAnimator;
        string m_LatestDirectionString;

        RuntimeAnimatorController m_WalkAnimatorController;

        const float c_WalkSecondsPerTile = .26f;
        bool m_isMoving;
        enum Direction
        {
            Down,
            Left,
            Up,
            Right
        }

        List<Vector2Int> m_DirectionList;

        public CharacterShiper()
        {
            m_CharacterTransform = GameObject.Find("Character").transform;
            m_CharacterAnimator = m_CharacterTransform.GetComponent<Animator>();


            m_WalkAnimatorController = Resources.Load<RuntimeAnimatorController>("PlayerShip");

            m_DirectionList = new List<Vector2Int>();

            m_DirectionList.Add(Vector2Int.down);
            m_DirectionList.Add(Vector2Int.left);
            m_DirectionList.Add(Vector2Int.up);
            m_DirectionList.Add(Vector2Int.right);
        }

        public bool IsMoving => m_isMoving;

        public void ChangeCharacterDisplay()
        {
            m_CharacterAnimator.runtimeAnimatorController = m_WalkAnimatorController;
        }
        public async UniTask Move(Vector2Int destination)
        {
            m_isMoving = true;

            float walkSecondsPerTile = c_WalkSecondsPerTile;


            if (Input.GetKey(KeyCode.LeftShift))
            {

                walkSecondsPerTile /= 2.5f;
            }

            string directionString = GetMoveDirection((Vector2)destination);
            if (directionString != m_LatestDirectionString)
            {
                m_LatestDirectionString = directionString;
                m_CharacterAnimator.SetTrigger(m_LatestDirectionString);
            }

            await LMotion.Create(m_CharacterTransform.position, new Vector3(destination.x, destination.y), walkSecondsPerTile).BindToPosition(m_CharacterTransform);

            EndMove();
        }
        void EndMove()
        {
            m_isMoving = false;
        }

        public void StopMoveBehavior()
        {
            m_CharacterAnimator.SetTrigger("Idle");
            m_LatestDirectionString = "";
        }

        string GetMoveDirection(Vector2 destination)
        {
            var MoveVector = destination - (Vector2)m_CharacterTransform.position;

            List<float> innerProductList = new List<float>();

            foreach (var v in m_DirectionList)
            {
                float f = Vector2.Dot((Vector2)v, MoveVector);
                innerProductList.Add(f);
            }

            string s = ((Direction)innerProductList.IndexOf(innerProductList.Max())).ToString();

            return s;

        }
    }
}
