using System.Collections;
using UnityEngine;
using TMPro;
using gaw241020.Presenter;
using Zenject;

namespace gaw241020.View
{
    public class MapFillUiView : MonoBehaviour,IMapFillUiView
    {
        [SerializeField]
        TextMeshProUGUI m_FillScoreText;

        const string c_FillRateLabel = "踏破率 : {0}%";

        public void Construct()
        {
            UpdateFillRate(0f);
        }

        public void UpdateFillRate(float fillPercent)
        {
            m_FillScoreText.text = c_FillRateLabel.Replace("{0}", fillPercent.ToString("F1"));
        }
    }
}