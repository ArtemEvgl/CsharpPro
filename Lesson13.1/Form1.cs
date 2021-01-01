using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson13._1
{
    public partial class Form1 : Form
    {
        SynchronizationContext sync;
        public Form1()
        {
            InitializeComponent();
        }

        Func<int, int, int> function;
        
        bool ArgsValidation(out int x, out int y)
        {
            bool xIsCorrect = Int32.TryParse(textBoxX.Text, out x);
            bool yIsCorrect = Int32.TryParse(textBoxY.Text, out y);
            if (!(xIsCorrect && yIsCorrect))
            {
                MessageBox.Show("Args is invalid");
                return true;
            }
            return false;
        }
        
        public int Add(int x, int y)
        {
            Thread.Sleep(1000);
            return x + y;
        }

        private void IsCompletedBtn_Click(object sender, EventArgs e)
        {
            int x, y;

            if (ArgsValidation(out x, out y))
            {
                return;
            }

            function = new Func<int, int, int>(Add);
            sync = SynchronizationContext.Current;
            IAsyncResult func = function.BeginInvoke(x, y, CallBack, null);
            MessageBox.Show("CallBack");
        }

        private void EndBtn_Click(object sender, EventArgs e)
        {
            int x, y;

            if (ArgsValidation(out x, out y))
            {
                return;
            }

            IAsyncResult asyncResult = function.BeginInvoke(x, y, null, null);
            string result = function.EndInvoke(asyncResult).ToString();
            textBoxResult.Text = result;
            MessageBox.Show("EndInvoke");
        }

        private void CallBackBtn_Click(object sender, EventArgs e)
        {
            
            int x, y;

            if (ArgsValidation(out x, out y))
            {
                return;
            }
            IAsyncResult asyncResult = function.BeginInvoke(x, y, null, null);
            if (!asyncResult.IsCompleted)
            {
                Thread.Sleep(100);
            }
            MessageBox.Show("Completed");

            textBoxResult.Text = function.EndInvoke(asyncResult).ToString();
        }

        private void CallBack(IAsyncResult ar)
        {
            AsyncResult res = (AsyncResult)ar;
            Func<int, int, int> func = (Func<int, int, int>)res.AsyncDelegate;
            int result = func.EndInvoke(ar);
            sync.Post((s) => textBoxResult.Text = result.ToString(), null);
        }
    }
}
