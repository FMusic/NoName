using Algebra.OICAR.Types.Enums;
using DevExpress.XtraBars;
using DevExpress.XtraBars.ToolbarForm;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algebra.OICAR.Business.Core
{
    public class LanguageProcessor
    {
        private static ComponentResourceManager resources;

        public static void ApplyLanguage(string languageName, Form form)
        {
            resources = new ComponentResourceManager(form.GetType());
            string ciName = "en-US";
            Enum.TryParse(languageName, out Language language);
            switch (language)
            {
                case Language.ENG:
                    ciName = "en-US";
                    break;
                case Language.HRV:
                case Language.CRO:
                    ciName = "hr-HR";
                    break;
            }
            CultureInfo ci = new CultureInfo(ciName, false);
            ChangeLanguage(ci, form);
        }

        private static void ChangeLanguage(CultureInfo ci, Form form)
        {
            Application.CurrentCulture = ci;
            CultureInfo.DefaultThreadCurrentCulture = ci;
            CultureInfo.DefaultThreadCurrentUICulture = ci;

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(ci.Name);
            ApplyResources(form.Controls);
            //ApplyResources(Root);
        }

        private static void ApplyResources(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (!string.IsNullOrEmpty(ctrl.Name))
                {
                    resources.ApplyResources(ctrl, ctrl.Name);
                }
               
                if (ctrl is LayoutControl)
                {
                    foreach (var item in (ctrl as LayoutControl).Items)
                    {
                        if (item is LayoutControlItem)
                        {
                            if (!string.IsNullOrEmpty(((LayoutControlItem)item).Name))
                            {
                                resources.ApplyResources(item, ((LayoutControlItem)item).Name);
                            }
                        }
                        
                    }
                }
                else if (ctrl is ToolbarFormControl)
                {
                    foreach (BarItem bar in (ctrl as ToolbarFormControl).Items)
                    {
                        if (!string.IsNullOrEmpty(bar.Name))
                        {
                            resources.ApplyResources(bar, bar.Name);
                        }
                    }
                }
                else if (ctrl is BarDockControl)
                {
                    foreach (BarItem bar in (ctrl as BarDockControl).Manager.Items)
                    {
                        if (!string.IsNullOrEmpty(bar.Name))
                        {
                            resources.ApplyResources(bar, bar.Name);
                        }
                    }
                }
                else if (ctrl.Controls.Count > 0)
                {
                    ApplyResources(ctrl.Controls);
                }
            }
        }
    }
}
