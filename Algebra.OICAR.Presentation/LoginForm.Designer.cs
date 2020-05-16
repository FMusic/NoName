namespace Algebra.OICAR.Presentation
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.mainLayoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.passwordTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.usersLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.usersLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.passwordLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.loginSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.userSvgImageBox = new DevExpress.XtraEditors.SvgImageBox();
            this.imageLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.infoLabelControl = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.mainLayoutControl)).BeginInit();
            this.mainLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersLayoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordLayoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userSvgImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageLayoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // mainLayoutControl
            // 
            this.mainLayoutControl.Controls.Add(this.infoLabelControl);
            this.mainLayoutControl.Controls.Add(this.loginSimpleButton);
            this.mainLayoutControl.Controls.Add(this.userSvgImageBox);
            this.mainLayoutControl.Controls.Add(this.passwordTextEdit);
            this.mainLayoutControl.Controls.Add(this.usersLookUpEdit);
            resources.ApplyResources(this.mainLayoutControl, "mainLayoutControl");
            this.mainLayoutControl.Name = "mainLayoutControl";
            this.mainLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(-2696, 93, 650, 400);
            this.mainLayoutControl.Root = this.Root;
            // 
            // passwordTextEdit
            // 
            resources.ApplyResources(this.passwordTextEdit, "passwordTextEdit");
            this.passwordTextEdit.Name = "passwordTextEdit";
            this.passwordTextEdit.Properties.PasswordChar = '*';
            this.passwordTextEdit.StyleController = this.mainLayoutControl;
            // 
            // usersLookUpEdit
            // 
            resources.ApplyResources(this.usersLookUpEdit, "usersLookUpEdit");
            this.usersLookUpEdit.Name = "usersLookUpEdit";
            this.usersLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("lookUpEdit1.Properties.Buttons"))))});
            this.usersLookUpEdit.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.ContentWidth;
            this.usersLookUpEdit.StyleController = this.mainLayoutControl;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.usersLayoutControlItem,
            this.passwordLayoutControlItem,
            this.emptySpaceItem2,
            this.imageLayoutControlItem,
            this.layoutControlItem1,
            this.emptySpaceItem4,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(440, 236);
            this.Root.TextVisible = false;
            // 
            // usersLayoutControlItem
            // 
            this.usersLayoutControlItem.Control = this.usersLookUpEdit;
            this.usersLayoutControlItem.Location = new System.Drawing.Point(104, 0);
            this.usersLayoutControlItem.Name = "usersLayoutControlItem";
            this.usersLayoutControlItem.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.usersLayoutControlItem.Size = new System.Drawing.Size(316, 46);
            resources.ApplyResources(this.usersLayoutControlItem, "usersLayoutControlItem");
            this.usersLayoutControlItem.TextLocation = DevExpress.Utils.Locations.Top;
            this.usersLayoutControlItem.TextSize = new System.Drawing.Size(50, 13);
            // 
            // passwordLayoutControlItem
            // 
            this.passwordLayoutControlItem.Control = this.passwordTextEdit;
            this.passwordLayoutControlItem.Location = new System.Drawing.Point(104, 56);
            this.passwordLayoutControlItem.Name = "passwordLayoutControlItem";
            this.passwordLayoutControlItem.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.passwordLayoutControlItem.Size = new System.Drawing.Size(316, 46);
            resources.ApplyResources(this.passwordLayoutControlItem, "passwordLayoutControlItem");
            this.passwordLayoutControlItem.TextLocation = DevExpress.Utils.Locations.Top;
            this.passwordLayoutControlItem.TextSize = new System.Drawing.Size(50, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(104, 46);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(316, 10);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 176);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(300, 40);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // loginSimpleButton
            // 
            this.loginSimpleButton.ImageOptions.Image = global::Algebra.OICAR.Presentation.Properties.Resources.assignto_32x32;
            resources.ApplyResources(this.loginSimpleButton, "loginSimpleButton");
            this.loginSimpleButton.Name = "loginSimpleButton";
            this.loginSimpleButton.StyleController = this.mainLayoutControl;
            this.loginSimpleButton.Click += new System.EventHandler(this.loginSimpleButton_Click);
            // 
            // userSvgImageBox
            // 
            resources.ApplyResources(this.userSvgImageBox, "userSvgImageBox");
            this.userSvgImageBox.Name = "userSvgImageBox";
            this.userSvgImageBox.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Zoom;
            this.userSvgImageBox.SvgImage = global::Algebra.OICAR.Presentation.Properties.Resources.bo_user;
            // 
            // imageLayoutControlItem
            // 
            this.imageLayoutControlItem.Control = this.userSvgImageBox;
            this.imageLayoutControlItem.Location = new System.Drawing.Point(0, 0);
            this.imageLayoutControlItem.Name = "imageLayoutControlItem";
            this.imageLayoutControlItem.Size = new System.Drawing.Size(104, 102);
            this.imageLayoutControlItem.TextSize = new System.Drawing.Size(0, 0);
            this.imageLayoutControlItem.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.loginSimpleButton;
            this.layoutControlItem1.Location = new System.Drawing.Point(300, 176);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(120, 40);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 102);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(104, 74);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.infoLabelControl;
            this.layoutControlItem2.Location = new System.Drawing.Point(104, 102);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(14, 17);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(316, 74);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // infoLabelControl
            // 
            this.infoLabelControl.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
            this.infoLabelControl.Appearance.Options.UseForeColor = true;
            this.infoLabelControl.Appearance.Options.UseTextOptions = true;
            this.infoLabelControl.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.infoLabelControl, "infoLabelControl");
            this.infoLabelControl.Name = "infoLabelControl";
            this.infoLabelControl.StyleController = this.mainLayoutControl;
            // 
            // LoginForm
            // 
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainLayoutControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoginForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainLayoutControl)).EndInit();
            this.mainLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.passwordTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersLayoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordLayoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userSvgImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageLayoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl mainLayoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit passwordTextEdit;
        private DevExpress.XtraEditors.LookUpEdit usersLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem usersLayoutControlItem;
        private DevExpress.XtraLayout.LayoutControlItem passwordLayoutControlItem;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.SvgImageBox userSvgImageBox;
        private DevExpress.XtraLayout.LayoutControlItem imageLayoutControlItem;
        private DevExpress.XtraEditors.SimpleButton loginSimpleButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.LabelControl infoLabelControl;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}