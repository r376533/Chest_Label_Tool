using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chest_Label_Tool
{
    public partial class ProcessBarPage : Form
    {
        private delegate void _SetMaxAndMin();
        private delegate void _SetProgressValue();
        private delegate void _CloseWindows();


        private int _Min, _Max, _NowValue;
        public ProcessBarPage()
        {
            InitializeComponent();
            _Min = 0;
            _Max = 100;
            _NowValue = 0;
        }

        public void SetMaxAndMin(int Min, int Max)
        {
            _Min = Min;
            _Max = Max;
            if (this.InvokeRequired)
            {
                _SetMaxAndMin fuc = new _SetMaxAndMin(RealSetMaxAndMin);
                this.Invoke(fuc);
            }
            else 
            {
                RealSetMaxAndMin();
            }
        }

        private void RealSetMaxAndMin() 
        {
            pgbProcBar.Maximum = _Max;
            pgbProcBar.Minimum = _Min;
        }
        public void SetProgressValue(int Value) 
        {
            _NowValue = Value;
            if (this.InvokeRequired)
            {
                _SetProgressValue fuc = new _SetProgressValue(SetProgressValue);
                this.Invoke(fuc);
            }
            else
            {
                SetProgressValue();
            }
            pgbProcBar.Value = Value;
        }
        private void SetProgressValue() 
        {
            pgbProcBar.Value = _NowValue;
        }

        public void CloseWindows() 
        {
            if (this.InvokeRequired)
            {
                _CloseWindows fuc = new _CloseWindows(CloseWindows);
                this.Invoke(fuc);
            }
            else
            {
                this.Close();
            }
        }
    }
}
