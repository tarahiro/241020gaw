using System.Collections;
using gaw241020;
using gaw241020.Presenter;
using UnityEngine;
using Zenject;

namespace gaw241020.View
{
    public class CharacterCollider : MonoBehaviour
    {
        [Inject]
        ICharacterCollisionPresenter m_CharacterCollisionPresenter;


        [Inject]
        public void Construct(ICharacterCollisionPresenter characterCollisionPresenter)
        {
            m_CharacterCollisionPresenter = characterCollisionPresenter;
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            m_CharacterCollisionPresenter.EnterCharacterToLocation(collision.gameObject);

        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            m_CharacterCollisionPresenter.ExitCharacterFromLocation(collision.gameObject);
        }
    }
}