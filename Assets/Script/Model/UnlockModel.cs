using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gaw241020.Presenter;

namespace gaw241020.Model
{
    public class UnlockModel : IUnlockModel
    {
        string m_UnlockContentId;

        public string GetUnlockContentId => m_UnlockContentId;

        public void SetUnlockContentId(string Id)
        {
            m_UnlockContentId = Id;
        }

        public void ResetUnlockContentId()
        {
            m_UnlockContentId = "";
        }


    }
}
