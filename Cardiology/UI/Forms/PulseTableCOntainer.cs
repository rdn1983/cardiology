using System;
using System.Windows.Forms;

namespace Cardiology.UI.Forms
{
    public partial class PulseTableCOntainer : Form
    {
        private OnReturnValues completeListener;

        internal PulseTableCOntainer(OnReturnValues listener)
        {
            InitializeComponent();
            completeListener = listener;
        }

        internal delegate void OnReturnValues(Range adRangse, Range chsRange);

        private void PulseTableCOntainer_Deactivate(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void cell11_Click(object sender, EventArgs e)
        {
            completeListener?.Invoke(new Range(0, 70), new Range(30, 42));
            Visible = false;
        }

        private void cell12_Click(object sender, EventArgs e)
        {
            completeListener?.Invoke(new Range(0, 70), new Range(50, 79));
            Visible = false;
        }

        private void cell13_Click(object sender, EventArgs e)
        {
            completeListener?.Invoke(new Range(0, 70), new Range(80, 190));
            Visible = false;
        }

        private void cell14_Click(object sender, EventArgs e)
        {
            completeListener?.Invoke(new Range(0, 70), new Range(110, 190));
            Visible = false;
        }

        private void cell21_Click(object sender, EventArgs e)
        {
            completeListener?.Invoke(new Range(71, 109), new Range(30, 42));
            Visible = false;
        }

        private void cell22_Click(object sender, EventArgs e)
        {
            completeListener?.Invoke(new Range(71, 109), new Range(50, 79));
            Visible = false;
        }

        private void cell23_Click(object sender, EventArgs e)
        {
            completeListener?.Invoke(new Range(71, 109), new Range(80, 109));
            Visible = false;
        }

        private void cell24_Click(object sender, EventArgs e)
        {
            completeListener?.Invoke(new Range(71, 109), new Range(110, 190));
            Visible = false;
        }

        private void cell31_Click(object sender, EventArgs e)
        {
            completeListener?.Invoke(new Range(110, 139), new Range(30, 42));
            Visible = false;
        }

        private void cell32_Click(object sender, EventArgs e)
        {
            completeListener?.Invoke(new Range(110, 139), new Range(50, 79));
            Visible = false;
        }

        private void cell33_Click(object sender, EventArgs e)
        {
            completeListener?.Invoke(new Range(110, 139), new Range(80, 109));
            Visible = false;
        }

        private void cell34_Click(object sender, EventArgs e)
        {
            completeListener?.Invoke(new Range(110, 139), new Range(110, 190));
            Visible = false;
        }

        private void cell41_Click(object sender, EventArgs e)
        {
            completeListener?.Invoke(new Range(140, 179), new Range(30, 42));
            Visible = false;
        }

        private void cell42_Click(object sender, EventArgs e)
        {
            completeListener?.Invoke(new Range(140, 179), new Range(50, 79));
            Visible = false;
        }

        private void cell43_Click(object sender, EventArgs e)
        {
            completeListener?.Invoke(new Range(140, 179), new Range(80, 109));
            Visible = false;
        }

        private void cell44_Click(object sender, EventArgs e)
        {
            completeListener?.Invoke(new Range(140, 179), new Range(110, 190));
            Visible = false;
        }

        private void cell51_Click(object sender, EventArgs e)
        {
            completeListener?.Invoke(new Range(180, 230), new Range(30, 42));
            Visible = false;
        }

        private void cell52_Click(object sender, EventArgs e)
        {
            completeListener?.Invoke(new Range(180, 230), new Range(50, 79));
            Visible = false;
        }

        private void cell53_Click(object sender, EventArgs e)
        {
            completeListener?.Invoke(new Range(180, 230), new Range(80, 109));
            Visible = false;
        }

        private void cell54_Click(object sender, EventArgs e)
        {
            completeListener?.Invoke(new Range(180, 230), new Range(110, 190));
            Visible = false;
        }
    }

    internal class Range
    {
        private int start;
        private int end;

        public Range(int start, int end)
        {
            this.start = start;
            this.end = end;
        }

        public int End { get => end; private set => end = value; }
        public int Start { get => start; private set => end = value; }
    }
}
