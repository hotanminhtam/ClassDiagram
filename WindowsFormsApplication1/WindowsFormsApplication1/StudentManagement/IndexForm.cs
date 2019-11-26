using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.StudentManagement
{
    public partial class IndexForm : Form
    {
        private LogicLayer Business;
        public IndexForm()
        {
            InitializeComponent();
            this.Business = new LogicLayer();
            this.Load += IndexForm_Load;
            this.btnCreate.Click += btnCreate_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.grdStudent.DoubleClick += grdStudent_DoubleClick;
        }

        void grdStudent_DoubleClick(object sender, EventArgs e)
        {
            if (this.grdStudent.SelectedRows.Count == 1)
            {
                var row = this.grdStudent.SelectedRows[0];
                var studentview = (StudentView)row.DataBoundItem;

                new UpdateForm(studentview.id).ShowDialog();
            }
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        void btnCreate_Click(object sender, EventArgs e)
        {
            new CreateForm().ShowDialog();
            this.ShowAllStudent();
        }

        void IndexForm_Load(object sender, EventArgs e)
        {
            this.ShowAllStudent();
        }

        private void ShowAllStudent()
        {
            //this.grdStudent.DataSource = this.Business.GetStudents();
            var students = this.Business.GetStudents();
            var studentviews = new StudentView[students.Length];
            for (int i = 0; i < students.Length; i++)
                studentviews[i] = new StudentView(students[i]);
            this.grdStudent.DataSource = studentviews;
        }
    }
}
