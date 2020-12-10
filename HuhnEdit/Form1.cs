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

namespace HuhnEdit
{
    public partial class Form1 : Form
    {
        public string currentFile = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void fastColoredTextBox1_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            if (webBrowser1.Visible == true)
            {
                webBrowser1.DocumentText = fastColoredTextBox1.Text;
            }
        }

        private void TestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save current code?", "New File", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (currentFile != null)
                {
                    StreamWriter sw = new StreamWriter(currentFile);
                    sw.Write(fastColoredTextBox1.Text);
                    sw.Close();
                }
                fastColoredTextBox1.Clear();
                currentFile = null;
            }
            else
            {
                fastColoredTextBox1.Clear();
                currentFile = null;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save the current code?", "Open File", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (currentFile != null)
                {
                    StreamWriter sw = new StreamWriter(currentFile);
                    sw.Write(fastColoredTextBox1.Text);
                    sw.Close();
                }
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "HTML-File|*.html|JavaScript-File|*.js|PHP-File|*.php|SQL-File|*.sql|XML-FIle|*.xml|C#-File|*.cs|VisualBasic-File|*.vb|Lua-File|*.lua|Text-File|*.txt|Any File|*.*";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(op.FileName);
                    currentFile = op.FileName;
                    fastColoredTextBox1.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
            else
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "HTML-File|*.html|JavaScript-File|*.js|PHP-File|*.php|SQL-File|*.sql|XML-FIle|*.xml|C#-File|*.cs|VisualBasic-File|*.vb|Lua-File|*.lua|Text-File|*.txt|Any File|*.*";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(op.FileName);
                    currentFile = op.FileName;
                    fastColoredTextBox1.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFile != null)
            {
                StreamWriter sw = new StreamWriter(currentFile);
                sw.Write(fastColoredTextBox1.Text);
                sw.Close();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog op = new SaveFileDialog();
            op.Filter = "HTML-File|*.html|JavaScript-File|*.js|PHP-File|*.php|SQL-File|*.sql|XML-FIle|*.xml|C#-File|*.cs|VisualBasic-File|*.vb|Lua-File|*.lua|Text-File|*.txt|Any File|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sr = new StreamWriter(op.FileName);
                currentFile = op.FileName;
                sr.Write(fastColoredTextBox1.Text);
                sr.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save the current code?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (currentFile != null)
                {
                    StreamWriter sw = new StreamWriter(currentFile);
                    sw.Write(fastColoredTextBox1.Text);
                    sw.Close();
                }
                Application.Exit();
            }
            else
            {
                Application.Exit();
            }
        }

        private void hTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.HTML;
        }

        private void jSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.JS;
        }

        private void pHPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.PHP;
        }

        private void sQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.SQL;
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.XML;
        }

        private void cSharpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.CSharp;
        }

        private void vBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.VB;
        }

        private void luaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Lua;
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Custom;
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webBrowser1.Visible == true)
            {
                webBrowser1.Visible = false;
            }
            else
            {
                webBrowser1.Visible = true;
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowFindDialog();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowReplaceDialog();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Paste();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webBrowser1.Visible = false;
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Custom;
            fastColoredTextBox1.Text = "HuhnCares: \n" +
            "Twitter: https://twitter.com/huhncares \n" +
            "GitHub: https://github.com/huhncares-cmd";
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Visible = false;
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Custom;
            fastColoredTextBox1.Text = "Credits: \n" +
            "Idea: https://www.youtube.com/watch?v=yhl8hnPvIxE \n" +
            "Logo: https://logomakr.com/";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void themeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.FormBackground = colorDlg.Color;
                Properties.Settings.Default.Save();
                this.BackColor = colorDlg.Color;
            }
        }

        private void fontSelectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog col = new ColorDialog();
            if (col.ShowDialog() == DialogResult.OK)
            {
                fastColoredTextBox1.ForeColor = col.Color;
            }
        }
    }
}
