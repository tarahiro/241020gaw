using System.Collections;
using UnityEngine;

namespace gaw241020.Presenter
{
    public interface ICharacterInputView
    {
        void ShowDecideGuide(string s);

        bool IsDecideGuideDisplayed { get; }

        void EraseDecideGuide(string s);
    }
}