using System.Drawing;
using System.Drawing.Drawing2D;

namespace GameCalendar
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private const int penWidth = 1;
        private Pen backgroundPen = new Pen(Color.FromArgb(0x00, 0x00, 0x00), penWidth)
        {
            LineJoin = LineJoin.Bevel,
        };

        private readonly int itemInterval = 47;
        private readonly Point startPoint = new Point(5, 3);
        private readonly Size itemSize = new Size(310, 36);

        private readonly string nameFormat = " {0} ";
        private readonly Point datePoint = new Point(17, 17);
        private readonly Point platformPoint = new Point(121, 17);
        private readonly Point koreanPatchPoint = new Point(262, 17);
        private readonly Point morePoint = new Point(290, 14);
        private readonly Size moreSize = new Size(16, 16);

        private readonly string searchFormatForGoogle = "https://www.google.com/search?q={0}";
        private readonly string searchFormatForYoutube = "https://www.youtube.com/results?search_query={0}";
        private readonly string searchToolTip = "MLB\t\tSearch on Google\nCtrl + MLB\tSearch on Youtube";

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            backgroundPen.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.todayLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.itemPanel = new System.Windows.Forms.Panel();
            this.detailPanel = new System.Windows.Forms.Panel();
            this.developerDetail = new System.Windows.Forms.LinkLabel();
            this.nameDetail = new System.Windows.Forms.LinkLabel();
            this.koreanPatchDetail = new System.Windows.Forms.Label();
            this.platformDetail = new System.Windows.Forms.Label();
            this.dateDetail = new System.Windows.Forms.Label();
            this.koreanPatchTitle = new System.Windows.Forms.Label();
            this.platformTitle = new System.Windows.Forms.Label();
            this.developerTitle = new System.Windows.Forms.Label();
            this.dateTitle = new System.Windows.Forms.Label();
            this.nameTitle = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.PictureBox();
            this.updateBtn = new System.Windows.Forms.PictureBox();
            this.topmostBtn = new System.Windows.Forms.PictureBox();
            this.pinBtn = new System.Windows.Forms.PictureBox();
            this.nameToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.developerToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.detailPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topmostBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pinBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // todayLabel
            // 
            this.todayLabel.AutoSize = true;
            this.todayLabel.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.todayLabel.Location = new System.Drawing.Point(28, 5);
            this.todayLabel.Name = "todayLabel";
            this.todayLabel.Size = new System.Drawing.Size(87, 12);
            this.todayLabel.TabIndex = 1;
            this.todayLabel.Text = "YYYY-MM-DD";
            this.todayLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // itemPanel
            // 
            this.itemPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemPanel.Location = new System.Drawing.Point(6, 30);
            this.itemPanel.Name = "itemPanel";
            this.itemPanel.Size = new System.Drawing.Size(320, 230);
            this.itemPanel.TabIndex = 3;
            // 
            // detailPanel
            // 
            this.detailPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detailPanel.Controls.Add(this.developerDetail);
            this.detailPanel.Controls.Add(this.nameDetail);
            this.detailPanel.Controls.Add(this.koreanPatchDetail);
            this.detailPanel.Controls.Add(this.platformDetail);
            this.detailPanel.Controls.Add(this.dateDetail);
            this.detailPanel.Controls.Add(this.koreanPatchTitle);
            this.detailPanel.Controls.Add(this.platformTitle);
            this.detailPanel.Controls.Add(this.developerTitle);
            this.detailPanel.Controls.Add(this.dateTitle);
            this.detailPanel.Controls.Add(this.nameTitle);
            this.detailPanel.Controls.Add(this.closeBtn);
            this.detailPanel.Location = new System.Drawing.Point(6, 30);
            this.detailPanel.Name = "detailPanel";
            this.detailPanel.Size = new System.Drawing.Size(320, 230);
            this.detailPanel.TabIndex = 1;
            this.detailPanel.Visible = false;
            // 
            // developerDetail
            // 
            this.developerDetail.AutoSize = true;
            this.developerDetail.Location = new System.Drawing.Point(150, 100);
            this.developerDetail.Name = "developerDetail";
            this.developerDetail.Size = new System.Drawing.Size(57, 12);
            this.developerDetail.TabIndex = 17;
            this.developerDetail.TabStop = true;
            this.developerDetail.Text = "Unknown";
            this.developerDetail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DeveloperDetail_LinkClicked);
            // 
            // nameDetail
            // 
            this.nameDetail.AutoSize = true;
            this.nameDetail.Location = new System.Drawing.Point(150, 20);
            this.nameDetail.Name = "nameDetail";
            this.nameDetail.Size = new System.Drawing.Size(57, 12);
            this.nameDetail.TabIndex = 16;
            this.nameDetail.TabStop = true;
            this.nameDetail.Text = "Unknown";
            this.nameDetail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.NameDetail_LinkClicked);
            // 
            // koreanPatchDetail
            // 
            this.koreanPatchDetail.AutoSize = true;
            this.koreanPatchDetail.Location = new System.Drawing.Point(150, 180);
            this.koreanPatchDetail.Name = "koreanPatchDetail";
            this.koreanPatchDetail.Size = new System.Drawing.Size(57, 12);
            this.koreanPatchDetail.TabIndex = 15;
            this.koreanPatchDetail.Text = "Unknown";
            // 
            // platformDetail
            // 
            this.platformDetail.AutoSize = true;
            this.platformDetail.Location = new System.Drawing.Point(150, 140);
            this.platformDetail.Name = "platformDetail";
            this.platformDetail.Size = new System.Drawing.Size(57, 12);
            this.platformDetail.TabIndex = 14;
            this.platformDetail.Text = "Unknown";
            // 
            // dateDetail
            // 
            this.dateDetail.AutoSize = true;
            this.dateDetail.Location = new System.Drawing.Point(150, 60);
            this.dateDetail.Name = "dateDetail";
            this.dateDetail.Size = new System.Drawing.Size(57, 12);
            this.dateDetail.TabIndex = 12;
            this.dateDetail.Text = "Unknown";
            // 
            // koreanPatchTitle
            // 
            this.koreanPatchTitle.AutoSize = true;
            this.koreanPatchTitle.Location = new System.Drawing.Point(20, 180);
            this.koreanPatchTitle.Name = "koreanPatchTitle";
            this.koreanPatchTitle.Size = new System.Drawing.Size(80, 12);
            this.koreanPatchTitle.TabIndex = 10;
            this.koreanPatchTitle.Text = "Korean Patch";
            // 
            // platformTitle
            // 
            this.platformTitle.AutoSize = true;
            this.platformTitle.Location = new System.Drawing.Point(20, 140);
            this.platformTitle.Name = "platformTitle";
            this.platformTitle.Size = new System.Drawing.Size(49, 12);
            this.platformTitle.TabIndex = 9;
            this.platformTitle.Text = "Platform";
            // 
            // developerTitle
            // 
            this.developerTitle.AutoSize = true;
            this.developerTitle.Location = new System.Drawing.Point(20, 100);
            this.developerTitle.Name = "developerTitle";
            this.developerTitle.Size = new System.Drawing.Size(61, 12);
            this.developerTitle.TabIndex = 8;
            this.developerTitle.Text = "Developer";
            // 
            // dateTitle
            // 
            this.dateTitle.AutoSize = true;
            this.dateTitle.Location = new System.Drawing.Point(20, 60);
            this.dateTitle.Name = "dateTitle";
            this.dateTitle.Size = new System.Drawing.Size(30, 12);
            this.dateTitle.TabIndex = 7;
            this.dateTitle.Text = "Date";
            // 
            // nameTitle
            // 
            this.nameTitle.AutoSize = true;
            this.nameTitle.Location = new System.Drawing.Point(20, 20);
            this.nameTitle.Name = "nameTitle";
            this.nameTitle.Size = new System.Drawing.Size(36, 12);
            this.nameTitle.TabIndex = 6;
            this.nameTitle.Text = "Name";
            // 
            // closeBtn
            // 
            this.closeBtn.Image = global::GameCalendar.Properties.Resources.close;
            this.closeBtn.InitialImage = null;
            this.closeBtn.Location = new System.Drawing.Point(303, 3);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(12, 12);
            this.closeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.closeBtn.TabIndex = 5;
            this.closeBtn.TabStop = false;
            this.closeBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Image = global::GameCalendar.Properties.Resources.update;
            this.updateBtn.InitialImage = null;
            this.updateBtn.Location = new System.Drawing.Point(282, 4);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(12, 12);
            this.updateBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.updateBtn.TabIndex = 4;
            this.updateBtn.TabStop = false;
            this.updateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // topmostBtn
            // 
            this.topmostBtn.Image = global::GameCalendar.Properties.Resources.topmost_disabled;
            this.topmostBtn.InitialImage = null;
            this.topmostBtn.Location = new System.Drawing.Point(298, 4);
            this.topmostBtn.Name = "topmostBtn";
            this.topmostBtn.Size = new System.Drawing.Size(12, 12);
            this.topmostBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.topmostBtn.TabIndex = 2;
            this.topmostBtn.TabStop = false;
            this.topmostBtn.Click += new System.EventHandler(this.TopmostBtn_Click);
            // 
            // pinBtn
            // 
            this.pinBtn.Image = global::GameCalendar.Properties.Resources.unpinned;
            this.pinBtn.InitialImage = null;
            this.pinBtn.Location = new System.Drawing.Point(314, 4);
            this.pinBtn.Name = "pinBtn";
            this.pinBtn.Size = new System.Drawing.Size(12, 12);
            this.pinBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pinBtn.TabIndex = 0;
            this.pinBtn.TabStop = false;
            this.pinBtn.Click += new System.EventHandler(this.PinBtn_Click);
            // 
            // nameToolTip
            // 
            this.nameToolTip.Tag = "";
            // 
            // developerToolTip
            // 
            this.developerToolTip.Tag = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.ClientSize = new System.Drawing.Size(330, 270);
            this.ControlBox = false;
            this.Controls.Add(this.detailPanel);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.itemPanel);
            this.Controls.Add(this.topmostBtn);
            this.Controls.Add(this.todayLabel);
            this.Controls.Add(this.pinBtn);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("돋움", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Game Calendar";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.detailPanel.ResumeLayout(false);
            this.detailPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topmostBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pinBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pinBtn;
        private System.Windows.Forms.Label todayLabel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox topmostBtn;
        private System.Windows.Forms.Panel itemPanel;
        private System.Windows.Forms.PictureBox updateBtn;
        private System.Windows.Forms.Panel detailPanel;
        private System.Windows.Forms.PictureBox closeBtn;
        private System.Windows.Forms.Label dateTitle;
        private System.Windows.Forms.Label nameTitle;
        private System.Windows.Forms.Label developerTitle;
        private System.Windows.Forms.Label platformTitle;
        private System.Windows.Forms.Label koreanPatchTitle;
        private System.Windows.Forms.Label dateDetail;
        private System.Windows.Forms.Label platformDetail;
        private System.Windows.Forms.Label koreanPatchDetail;
        private System.Windows.Forms.LinkLabel nameDetail;
        private System.Windows.Forms.LinkLabel developerDetail;
        private System.Windows.Forms.ToolTip nameToolTip;
        private System.Windows.Forms.ToolTip developerToolTip;
    }
}

