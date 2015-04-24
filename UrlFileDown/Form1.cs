using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrlFileDown.Tool;

namespace UrlFileDown
{
    public partial class UrlFiledown : Form
    {
        private List<Options> list;
        private List<Options> displaylist;
        public UrlFiledown()
        {
            InitializeComponent();
            cmb_filetype.DataSource = typeof(OptionFileType).GetEnumNames();
            if (!string.IsNullOrWhiteSpace(CommonSettings.SaveFilePath))
            {
                lbsaveresult.Text = CommonSettings.SaveFilePath;
            }
            else
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "请选择下载保存路径";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    lbsaveresult.Text = dialog.SelectedPath;
                }
            }
            UrlDownFile.FileSavePath = lbsaveresult.Text;
            displaylist = new List<Options>();
            list = SerializeHelp<Options>.GetClassModelList(CommonSettings.SaveOptionPath);
            list.ForEach(m => displaylist.Add(m));
            dgvoptions.AutoGenerateColumns = false;
            BindOptions();
<<<<<<< HEAD
=======
            this.ShowDialog();
>>>>>>> 5ef4d249aa3c4ec382e57e1d90245aff63308ae6
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
                displaylist = SerializeHelp<Options>.SerializeModel(option, CommonSettings.SaveOptionPath,
                    option.SaveFileName);
                list = displaylist;
                BindOptions();
            }
        }

        private void BindOptions()
        {
            if (list != null)
            {
                dgvoptions.DataSource = displaylist;
            }
        }

        private void dgvoptions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                var filename = dgvoptions.Rows[e.RowIndex].Cells[3].Value.ToString();
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
                if (dgvoptions.Rows[e.RowIndex].Cells[0].Value == null)
                {
                    dgvoptions.Rows[e.RowIndex].Cells[0].Value = true;
                }
                else
                {
                    dgvoptions.Rows[e.RowIndex].Cells[0].Value = !(bool)dgvoptions.Rows[e.RowIndex].Cells[0].Value;
                }
            }
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                foreach (DataGridViewRow dr in dgvoptions.Rows)
                    dr.Cells[0].Value = true;
            }
        }
        private void btedit_Click(object sender, EventArgs e)
        {
            var option = GetSetOptions();
            if (!string.IsNullOrWhiteSpace(lbeditfilename.Text))
            {
                option.SaveFileName = lbeditfilename.Text;
                SerializeHelp<Options>.DeleteFile(CommonSettings.SaveOptionPath, lbeditfilename.Text);
                displaylist = SerializeHelp<Options>.SerializeModel(option, CommonSettings.SaveOptionPath,
                    option.SaveFileName);
                list = displaylist;
                BindOptions();
            }
        }
        private void btdelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lbeditfilename.Text))
            {
                displaylist = SerializeHelp<Options>.DeleteFile(CommonSettings.SaveOptionPath, lbeditfilename.Text);
                list = displaylist;
                BindOptions();
            }
        }
        private void bt_begin_Click(object sender, EventArgs e)
        {
            FilterOption();
            if (list == null || list.Count == 0)
                MessageBox.Show("请选择要下载的");
            UrlDownFile down = new UrlDownFile(list);
            down.DownEvent += down_DownEvent;
            System.Threading.Thread fileth = new Thread(new ThreadStart(down.GetFiles));
            fileth.IsBackground = true;
            fileth.Start();
           
        }

        void down_DownEvent(string obj)
        {
            lsbox_result.Invoke(new Action<string>(lsvlist), obj);


        }
        private void lsvlist(string obj)
        {
            lsbox_result.Items.Add(obj);
        }
        /// <summary>
        /// 只下载勾选的
        /// </summary>
        private void FilterOption()
        {
            var templist = new List<Options>();
            for (int i = 0; i < dgvoptions.Rows.Count; i++)
            {              
                if (dgvoptions.Rows[i].Cells[0].Value == null || !(bool)dgvoptions.Rows[i].Cells[0].Value)
                {
                    templist.Add(list[i]);
                }
            }
            templist.ForEach(m => list.Remove(m));
        }

        private void dgvoptions_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
