using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Clips
{
    public partial class Form1 : Form, IMessageFilter
    {
        private string appDir = Path.GetDirectoryName(Application.ExecutablePath);
        private Settings settings = new Settings();
        private string saveFile;
        private string charPipe = "#645745cf218740529d9a584cd838da15#";
        private string charLine = "#4b45ff83a4634fa8b1591e413162dd3d#";

        private int width = 0;
        private int height = 0;
        private int splitV = 0;
        private int splitH = 0;

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        private const int WM_DRAWCLIPBOARD = 0x0308;
        private IntPtr _clipboardViewerNext;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_DRAWCLIPBOARD)
            {
                IDataObject iData = Clipboard.GetDataObject();

                if (iData.GetDataPresent(DataFormats.Text))
                {
                    string text = (string)iData.GetData(DataFormats.Text);
                    textBox1.Text = text;
                }

                else if (iData.GetDataPresent(DataFormats.Bitmap))
                {
                    string text = "Clipboard contains bitmap.";
                    textBox1.Text = text;
                }

                else if (iData.GetDataPresent(DataFormats.Html))
                {
                    string text = "Clipboard contains HTMP.";
                    textBox1.Text = text;
                }

                else if (iData.GetDataPresent(DataFormats.Rtf))
                {
                    string text = "Clipboard contains RTF.";
                    textBox1.Text = text;
                }

                else if (iData.GetDataPresent(DataFormats.WaveAudio))
                {
                    string text = "Clipboard contains audio.";
                    textBox1.Text = text;
                }

                else
                {
                    if (Clipboard.ContainsFileDropList())
                    {
                        string str = "Clipboard contains files:" + Environment.NewLine;
                        System.Collections.Specialized.StringCollection list = Clipboard.GetFileDropList();

                        foreach (string file in list)
                        {
                            str += file + Environment.NewLine;
                        }

                        textBox1.Text = str;
                    }
                }

                checkButtons();
            }
        }

        public Form1()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
            _clipboardViewerNext = SetClipboardViewer(this.Handle);
            saveFile = Path.Combine(appDir, "autosave.clp");
            lineH();
            lineV();
        }

        private void lineV()
        {
            Label labelLine = new Label();
            labelLine.Top = 0;
            labelLine.Left = 0;
            labelLine.AutoSize = false;
            labelLine.Height = splitContainerH.Panel2.Height + 2;
            labelLine.Width = 2;
            labelLine.BorderStyle = BorderStyle.Fixed3D;
            labelLine.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            splitContainerH.Panel2.Controls.Add(labelLine);
            labelLine.BringToFront();
        }

        private void lineH()
        {
            Label labelLine = new Label();
            labelLine.Top = 0;
            labelLine.Left = 0;
            labelLine.AutoSize = false;
            labelLine.Height = 2;
            labelLine.Width = splitContainerV.Panel2.Width + 2;
            labelLine.BorderStyle = BorderStyle.Fixed3D;
            labelLine.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            splitContainerV.Panel2.Controls.Add(labelLine);
            labelLine.BringToFront();
        }

        private void setListNumbers()
        {
            lstClips.BeginUpdate();
            int i = 0;
            foreach (ListViewItem item in lstClips.Items)
            {
                i++;
                item.Text = i.ToString();
            }
            lstClips.EndUpdate();

            resizeColumns();
        }

        private void resizeColumns()
        {
            if (this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Maximized)
            {                
                clmNumber.Width = -1;
                int w = lstClips.ClientRectangle.Width;
                int name = w - clmNumber.Width;
                clmName.Width = name;
            }
        }

        private void checkButtons()
        {
            if (lstClips.SelectedItems.Count == 1)
            {
                btnDelete.Enabled = true;
                btnCopy.Enabled = true;
                btnRemoveIndent.Enabled = true;

                if (lstClips.Items.Count > 1)
                {
                    if (lstClips.SelectedItems[0].Index > 0) btnMoveUp.Enabled = true;
                    else btnMoveUp.Enabled = false;

                    if (lstClips.SelectedItems[0].Index < lstClips.Items.Count - 1) btnMoveDown.Enabled = true;
                    else btnMoveDown.Enabled = false;
                }
                
                else
                {
                    btnMoveUp.Enabled = false;
                    btnMoveDown.Enabled = false;
                }
            }
            
            else
            {
                btnMoveUp.Enabled = false;
                btnMoveDown.Enabled = false;
                btnDelete.Enabled = false;
                btnCopy.Enabled = false;
                btnRemoveIndent.Enabled = false;
            }

            if (Clipboard.GetText().Trim() != "") btnPaste.Enabled = true;
            else btnPaste.Enabled = false;
            checkSave();
        }

        private void checkSave()
        {
            if (lstClips.SelectedItems.Count == 1)
            {
                if (txtName.Text != lstClips.SelectedItems[0].SubItems[1].Text || txtView.Text != lstClips.SelectedItems[0].Tag.ToString()) btnSave.Enabled = true;
                else btnSave.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader reader = File.OpenText(saveFile))
                {
                    while (reader.Peek() >= 0)
                    {
                        string line = reader.ReadLine();
                        string num = line.Split('|')[0];
                        string name = line.Split('|')[1].Replace(charLine, "\r\n").Replace(charPipe, "|");
                        string clip = line.Split('|')[2].Replace(charLine, "\r\n").Replace(charPipe, "|");

                        ListViewItem newItem = new ListViewItem(num);
                        newItem.SubItems.Add(name);
                        newItem.Tag = clip;
                        lstClips.Items.Add(newItem);
                    }
                }
            }

            catch { }

            int selected = settings.LoadSetting("Selected", "int", "-1");
            if (lstClips.Items.Count > 0 && selected > -1) lstClips.Items[selected].Selected = true;

            this.Width = settings.LoadSetting("Width", "int", "741");
            this.Height = settings.LoadSetting("Height", "int", "630");
            splitContainerV.SplitterDistance = settings.LoadSetting("SplitV", "int", "284");
            splitContainerH.SplitterDistance = settings.LoadSetting("SplitH", "int", "410");
            checkMinimize.Checked = settings.LoadSetting("MinimizeOnCopy", "bool", "false");

            Screen screen = Screen.FromPoint(Cursor.Position);
            this.Left = screen.WorkingArea.Left + (screen.WorkingArea.Size.Width / 2) - (this.Width / 2);
            this.Top = screen.WorkingArea.Top + (screen.WorkingArea.Size.Height / 2) - (this.Height / 2) - 1;

            setListNumbers();
            checkButtons();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(saveFile))
                {
                    foreach (ListViewItem item in lstClips.Items)
                    {
                        string num = item.Text.Replace("\r\n", charLine).Replace("|", charPipe);
                        string name = item.SubItems[1].Text.Replace("\r\n", charLine).Replace("|", charPipe);
                        string clip = item.Tag.ToString().Replace("\r\n", charLine).Replace("|", charPipe);
                        string line = num + "|" + name + "|" + clip;

                        sw.WriteLine(line);
                    }
                }
            }

            catch { }

            int selected = -1;
            if (lstClips.SelectedItems.Count > 0) selected = lstClips.SelectedItems[0].Index;
            settings.SaveSetting("Selected", selected.ToString());

            if (width >= this.MinimumSize.Width && height >= this.MinimumSize.Height)
            {
                settings.SaveSetting("Width", width.ToString());
                settings.SaveSetting("Height", height.ToString());
                settings.SaveSetting("SplitV", splitV.ToString());
                settings.SaveSetting("SplitH", splitH.ToString());
            }

            settings.SaveSetting("MinimizeOnCopy", checkMinimize.Checked.ToString());

            ChangeClipboardChain(this.Handle, _clipboardViewerNext);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            lstClips.Focus();
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            string clip = Clipboard.GetText();
            if (clip != null && clip != "")
            {
                int index = -1;
                foreach (ListViewItem item in lstClips.Items)
                {
                    if (item.Text == clip)
                    {
                        index = item.Index;
                    }
                }
                if (index > -1) lstClips.Items[index].Remove();

                string[] name = clip.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                ListViewItem newItem = new ListViewItem((lstClips.Items.Count + 1).ToString());
                newItem.SubItems.Add(name[0].Trim());
                newItem.Tag = clip;
                lstClips.Items.Insert(0, newItem);
                lstClips.Items[0].Selected = true;

                setListNumbers();
                checkButtons();
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (lstClips.SelectedItems.Count == 1)
            {
                if (lstClips.SelectedItems[0].Tag.ToString() == "")
                {
                    textBox1.Clear();
                    Clipboard.Clear();
                }

                else Clipboard.SetText(lstClips.SelectedItems[0].Tag.ToString());
                if (checkMinimize.Checked) this.WindowState = FormWindowState.Minimized;
            }

            checkButtons();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ListViewItem newItem = new ListViewItem("");
            newItem.SubItems.Add("[New clip]");
            newItem.Tag = "";
            lstClips.Items.Insert(0, newItem);
            lstClips.Items[0].Selected = true;

            setListNumbers();
            checkButtons();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstClips.SelectedItems.Count == 1)
            {
                var result = MessageBox.Show("Really delete selected clip?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    int selected = lstClips.SelectedItems[0].Index;
                    lstClips.SelectedItems[0].Remove();

                    if (lstClips.Items.Count > 0)
                    {
                        if (lstClips.Items.Count > selected + 1) lstClips.Items[selected].Selected = true;
                        else lstClips.Items[lstClips.Items.Count - 1].Selected = true;
                    }
                }
            }

            setListNumbers();
            checkButtons();
        }

        private void lstClips_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstClips.SelectedItems.Count == 1)
            {
                txtName.Text = lstClips.SelectedItems[0].SubItems[1].Text.ToString();
                txtView.Text = lstClips.SelectedItems[0].Tag.ToString();
            }

            else
            {
                txtName.Text = txtView.Text = "";
            }

            checkButtons();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lstClips.SelectedItems.Count == 1)
            {
                lstClips.SelectedItems[0].SubItems[1].Text = txtName.Text;
                lstClips.SelectedItems[0].Tag = txtView.Text;
            }

            checkButtons();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (lstClips.SelectedItems.Count == 1 && lstClips.Items.Count > 1)
            {
                int selected = lstClips.SelectedItems[0].Index;

                if (selected > 0)
                {
                    lstClips.BeginUpdate();
                    ListViewItem item = lstClips.Items[selected - 1];
                    lstClips.Items.RemoveAt(selected - 1);
                    lstClips.Items.Insert(selected, item);
                    lstClips.EndUpdate();
                }

                setListNumbers();
                checkButtons();
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (lstClips.SelectedItems.Count == 1 && lstClips.Items.Count > 1)
            {
                int selected = lstClips.SelectedItems[0].Index;

                if (selected < lstClips.Items.Count - 1)
                {
                    lstClips.BeginUpdate();
                    ListViewItem item = lstClips.Items[selected + 1];
                    lstClips.Items.RemoveAt(selected + 1);
                    lstClips.Items.Insert(selected, item);
                    lstClips.EndUpdate();
                }

                setListNumbers();
                checkButtons();
            }
        }

        private void Form1_Layout(object sender, LayoutEventArgs e)
        {
            if (this.Height >= this.MinimumSize.Height && this.Width >= this.MinimumSize.Width)
            {
                height = this.Height;
                width = this.Width;
                splitH = splitContainerH.SplitterDistance;
                splitV = splitContainerV.SplitterDistance;
            }

            resizeColumns();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            resizeColumns();
        }

        private void btnRemoveIndent_Click(object sender, EventArgs e)
        {
            string[] lines = txtView.Text.Split(new[] { "\r\n" }, StringSplitOptions.None);

            int shortest = -1;
            foreach (string line in lines)
            {
                int spaceLength = spaces(line);
                if (spaceLength > -1)
                {
                    if (shortest > spaceLength || shortest == -1) shortest = spaceLength;
                }
            }

            if (shortest > 0)
            {
                txtView.SuspendLayout();
                txtView.Clear();

                int count = 0;
                foreach (string line in lines)
                {
                    if (line.Length > shortest) txtView.AppendText(line.Substring(shortest));
                    else txtView.AppendText(line);

                    if (lines.Count() > count + 1) txtView.AppendText(Environment.NewLine);
                    count++;
                }

                txtView.ResumeLayout();
            }
        }

        private int spaces(string line)
        {
            Regex x = new Regex(@"(^\s*)(\S*)(.*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Match m = x.Match(line);

            int spaceLength = -1;
            string space = m.Groups[1].Value;
            if (space.Length > 0) spaceLength = space.Length;
            if (spaceLength == -1 && line.Length > 0) spaceLength = 0;

            return spaceLength;
        }

        private void txtView_TextChanged(object sender, EventArgs e)
        {
            checkSave();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            checkSave();
        }

        private void lstClips_DoubleClick(object sender, EventArgs e)
        {
            btnCopy.PerformClick();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            Clipboard.Clear();
            checkButtons();
        }

    }
}
