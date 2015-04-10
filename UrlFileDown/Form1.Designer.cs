namespace UrlFileDown
{
    partial class UrlFiledown
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tb_encoding = new System.Windows.Forms.TextBox();
            this.lbencoding = new System.Windows.Forms.Label();
            this.lbfiletype = new System.Windows.Forms.Label();
            this.cmb_filetype = new System.Windows.Forms.ComboBox();
            this.bt_begin = new System.Windows.Forms.Button();
            this.btdelete = new System.Windows.Forms.Button();
            this.btedit = new System.Windows.Forms.Button();
            this.lbeditfilename = new System.Windows.Forms.Label();
            this.txwebname = new System.Windows.Forms.TextBox();
            this.lbwebname = new System.Windows.Forms.Label();
            this.listgroup = new System.Windows.Forms.GroupBox();
            this.tbdetailreg = new System.Windows.Forms.TextBox();
            this.nextpagegroup = new System.Windows.Forms.GroupBox();
            this.tbnextpagereg = new System.Windows.Forms.TextBox();
            this.isdetail = new System.Windows.Forms.CheckBox();
            this.isnextpage = new System.Windows.Forms.CheckBox();
            this.lbsaveresult = new System.Windows.Forms.Label();
            this.lbsavepath = new System.Windows.Forms.Label();
            this.btaddsource = new System.Windows.Forms.Button();
            this.tbreg = new System.Windows.Forms.TextBox();
            this.lbreg = new System.Windows.Forms.Label();
            this.tburl = new System.Windows.Forms.TextBox();
            this.lburltitle = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvoptions = new System.Windows.Forms.DataGridView();
            this.WebName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaveFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsv_downresult = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.listgroup.SuspendLayout();
            this.nextpagegroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvoptions)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tb_encoding);
            this.splitContainer1.Panel1.Controls.Add(this.lbencoding);
            this.splitContainer1.Panel1.Controls.Add(this.lbfiletype);
            this.splitContainer1.Panel1.Controls.Add(this.cmb_filetype);
            this.splitContainer1.Panel1.Controls.Add(this.bt_begin);
            this.splitContainer1.Panel1.Controls.Add(this.btdelete);
            this.splitContainer1.Panel1.Controls.Add(this.btedit);
            this.splitContainer1.Panel1.Controls.Add(this.lbeditfilename);
            this.splitContainer1.Panel1.Controls.Add(this.txwebname);
            this.splitContainer1.Panel1.Controls.Add(this.lbwebname);
            this.splitContainer1.Panel1.Controls.Add(this.listgroup);
            this.splitContainer1.Panel1.Controls.Add(this.nextpagegroup);
            this.splitContainer1.Panel1.Controls.Add(this.isdetail);
            this.splitContainer1.Panel1.Controls.Add(this.isnextpage);
            this.splitContainer1.Panel1.Controls.Add(this.lbsaveresult);
            this.splitContainer1.Panel1.Controls.Add(this.lbsavepath);
            this.splitContainer1.Panel1.Controls.Add(this.btaddsource);
            this.splitContainer1.Panel1.Controls.Add(this.tbreg);
            this.splitContainer1.Panel1.Controls.Add(this.lbreg);
            this.splitContainer1.Panel1.Controls.Add(this.tburl);
            this.splitContainer1.Panel1.Controls.Add(this.lburltitle);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(947, 607);
            this.splitContainer1.SplitterDistance = 315;
            this.splitContainer1.TabIndex = 4;
            // 
            // tb_encoding
            // 
            this.tb_encoding.Location = new System.Drawing.Point(83, 358);
            this.tb_encoding.Name = "tb_encoding";
            this.tb_encoding.Size = new System.Drawing.Size(100, 21);
            this.tb_encoding.TabIndex = 24;
            // 
            // lbencoding
            // 
            this.lbencoding.AutoSize = true;
            this.lbencoding.Location = new System.Drawing.Point(12, 361);
            this.lbencoding.Name = "lbencoding";
            this.lbencoding.Size = new System.Drawing.Size(53, 12);
            this.lbencoding.TabIndex = 23;
            this.lbencoding.Text = "页面编码";
            // 
            // lbfiletype
            // 
            this.lbfiletype.AutoSize = true;
            this.lbfiletype.Location = new System.Drawing.Point(12, 325);
            this.lbfiletype.Name = "lbfiletype";
            this.lbfiletype.Size = new System.Drawing.Size(53, 12);
            this.lbfiletype.TabIndex = 22;
            this.lbfiletype.Text = "资源类型";
            // 
            // cmb_filetype
            // 
            this.cmb_filetype.FormattingEnabled = true;
            this.cmb_filetype.Location = new System.Drawing.Point(71, 322);
            this.cmb_filetype.Name = "cmb_filetype";
            this.cmb_filetype.Size = new System.Drawing.Size(121, 20);
            this.cmb_filetype.TabIndex = 21;
            // 
            // bt_begin
            // 
            this.bt_begin.Location = new System.Drawing.Point(27, 491);
            this.bt_begin.Name = "bt_begin";
            this.bt_begin.Size = new System.Drawing.Size(256, 23);
            this.bt_begin.TabIndex = 20;
            this.bt_begin.Text = "开始";
            this.bt_begin.UseVisualStyleBackColor = true;
            this.bt_begin.Click += new System.EventHandler(this.bt_begin_Click);
            // 
            // btdelete
            // 
            this.btdelete.Location = new System.Drawing.Point(217, 417);
            this.btdelete.Name = "btdelete";
            this.btdelete.Size = new System.Drawing.Size(82, 40);
            this.btdelete.TabIndex = 19;
            this.btdelete.Text = "删除";
            this.btdelete.UseVisualStyleBackColor = true;
            this.btdelete.Click += new System.EventHandler(this.btdelete_Click);
            // 
            // btedit
            // 
            this.btedit.Location = new System.Drawing.Point(104, 417);
            this.btedit.Name = "btedit";
            this.btedit.Size = new System.Drawing.Size(107, 40);
            this.btedit.TabIndex = 18;
            this.btedit.Text = "修改";
            this.btedit.UseVisualStyleBackColor = true;
            this.btedit.Click += new System.EventHandler(this.btedit_Click);
            // 
            // lbeditfilename
            // 
            this.lbeditfilename.AutoSize = true;
            this.lbeditfilename.Location = new System.Drawing.Point(255, 547);
            this.lbeditfilename.Name = "lbeditfilename";
            this.lbeditfilename.Size = new System.Drawing.Size(0, 12);
            this.lbeditfilename.TabIndex = 17;
            // 
            // txwebname
            // 
            this.txwebname.Location = new System.Drawing.Point(85, 9);
            this.txwebname.Name = "txwebname";
            this.txwebname.Size = new System.Drawing.Size(173, 21);
            this.txwebname.TabIndex = 16;
            // 
            // lbwebname
            // 
            this.lbwebname.AutoSize = true;
            this.lbwebname.Location = new System.Drawing.Point(12, 9);
            this.lbwebname.Name = "lbwebname";
            this.lbwebname.Size = new System.Drawing.Size(53, 12);
            this.lbwebname.TabIndex = 15;
            this.lbwebname.Text = "网站名称";
            // 
            // listgroup
            // 
            this.listgroup.Controls.Add(this.tbdetailreg);
            this.listgroup.Location = new System.Drawing.Point(60, 258);
            this.listgroup.Name = "listgroup";
            this.listgroup.Size = new System.Drawing.Size(216, 46);
            this.listgroup.TabIndex = 14;
            this.listgroup.TabStop = false;
            this.listgroup.Text = "详情正则";
            // 
            // tbdetailreg
            // 
            this.tbdetailreg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbdetailreg.Location = new System.Drawing.Point(3, 17);
            this.tbdetailreg.Multiline = true;
            this.tbdetailreg.Name = "tbdetailreg";
            this.tbdetailreg.Size = new System.Drawing.Size(210, 26);
            this.tbdetailreg.TabIndex = 1;
            // 
            // nextpagegroup
            // 
            this.nextpagegroup.Controls.Add(this.tbnextpagereg);
            this.nextpagegroup.Location = new System.Drawing.Point(60, 206);
            this.nextpagegroup.Name = "nextpagegroup";
            this.nextpagegroup.Size = new System.Drawing.Size(219, 46);
            this.nextpagegroup.TabIndex = 13;
            this.nextpagegroup.TabStop = false;
            this.nextpagegroup.Text = "分页正则";
            // 
            // tbnextpagereg
            // 
            this.tbnextpagereg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbnextpagereg.Location = new System.Drawing.Point(3, 17);
            this.tbnextpagereg.Multiline = true;
            this.tbnextpagereg.Name = "tbnextpagereg";
            this.tbnextpagereg.Size = new System.Drawing.Size(213, 26);
            this.tbnextpagereg.TabIndex = 0;
            // 
            // isdetail
            // 
            this.isdetail.AutoSize = true;
            this.isdetail.Location = new System.Drawing.Point(159, 184);
            this.isdetail.Name = "isdetail";
            this.isdetail.Size = new System.Drawing.Size(96, 16);
            this.isdetail.TabIndex = 12;
            this.isdetail.Text = "是否进入详情";
            this.isdetail.UseVisualStyleBackColor = true;
            // 
            // isnextpage
            // 
            this.isnextpage.AutoSize = true;
            this.isnextpage.Location = new System.Drawing.Point(60, 184);
            this.isnextpage.Name = "isnextpage";
            this.isnextpage.Size = new System.Drawing.Size(72, 16);
            this.isnextpage.TabIndex = 11;
            this.isnextpage.Text = "是否分页";
            this.isnextpage.UseVisualStyleBackColor = true;
            // 
            // lbsaveresult
            // 
            this.lbsaveresult.AutoSize = true;
            this.lbsaveresult.Location = new System.Drawing.Point(40, 586);
            this.lbsaveresult.Name = "lbsaveresult";
            this.lbsaveresult.Size = new System.Drawing.Size(0, 12);
            this.lbsaveresult.TabIndex = 10;
            // 
            // lbsavepath
            // 
            this.lbsavepath.AutoSize = true;
            this.lbsavepath.Location = new System.Drawing.Point(12, 558);
            this.lbsavepath.Name = "lbsavepath";
            this.lbsavepath.Size = new System.Drawing.Size(53, 12);
            this.lbsavepath.TabIndex = 9;
            this.lbsavepath.Text = "保存路径";
            // 
            // btaddsource
            // 
            this.btaddsource.Location = new System.Drawing.Point(5, 417);
            this.btaddsource.Name = "btaddsource";
            this.btaddsource.Size = new System.Drawing.Size(93, 40);
            this.btaddsource.TabIndex = 8;
            this.btaddsource.Text = "添加";
            this.btaddsource.UseVisualStyleBackColor = true;
            this.btaddsource.Click += new System.EventHandler(this.btaddsource_Click);
            // 
            // tbreg
            // 
            this.tbreg.Location = new System.Drawing.Point(88, 89);
            this.tbreg.Multiline = true;
            this.tbreg.Name = "tbreg";
            this.tbreg.Size = new System.Drawing.Size(173, 69);
            this.tbreg.TabIndex = 7;
            // 
            // lbreg
            // 
            this.lbreg.AutoSize = true;
            this.lbreg.Location = new System.Drawing.Point(5, 89);
            this.lbreg.Name = "lbreg";
            this.lbreg.Size = new System.Drawing.Size(77, 12);
            this.lbreg.TabIndex = 6;
            this.lbreg.Text = "抓取资源正则";
            // 
            // tburl
            // 
            this.tburl.Location = new System.Drawing.Point(88, 45);
            this.tburl.Name = "tburl";
            this.tburl.Size = new System.Drawing.Size(173, 21);
            this.tburl.TabIndex = 5;
            // 
            // lburltitle
            // 
            this.lburltitle.AutoSize = true;
            this.lburltitle.Location = new System.Drawing.Point(12, 45);
            this.lburltitle.Name = "lburltitle";
            this.lburltitle.Size = new System.Drawing.Size(47, 12);
            this.lburltitle.TabIndex = 4;
            this.lburltitle.Text = "页面Url";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvoptions);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lsv_downresult);
            this.splitContainer2.Size = new System.Drawing.Size(628, 607);
            this.splitContainer2.SplitterDistance = 209;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvoptions
            // 
            this.dgvoptions.AllowUserToAddRows = false;
            this.dgvoptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvoptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvoptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WebName,
            this.MainUrl,
            this.SaveFileName,
            this.FileType});
            this.dgvoptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvoptions.Location = new System.Drawing.Point(0, 0);
            this.dgvoptions.Name = "dgvoptions";
            this.dgvoptions.RowTemplate.Height = 23;
            this.dgvoptions.Size = new System.Drawing.Size(628, 209);
            this.dgvoptions.TabIndex = 0;
            this.dgvoptions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvoptions_CellClick);
            // 
            // WebName
            // 
            this.WebName.DataPropertyName = "Title";
            this.WebName.HeaderText = "网站名称";
            this.WebName.Name = "WebName";
            // 
            // MainUrl
            // 
            this.MainUrl.DataPropertyName = "MainUrl";
            this.MainUrl.HeaderText = "进入URL";
            this.MainUrl.Name = "MainUrl";
            // 
            // SaveFileName
            // 
            this.SaveFileName.DataPropertyName = "SaveFileName";
            this.SaveFileName.HeaderText = "序列化文件名称";
            this.SaveFileName.Name = "SaveFileName";
            // 
            // FileType
            // 
            this.FileType.DataPropertyName = "FileType";
            this.FileType.HeaderText = "资源类型";
            this.FileType.Name = "FileType";
            // 
            // lsv_downresult
            // 
            this.lsv_downresult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lsv_downresult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsv_downresult.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lsv_downresult.Location = new System.Drawing.Point(0, 0);
            this.lsv_downresult.Name = "lsv_downresult";
            this.lsv_downresult.Size = new System.Drawing.Size(628, 394);
            this.lsv_downresult.TabIndex = 0;
            this.lsv_downresult.UseCompatibleStateImageBehavior = false;
            this.lsv_downresult.View = System.Windows.Forms.View.List;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 500;
            // 
            // UrlFiledown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 607);
            this.Controls.Add(this.splitContainer1);
            this.Name = "UrlFiledown";
            this.Text = "Url资源下载";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.listgroup.ResumeLayout(false);
            this.listgroup.PerformLayout();
            this.nextpagegroup.ResumeLayout(false);
            this.nextpagegroup.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvoptions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btaddsource;
        private System.Windows.Forms.TextBox tbreg;
        private System.Windows.Forms.Label lbreg;
        private System.Windows.Forms.TextBox tburl;
        private System.Windows.Forms.Label lburltitle;
        private System.Windows.Forms.Label lbsaveresult;
        private System.Windows.Forms.Label lbsavepath;
        private System.Windows.Forms.CheckBox isdetail;
        private System.Windows.Forms.CheckBox isnextpage;
        private System.Windows.Forms.GroupBox listgroup;
        private System.Windows.Forms.TextBox tbdetailreg;
        private System.Windows.Forms.GroupBox nextpagegroup;
        private System.Windows.Forms.TextBox tbnextpagereg;
        private System.Windows.Forms.TextBox txwebname;
        private System.Windows.Forms.Label lbwebname;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvoptions;
        private System.Windows.Forms.Label lbeditfilename;
        private System.Windows.Forms.Button btdelete;
        private System.Windows.Forms.Button btedit;
        private System.Windows.Forms.Button bt_begin;
        private System.Windows.Forms.Label lbfiletype;
        private System.Windows.Forms.ComboBox cmb_filetype;
        private System.Windows.Forms.DataGridViewTextBoxColumn WebName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MainUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaveFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileType;
        private System.Windows.Forms.ListView lsv_downresult;
        private System.Windows.Forms.TextBox tb_encoding;
        private System.Windows.Forms.Label lbencoding;
        private System.Windows.Forms.ColumnHeader columnHeader1;

    }
}

