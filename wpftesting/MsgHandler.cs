using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpftesting
{
    class MsgHandler
    {
        private string title;
        private string message;
        private MsgBox msgBox;

        public MsgHandler()
        {
            
        }

        public bool IsAgreed()
        {
            return msgBox.resultOk;
        }

        public void CreateMessage(string title, string message)
        {
            this.title = title;
            this.message = message;
            this.msgBox = new MsgBox(this.title, this.message);
            this.ShowMessage();
        }

        private void ShowMessage()
        {
            msgBox.ShowDialog();
            if (msgBox.resultCancel)
            {
                Environment.Exit(0);
            }
        }

    }
}
