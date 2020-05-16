using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Algebra.OICAR.Business.Core;
using Algebra.OICAR.Business.ServiceAgents;
using Algebra.OICAR.Types.Users;
using DevExpress.Utils.Extensions;

namespace Algebra.OICAR.Presentation
{
    public partial class LoginForm : XtraForm
    {
        private const string LOOKUP_COLUMN_ID = "ID";
        private const string LOOKUP_COLUMN_USERS = "Users";

        public User CurrentUser { get; set; }

        public LoginForm(string languageName)
        {
            InitializeComponent();
            LanguageProcessor.ApplyLanguage(languageName, this);
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            PopulateUsersLookup();
        }

        private void PopulateUsersLookup()
        {
            UserList users = UsersServiceAgent.GetUsers();
            users.Sort();
            usersLookUpEdit.Properties.DataSource = users;
            usersLookUpEdit.Properties.ValueMember = LOOKUP_COLUMN_ID;
            usersLookUpEdit.Properties.Columns.Clear();
            usersLookUpEdit.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(LOOKUP_COLUMN_ID));
            usersLookUpEdit.Properties.Columns[0].Visible = false;
            usersLookUpEdit.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(LOOKUP_COLUMN_USERS));
            usersLookUpEdit.ItemIndex = 0;
            usersLookUpEdit.Properties.GetNotInListValue += Properties_GetNotInListValue;
            usersLookUpEdit.Focus();
        }

        private void Properties_GetNotInListValue(object sender, DevExpress.XtraEditors.Controls.GetNotInListValueEventArgs e)
        {
            if (e.FieldName == LOOKUP_COLUMN_USERS)
            {
                User user = (usersLookUpEdit.Properties.DataSource as UserList)[e.RecordIndex];
                if (user != null)
                {
                    e.Value = user.ToString();                    
                }
            }
        }

        private void loginSimpleButton_Click(object sender, EventArgs e)
        {
            //TODO login and authorization task
            CurrentUser = (usersLookUpEdit.Properties.DataSource as UserList).First(x => x.ID == (int)usersLookUpEdit.EditValue);
            Close();
        }

    }
}