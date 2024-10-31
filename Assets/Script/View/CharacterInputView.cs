using System.Collections;
using UnityEngine;
using gaw241020.Presenter;
using Tarahiro;
using Zenject;

namespace gaw241020.View
{
    public class CharacterInputView : MonoBehaviour, ICharacterInputView
    {
        [SerializeField]
        GameObject m_DecideGuide;

        
        [Inject]
        public void Construct()
        {
            SetActiveDecideGuide(false);
        }
        

        public void ShowDecideGuide(string s)
        {
            SetActiveDecideGuide(true);
        }

        public void EraseDecideGuide(string s)
        {
            SetActiveDecideGuide(false);
        }

        public bool IsDecideGuideDisplayed => m_DecideGuide.activeSelf;

        void SetActiveDecideGuide(bool b)
        {
            Log.DebugAssert(m_DecideGuide.activeSelf != b);
            m_DecideGuide.SetActive(b);

        }
    }
}