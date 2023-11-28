using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace TourFirmGavrilov
{
    public partial class Form2 : Form
    {
        private DBTourFirmEntities dbContext;
        public Form2(DBTourFirmEntities dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Parse("01.01.2023");
            dateTimePicker2.Value = DateTime.Now;
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            tourBindingSource.DataSource = dbContext.Tours.Local.ToBindingList();
            customerBindingSource.DataSource = dbContext.Customers.Local.ToBindingList();

        }
        private void SetReport()
        {
            ReportDataSource sale = new ReportDataSource();
            sale.Name = "OrderSet";

            if (checkBox1.Checked && checkBox2.Checked)
            {
                sale.Value = dbContext.Orders.Local
                    .Where(o => o.orderDate >= dateTimePicker1.Value.Date && o.orderDate <= dateTimePicker2.Value.Date)
                    .Where(o => o.customersId == Convert.ToInt32(comboBox1.SelectedValue))
                    .Where(o => o.tourId == Convert.ToInt32(comboBox2.SelectedValue));
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(sale);
            }

            else if (checkBox1.Checked && !checkBox2.Checked)
            {
                sale.Value = dbContext.Orders.Local
                    .Where(o => o.orderDate >= dateTimePicker1.Value.Date && o.orderDate <= dateTimePicker2.Value.Date)
                    .Where(o => o.customersId == Convert.ToInt32(comboBox1.SelectedValue));
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(sale);
            }

            else if (checkBox2.Checked && !checkBox1.Checked)
            {
                sale.Value = dbContext.Orders.Local
                    .Where(o => o.orderDate >= dateTimePicker1.Value.Date && o.orderDate <= dateTimePicker2.Value.Date)
                    .Where(o => o.tourId == Convert.ToInt32(comboBox2.SelectedValue));
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(sale);
            }

            else
            {
                sale.Value = dbContext.Orders.Local
                    .Where(o => o.orderDate >= dateTimePicker1.Value.Date && o.orderDate <= dateTimePicker2.Value.Date);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(sale);
            }

            ReportDataSource customer = new ReportDataSource();
            customer.Name = "CustomerSet";
            customer.Value = dbContext.Customers.Local;

            ReportDataSource tour = new ReportDataSource();
            tour.Name = "TourSet";
            tour.Value = dbContext.Tours.Local;

            reportViewer1.LocalReport.DataSources.Add(sale);
            reportViewer1.LocalReport.DataSources.Add(customer);
            reportViewer1.LocalReport.DataSources.Add(tour);
            ReportParameter start = new ReportParameter("Start", dateTimePicker1.Value.Date.ToString());
            ReportParameter end = new ReportParameter("End", dateTimePicker2.Value.Date.ToString());
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { start, end });
            this.reportViewer1.RefreshReport();
        }
        


        private void Form2_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SetReport();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            SetReport();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SetReport();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            SetReport();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetReport();
        }
        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetReport();
        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    SetReport();
        //}

        //private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    SetReport();
        //}

    }
}






        
