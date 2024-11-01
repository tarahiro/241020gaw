using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using LitMotion;
using LitMotion.Extensions;
using gaw241020;
using gaw241020.Presenter;
using Tarahiro;
using System.Linq;

namespace gaw241020.View {
    public class CharacterView : ICharacterView
    {
        //Memo ���̃N���X��MonoBehaviour�ɂ��Ă������C������

        const float c_WalkSecondsPerTile = .26f;

        Transform m_CharacterTransform;
        Animator m_CharacterAnimator;
        string m_LatestDirectionString;

        //Direction�����Util�ɂ܂Ƃ߂邩��

        enum Direction
        {
            Down,
            Left,
            Up,
            Right
        }

        List<Vector2Int> m_DirectionList;

        public bool isMoving { get; private set; }

        public CharacterView()
        {
            m_CharacterTransform = GameObject.Find("Character").transform;
            m_CharacterAnimator = m_CharacterTransform.GetComponent<Animator>();

            m_DirectionList = new List<Vector2Int>();

            m_DirectionList.Add(Vector2Int.down);
            m_DirectionList.Add(Vector2Int.left);
            m_DirectionList.Add(Vector2Int.up);
            m_DirectionList.Add(Vector2Int.right);
        }


        public async UniTask Move(Vector2Int destination)
        {
            isMoving = true;

            float walkSecondsPerTile = c_WalkSecondsPerTile;

#if ENABLE_DEBUG
            if (Input.GetKey(KeyCode.LeftShift))
            {

                walkSecondsPerTile /= 5f;
            }
#endif
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
            isMoving = false;
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

            foreach(var v in m_DirectionList)
            {
                float f = Vector2.Dot((Vector2)v, MoveVector);
                innerProductList.Add(f);
            }

            string s = ((Direction)innerProductList.IndexOf(innerProductList.Max())).ToString();

            return s;

        }

    }
}
