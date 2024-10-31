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
        //Memo このクラスもMonoBehaviourにしてもいい気もする

        const float c_WalkSecondsPerTile = .26f;

        Transform m_CharacterTransform;
        Animator m_CharacterAnimator;

        //Direction周りはUtilにまとめるかも

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
            m_CharacterAnimator.SetTrigger(GetMoveDirection((Vector2)destination));

            await LMotion.Create(m_CharacterTransform.position, new Vector3(destination.x, destination.y), walkSecondsPerTile).BindToPosition(m_CharacterTransform);

            EndMove();
        }
        void EndMove()
        {
            Log.DebugLog("移動終了");
            m_CharacterAnimator.SetTrigger("Idle");
            isMoving = false;

        }

        string GetMoveDirection(Vector2 destination)
        {
            var MoveVector = destination - (Vector2)m_CharacterTransform.position;

            List<float> innerProductList = new List<float>();

            foreach(var v in m_DirectionList)
            {
                float f = Vector2.Dot((Vector2)v, MoveVector);
                Log.DebugLog(f.ToString());
                innerProductList.Add(f);
            }

            string s = ((Direction)innerProductList.IndexOf(innerProductList.Max())).ToString();
            Log.DebugLog(s);

            return s;

        }

    }
}
