using System.Collections;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace gaw241020.Presenter
{
    public interface ITalkView
    {
        UniTask DisplayTalk(string talkText);
    }
}