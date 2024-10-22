using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using gaw241020;

namespace gaw241020.Character {
    public class CharacterView : ICharacterView
    {
        Transform m_characterTransform;

        public CharacterView()
        {
            m_characterTransform = GameObject.Find("Character").transform;
        }


        public async UniTask Move(Vector2Int destination)
        {
            m_characterTransform.position = new Vector2(destination.x, destination.y);
        }
    }
}
