using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using LitMotion;
using LitMotion.Extensions;
using gaw241020;
using gaw241020.Presenter;

namespace gaw241020.View {
    public class CharacterView : ICharacterView
    {
        const float c_WalkSecondsPerTile = .26f;

        Transform m_characterTransform;

        public bool isMoving { get; private set; }

        public CharacterView()
        {
            m_characterTransform = GameObject.Find("Character").transform;
        }


        public async UniTask Move(Vector2Int destination)
        {
            isMoving = true;

            float walkSecondsPerTile = c_WalkSecondsPerTile;

#if ENABLE_DEBUG
            if (Input.GetKey(KeyCode.LeftShift)) { 
            
                walkSecondsPerTile /= 5f;
            }
#endif
            await LMotion.Create(m_characterTransform.position, new Vector3(destination.x, destination.y), walkSecondsPerTile).BindToPosition(m_characterTransform);

            isMoving = false;
        }
    }
}
