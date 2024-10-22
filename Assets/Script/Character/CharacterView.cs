using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using LitMotion;
using LitMotion.Extensions;
using gaw241020;

namespace gaw241020.Character {
    public class CharacterView : ICharacterView
    {
        Transform m_characterTransform;

        public bool isMoving { get; private set; }

        public CharacterView()
        {
            m_characterTransform = GameObject.Find("Character").transform;
        }


        public async UniTask Move(Vector2Int destination)
        {
            isMoving = true;
            await LMotion.Create(m_characterTransform.position, new Vector3(destination.x, destination.y),0.26f).BindToPosition(m_characterTransform);
            isMoving = false;
        }
    }
}
