using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrlFileDown.Tool;

namespace UrlFileDown
{
    public partial class UrlFiledown : Form
    {
        private List<Options> list;
        public UrlFiledown()
        {
            InitializeComponent();
            cmb_filetype.DataSource = typeof(OptionFileType).GetEnumNames();
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择下载保存路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                lbsaveresult.Text = dialog.SelectedPath;
                list = SerializeHelp<Options>.GetClassModelList(CommonSettings.SaveOptionPath);
                dgvoptions.AutoGenerateColumns = false;
                BindOptions();
            }
        }
        private Options GetSetOptions()
        {
            Options option = new Options();
            if (string.IsNullOrWhiteSpace(txwebname.Text))
            {
                MessageBox.Show("请填写网站名称");
                return null;
            }
            if (string.IsNullOrWhiteSpace(lbsaveresult.Text))
            {
                MessageBox.Show("请选择保存路径");
                return null;
            }
            if (string.IsNullOrWhiteSpace(tbreg.Text))
            {
                MessageBox.Show("抓取正则不能为空");
                return null;
            }
            if (string.IsNullOrWhiteSpace(tburl.Text))
            {
                MessageBox.Show("采集url不能为空");
                return null;
            }
            if (isnextpage.Checked)
            {
                if (string.IsNullOrWhiteSpace(tbnextpagereg.Text))
                {
                    MessageBox.Show("分页规则不能为空");
                    return null;
                }
                option.NextPageReg = tbnextpagereg.Text;
            }
            if (isdetail.Checked)
            {
                if (string.IsNullOrWhiteSpace(tbdetailreg.Text))
                {
                    MessageBox.Show("详情规则不能为空");
                    return null;
                }
                option.DetailReg = tbdetailreg.Text;
            }
            option.DownFileReg = tbreg.Text;
            option.IsDetail = isdetail.Checked;
            option.IsNextPage = isnextpage.Checked;
            option.Title = txwebname.Text;
            option.SavePath = lbsaveresult.Text;
            option.MainUrl = tburl.Text;
            option.SaveFileName = DateTime.Now.ToString("yyyyMMddHHssmm");
            option.Encoding = tb_encoding.Text;
            option.FileType = (OptionFileType)Enum.Parse(typeof(OptionFileType), cmb_filetype.SelectedValue.ToString());
            return option;
        }

        private void btaddsource_Click(object sender, EventArgs e)
        {
            var option = GetSetOptions();

            if (option != null)
            {
                list = SerializeHelp<Options>.SerializeModel(option, CommonSettings.SaveOptionPath,
                    option.SaveFileName);
                BindOptions();
            }



        }

        private void BindOptions()
        {
            if (list != null)
            {
                dgvoptions.DataSource = list;
            }
        }

        private void dgvoptions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                var filename = dgvoptions.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (list != null && list.Count > 0)
                {
                    var model = list.SingleOrDefault(m => m.SaveFileName == filename.Trim());
                    if (model != null)
                    {
                        txwebname.Text = model.Title;
                        tburl.Text = model.MainUrl;
                        tbreg.Text = model.DownFileReg;
                        tbnextpagereg.Text = model.NextPageReg;
                        tbdetailreg.Text = model.DetailReg;
                        isnextpage.Checked = model.IsNextPage;
                        isdetail.Checked = model.IsDetail;
                        lbeditfilename.Text = filename;
                        cmb_filetype.SelectedIndex = (int)model.FileType;
                        tb_encoding.Text = model.Encoding;
                        // lbeditfilename.Visible = false;
                    }
                }
            }
        }
        private void btedit_Click(object sender, EventArgs e)
        {
            var option = GetSetOptions();
            if (!string.IsNullOrWhiteSpace(lbeditfilename.Text))
            {
                option.SaveFileName = lbeditfilename.Text;
                SerializeHelp<Options>.DeleteFile(CommonSettings.SaveOptionPath, lbeditfilename.Text);
                list = SerializeHelp<Options>.SerializeModel(option, CommonSettings.SaveOptionPath,
                    option.SaveFileName);
                BindOptions();
            }
        }
        private void btdelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lbeditfilename.Text))
            {
                list = SerializeHelp<Options>.DeleteFile(CommonSettings.SaveOptionPath, lbeditfilename.Text);

                BindOptions();
            }
        }
        private void bt_begin_Click(object sender, EventArgs e)
        {
            UrlDownFile down = new UrlDownFile(list);
            down.DownEvent += down_DownEvent;
            down.GetFiles();
        }

        void down_DownEvent(string obj)
        {
            lsv_downresult.Invoke(new Action<string>(lsvlist), obj);


        }
        private void lsvlist(string obj)
        {
            lsv_downresult.Items.Add(new ListViewItem { Text = obj });
        }
    }
}
