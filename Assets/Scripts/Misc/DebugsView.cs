using System;

namespace Misc
{
    public class DebugsView : BaseView<DebugsModel, DebugsController>
    {
        private void Start()
        {
            Controller.Init();
        }
    }
}