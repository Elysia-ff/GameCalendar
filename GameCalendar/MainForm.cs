using GameCalendar.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameCalendar.JSONConverter;

namespace GameCalendar
{
    public partial class MainForm : Form
    {
        private List<GameData> dataList = new List<GameData>();
        private GameData loadedData = null;

        private bool isPinned;
        public bool IsPinned
        {
            get { return isPinned; }
            private set
            {
                if (isPinned != value)
                {
                    isPinned = value;
                    pinBtn.Image = isPinned ? Properties.Resources.pinned : Properties.Resources.unpinned;
                }
            }
        }

        public new bool TopMost
        {
            get { return base.TopMost; }
            set
            {
                if (base.TopMost != value)
                {
                    base.TopMost = value;
                    topmostBtn.Image = base.TopMost ? Properties.Resources.topmost_enabled : Properties.Resources.topmost_disabled;
                }
            }
        }

        public bool IsLoading { get; private set; }

        // Hide from Alt+Tab
        // https://social.msdn.microsoft.com/Forums/windows/en-US/0eefb6f4-3619-4f7a-b144-48df80e2c603/how-to-hide-form-from-alttab-dialog?forum=winforms
        protected override CreateParams CreateParams
        {
            get
            {
                // Turn on WS_EX_TOOLWINDOW style bit
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        public MainForm()
        {
            InitializeComponent();

            nameToolTip.SetToolTip(nameDetail, searchToolTip);
            developerToolTip.SetToolTip(developerDetail, searchToolTip);

            IsPinned = Properties.Settings.Default.IsPinned;
            TopMost = Properties.Settings.Default.IsTopMost;
            SetDateLabel();
        }

        private async Task LoadData()
        {
            if (IsLoading)
                return;

            IsLoading = true;
            for (int i = 0; i < dataList.Count; ++i)
            {
                RemoveControl(dataList[i]);
            }

            HttpWebRequest request = WebRequest.Create(Define.resourcesPath) as HttpWebRequest;
            HttpWebResponse response = await Task.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null) as HttpWebResponse;
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            string content = await streamReader.ReadToEndAsync();
            dataList = JsonConvert.DeserializeObject<List<GameData>>(content, new DateConverter());
            dataList.Sort(GameData.SortByDate);
            streamReader.Dispose();

            Invoke(new Action(() =>
            {
                int idx = 0;
                for (int i = 0; i < dataList.Count; ++i)
                {
                    TimeSpan timeSpan = dataList[i].Date.GetTimeSpan();
                    if (timeSpan.Days > Define.IgnoreDay)
                        continue;

                    MakeItem(idx++, dataList[i]);
                }

                // How to disable scroll bar
                // https://stackoverflow.com/a/38050589
                itemPanel.AutoScroll = false;
                itemPanel.HorizontalScroll.Maximum = 0;
                itemPanel.HorizontalScroll.Visible = false;
                itemPanel.VerticalScroll.Maximum = 0;
                itemPanel.VerticalScroll.Visible = false;
                itemPanel.AutoScroll = true;

                IsLoading = false;
            }));
        }

        private void SetDateLabel()
        {
            todayLabel.Text = DateTime.UtcNow.ToString();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (Visible)
            {
                Graphics g = e.Graphics;

                DrawBackground(g);
            }
        }

        private void DrawBackground(Graphics g)
        {
            Rectangle rect = new Rectangle(0, 0, Width - penWidth, Height - penWidth);
            g.DrawRectangle(backgroundPen, rect);
        }

        private void MakeItem(int idx, GameData data)
        {
            Point newPoint = startPoint;
            newPoint.Y = startPoint.Y + (idx * itemInterval);

            GroupBox groupBox = new GroupBox
            {
                BackColor = data.Date.GetColor(),
                Location = newPoint,
#if DEBUG
                Text = string.Format(nameFormat, idx + 1, data.Name),
#else
                Text = string.Format(nameFormat, data.Name),
#endif
                Size = itemSize,
                TabStop = false
            };

            data.uiData = new UIData();
            data.uiData.labels.Add(MakeLabel(groupBox, datePoint, data.Date.DateStr));
            data.uiData.labels.Add(MakeLabel(groupBox, platformPoint, data.Platform));
            data.uiData.labels.Add(MakeAlignedLabel(groupBox, koreanPatchPoint, data.KoreanPatch));
            MakeBtn(groupBox, morePoint, moreSize, data);

            itemPanel.Controls.Add(groupBox);
            data.uiData.panel = itemPanel;
            data.uiData.groupBox = groupBox;
        }

        private Label MakeLabel(GroupBox parent, Point point, string text)
        {
            Label label = new Label
            {
                AutoSize = true,
                Location = point,
                Text = text
            };

            parent.Controls.Add(label);
            return label;
        }

        private Label MakeAlignedLabel(GroupBox parent, Point point, string text)
        {
            Label label = new Label
            {
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleRight,
                Location = point,
                Text = text,
                Size = new Size(70, 20)
            };

            parent.Controls.Add(label);
            return label;
        }

        private void MakeBtn(GroupBox parent, Point point, Size size, GameData data)
        {
            Button btn = new Button
            {
                Location = point,
                Size = size,
                TabStop = false
            };
            data.uiData.clickEvent = (s, e) => { MoreBtn_Click(data); };
            btn.Click += data.uiData.clickEvent;

            parent.Controls.Add(btn);
            data.uiData.button = btn;
        }

        private void SetDetailPanel(GameData data)
        {
            loadedData = data;
            nameDetail.Text = data.Name;
            dateDetail.Text = data.Date.DateStr;
            developerDetail.Text = data.Developer;
            platformDetail.Text = data.Platform;
            koreanPatchDetail.Text = data.KoreanPatch;
        }

        private void RemoveControl(GameData data)
        {
            UIData ui = data.uiData;
            if (ui == null)
                return;

            if (ui.panel.Controls.Contains(ui.groupBox))
            {
                for (int i = 0; i < ui.labels.Count; ++i)
                {
                    if (ui.groupBox.Controls.Contains(ui.labels[i]))
                    {
                        ui.groupBox.Controls.Remove(ui.labels[i]);
                        ui.labels[i].Dispose();
                    }
                }

                if (ui.groupBox.Controls.Contains(ui.button))
                {
                    ui.button.Click -= ui.clickEvent;
                    ui.groupBox.Controls.Remove(ui.button);
                    ui.button.Dispose();
                }

                ui.panel.Controls.Remove(ui.groupBox);
                ui.groupBox.Dispose();
            }

            data.uiData = null;
        }

#region Event
        private void PinBtn_Click(object sender, EventArgs e)
        {
            IsPinned = !IsPinned;
            Properties.Settings.Default.IsPinned = IsPinned;
            Properties.Settings.Default.Save();
        }

        private void TopmostBtn_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
            Properties.Settings.Default.IsTopMost = TopMost;
            Properties.Settings.Default.Save();
        }

        private async void UpdateBtn_Click(object sender, EventArgs e)
        {
            await LoadData();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (!IsPinned)
            {
                this.MoveFormWithMouse();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            SetDateLabel();
        }

        private void MoreBtn_Click(GameData data)
        {
#if DEBUG
            Debug.WriteLine(data.Name);
#endif
            SetDetailPanel(data);
            detailPanel.Show();
            detailPanel.Focus();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            detailPanel.Hide();
            loadedData = null;
        }

        private void NameDetail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (loadedData != null && e.Button == MouseButtons.Left)
            {
                string format = KeyManager.Instance.Ctrl ? searchFormatForYoutube : searchFormatForGoogle;
                string url = string.Format(format, loadedData.Name);
                Process.Start(url);
            }
        }

        private void DeveloperDetail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (loadedData != null && e.Button == MouseButtons.Left)
            {
                string format = KeyManager.Instance.Ctrl ? searchFormatForYoutube : searchFormatForGoogle;
                string url = string.Format(searchFormatForGoogle, loadedData.Developer);
                Process.Start(url);
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            KeyManager.Instance.OnKeyDown(e);
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            KeyManager.Instance.OnKeyUp(e);
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            KeyManager.Instance.Reset();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            Location = Properties.Settings.Default.Location;

            await LoadData();
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                Properties.Settings.Default.Location = Location;
                Properties.Settings.Default.Save();
            }
        }
#endregion
    }
}
