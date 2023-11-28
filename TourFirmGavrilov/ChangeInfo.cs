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
    public partial class ChangeInfo : Form
    {
        private DBTourFirmEntities dbContext;
        public ChangeInfo(DBTourFirmEntities dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            dbContext.Customers.Load();
            dbContext.Guides.Load();
            dbContext.Tours.Load();
            dbContext.Cities.Load();

            customerBindingSource.DataSource = dbContext.Customers.Local.ToBindingList();
            guideBindingSource.DataSource = dbContext.Guides.Local.ToBindingList();
            tourBindingSource.DataSource = dbContext.Tours.Local.ToBindingList();
            cityBindingSource.DataSource = dbContext.Cities.Local.ToBindingList();
        }

        private void btSave1_Click(object sender, EventArgs e)
        {
            Validate();
            dbContext.SaveChanges();
            customerDataGridView.Refresh();
            guideDataGridView.Refresh();
            tourDataGridView.Refresh();
            cityDataGridView.Refresh();
        }

        private void tourDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
