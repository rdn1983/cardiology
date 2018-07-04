using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class HistoryCard : Form
    {
        public HistoryCard()
        {
            InitializeComponent();
            initGrid();
        }

        private void initGrid()
        {
            historyGrid.Rows.Add(false, new DateTime(), "Первчиный осмотр", "Иванов В.В.");
            historyGrid.Rows.Add(false, new DateTime(), "Анализы", "Петрова С.С");
            historyGrid.Rows.Add(false, new DateTime(), "Анализы", "Петрова С.С");
            historyGrid.Rows.Add(false, new DateTime(), "Анализы", "Иванов В.В.");
            historyGrid.Rows.Add(false, new DateTime(), "Катетеризация яремной, подключичной вены", "Иванов В.В.");
            historyGrid.Rows.Add(false, new DateTime(), "Протокол торакацентоза", "Сидоров А.С.");
            historyGrid.Rows.Add(false, new DateTime(), "Дневник До КАГ", "Иванов В.В.");
            historyGrid.Rows.Add(false, new DateTime(), "Дневник после КАГ", "Петров С.С");
            historyGrid.Rows.Add(false, new DateTime(), "Анализы", "Иванов В.В");
            historyGrid.Rows.Add(false, new DateTime(), "Дневник после КАГ", "Петров С.С.");
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
