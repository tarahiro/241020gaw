using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaw241020.Presenter

{
    public interface IUnlockModel
    {
        string GetUnlockContentId { get; }

        void SetUnlockContentId(string id);

        void ResetUnlockContentId();
    }
}
