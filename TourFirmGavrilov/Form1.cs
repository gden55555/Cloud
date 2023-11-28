using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace TourFirmGavrilov
{
    public partial class Form1 : Form
    {
        DBTourFirmEntities dbContext;
        ChangeInfo infoChange;
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            dbContext = new DBTourFirmEntities();

            dbContext.Orders.Load();
            dbContext.Tours.Load();
            dbContext.Customers.Load();

            orderBindingSource.DataSource = dbContext.Orders.Local.ToBindingList();
            tourBindingSource.DataSource = dbContext.Tours.Local.ToBindingList();
            customerBindingSource.DataSource = dbContext.Customers.Local.ToBindingList();
        }
        private void orderBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            dbContext.SaveChanges();
            orderDataGridView.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var entry in dbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
            orderDataGridView.Refresh();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            orderDataGridView.Refresh();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Validate();
            dbContext.SaveChanges();
            orderDataGridView.Refresh();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            dbContext.Dispose();
        }

        private void btChangeInfo_Click(object sender, EventArgs e)
        {
            if (infoChange == null || infoChange.IsDisposed)
                infoChange = new ChangeInfo(dbContext);
            infoChange.ShowDialog();
        }

        private void btReport_Click(object sender, EventArgs e)
        {
            Form form = new Form2(dbContext);
            form.ShowDialog();
        }
    }
}
