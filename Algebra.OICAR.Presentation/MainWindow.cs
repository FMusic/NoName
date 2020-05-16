using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Globalization;
using System.Threading;
using DevExpress.XtraLayout;
using Algebra.OICAR.Types.Enums;
using Algebra.OICAR.Business.Core;
using DevExpress.XtraTab;
using DevExpress.XtraEditors;
using DevExpress.Utils.Extensions;
using Algebra.OICAR.Types.Users;

namespace Algebra.OICAR.Presentation
{
    public partial class MainWindow : DevExpress.XtraBars.ToolbarForm.ToolbarForm
    {
        public User CurrentUser { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            SetLanguage(langCroBarButton);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            LoginForm loginForm = new LoginForm("HRV");
            loginForm.ShowDialog();
            CurrentUser = loginForm.CurrentUser;
            userBarStaticItem.Caption = CurrentUser.ToString();
            this.Enabled = true;
        }


        private void languageBarButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            SetLanguage(e.Item);
        }

        private void SetLanguage(BarItem item)
        {
            LanguageProcessor.ApplyLanguage(item.Caption, this);
            SetLanguageBar(item);
            if (CurrentUser != null)
            {
                userBarStaticItem.Caption = CurrentUser.ToString();
            }
        }

        private void SetLanguageBar(BarItem item)
        {
            Enum.TryParse(item.Caption, out Language language);
            languageBarSubItem.Caption = language.ToString();
            switch (language)
            {
                case Language.ENG:
                    languageBarSubItem.ImageOptions.Image = Properties.Resources.united_kingdom_flag_icon_32;
                    break;
                case Language.HRV:
                case Language.CRO:
                    languageBarSubItem.ImageOptions.Image = Properties.Resources.croatia_flag_icon_32;
                    break;
            }
        }

        private void sale_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!xtraTabControl.TabPages.Any(x => x.Text == e.Item.Caption))
            {
                SaleForm form = new SaleForm
                {
                    Dock = DockStyle.Fill
                };
                CreateTabItem(e.Item.Caption, form);
            }
        }

        private void CreateTabItem(string tabName, XtraUserControl form)
        {
            XtraTabPage xtraTab = new XtraTabPage
            {
                Text = tabName
            };
            form.Dock = DockStyle.Fill;
            xtraTab.Controls.Add(form);
            xtraTabControl.TabPages.Add(xtraTab);
            xtraTabControl.SelectedTabPage = xtraTab;
        }

        private void exitBarButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}