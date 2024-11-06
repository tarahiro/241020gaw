using System.Collections;
using UnityEngine;
using gaw241020.Presenter;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using TMPro;
using Tarahiro;
using Tarahiro.Text;
using Zenject;

namespace gaw241020.View
{
    public class TalkView : MonoBehaviour, ITalkView
    {
        [SerializeField]
        TextMeshProUGUI m_TalkText;

        [SerializeField]
        GameObject m_DisplayRoot;

        [SerializeField]
        GameObject m_KeyGuide;

        [Inject]
        public void Construct()
        {
            EraseDisplay();
        }

        public async UniTask DisplayTalk(string Text)
        {
            StartDisplay();

            await TextUtil.DisplayTextByCharacter(Text, m_TalkText, "Text", KeyCode.Z);

            m_KeyGuide.SetActive(true);

            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Z));

            EraseDisplay();

        }

        void StartDisplay()
        {
            m_DisplayRoot.SetActive(true);
            m_TalkText.text = "";
            m_KeyGuide.SetActive(false);

        }

        void EraseDisplay()
        {
            m_DisplayRoot.SetActive(false);

        }
    }
}