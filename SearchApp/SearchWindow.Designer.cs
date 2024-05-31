namespace SearchApp
{
    partial class SearchWindow
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Program Files");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Windows");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Users");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("С:\\", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchWindow));
            this.ResultsView = new System.Windows.Forms.TreeView();
            this.FileIcons = new System.Windows.Forms.ImageList(this.components);
            this.SearchFolderInput = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.FoundText = new System.Windows.Forms.Label();
            this.TimeText = new System.Windows.Forms.Label();
            this.StateText = new System.Windows.Forms.Label();
            this.CountText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ResumeButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchQueryInput = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.StopwatchUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResultsView
            // 
            this.ResultsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultsView.FullRowSelect = true;
            this.ResultsView.ImageIndex = 0;
            this.ResultsView.ImageList = this.FileIcons;
            this.ResultsView.Location = new System.Drawing.Point(0, 0);
            this.ResultsView.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ResultsView.Name = "ResultsView";
            treeNode1.Name = "Узел1";
            treeNode1.Text = "Program Files";
            treeNode2.Name = "Узел2";
            treeNode2.Text = "Windows";
            treeNode3.Name = "Узел14";
            treeNode3.Text = "Users";
            treeNode4.Name = "С:\\";
            treeNode4.Text = "С:\\";
            this.ResultsView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.ResultsView.SelectedImageIndex = 0;
            this.ResultsView.Size = new System.Drawing.Size(1152, 501);
            this.ResultsView.TabIndex = 0;
            // 
            // FileIcons
            // 
            this.FileIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FileIcons.ImageStream")));
            this.FileIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.FileIcons.Images.SetKeyName(0, "folder.png");
            this.FileIcons.Images.SetKeyName(1, "file.png");
            // 
            // SearchFolderInput
            // 
            this.SearchFolderInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchFolderInput.Location = new System.Drawing.Point(117, 10);
            this.SearchFolderInput.Margin = new System.Windows.Forms.Padding(4);
            this.SearchFolderInput.Name = "SearchFolderInput";
            this.SearchFolderInput.Size = new System.Drawing.Size(387, 22);
            this.SearchFolderInput.TabIndex = 1;
            this.SearchFolderInput.Text = "C:\\";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.FoundText, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TimeText, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.StateText, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.CountText, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 600);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1152, 54);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // FoundText
            // 
            this.FoundText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FoundText.AutoSize = true;
            this.FoundText.Location = new System.Drawing.Point(4, 5);
            this.FoundText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FoundText.Name = "FoundText";
            this.FoundText.Size = new System.Drawing.Size(50, 16);
            this.FoundText.TabIndex = 2;
            this.FoundText.Text = "0 found";
            this.FoundText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TimeText
            // 
            this.TimeText.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TimeText.AutoSize = true;
            this.TimeText.Location = new System.Drawing.Point(1110, 32);
            this.TimeText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TimeText.Name = "TimeText";
            this.TimeText.Size = new System.Drawing.Size(38, 16);
            this.TimeText.TabIndex = 0;
            this.TimeText.Text = "Time";
            this.TimeText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StateText
            // 
            this.StateText.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.StateText.AutoSize = true;
            this.StateText.Location = new System.Drawing.Point(1079, 5);
            this.StateText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StateText.Name = "StateText";
            this.StateText.Size = new System.Drawing.Size(69, 16);
            this.StateText.TabIndex = 1;
            this.StateText.Text = "Doing stuff";
            this.StateText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CountText
            // 
            this.CountText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CountText.AutoSize = true;
            this.CountText.Location = new System.Drawing.Point(4, 32);
            this.CountText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CountText.Name = "CountText";
            this.CountText.Size = new System.Drawing.Size(82, 16);
            this.CountText.TabIndex = 3;
            this.CountText.Text = "0 in directory";
            this.CountText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Текст запроса";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Путь поиска";
            // 
            // ResumeButton
            // 
            this.ResumeButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ResumeButton.Enabled = false;
            this.ResumeButton.Location = new System.Drawing.Point(1049, 49);
            this.ResumeButton.Margin = new System.Windows.Forms.Padding(4);
            this.ResumeButton.Name = "ResumeButton";
            this.ResumeButton.Size = new System.Drawing.Size(99, 28);
            this.ResumeButton.TabIndex = 7;
            this.ResumeButton.Text = "Resume";
            this.ResumeButton.UseVisualStyleBackColor = true;
            this.ResumeButton.Click += new System.EventHandler(this.ResumeButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(1049, 7);
            this.StopButton.Margin = new System.Windows.Forms.Padding(4);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(99, 28);
            this.StopButton.TabIndex = 6;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.PauseButton.Enabled = false;
            this.PauseButton.Location = new System.Drawing.Point(941, 49);
            this.PauseButton.Margin = new System.Windows.Forms.Padding(4);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(100, 28);
            this.PauseButton.TabIndex = 5;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SearchButton.Location = new System.Drawing.Point(941, 7);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(4);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(100, 28);
            this.SearchButton.TabIndex = 4;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchQueryInput
            // 
            this.SearchQueryInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchQueryInput.Location = new System.Drawing.Point(117, 52);
            this.SearchQueryInput.Margin = new System.Windows.Forms.Padding(4);
            this.SearchQueryInput.Name = "SearchQueryInput";
            this.SearchQueryInput.Size = new System.Drawing.Size(387, 22);
            this.SearchQueryInput.TabIndex = 3;
            this.SearchQueryInput.Text = "Query";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.ResultsView);
            this.panel3.Location = new System.Drawing.Point(0, 91);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1152, 501);
            this.panel3.TabIndex = 5;
            // 
            // StopwatchUpdateTimer
            // 
            this.StopwatchUpdateTimer.Interval = 10;
            this.StopwatchUpdateTimer.Tick += new System.EventHandler(this.StopwatchTimer_Tick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.809028F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.52778F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.375F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.288195F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.SearchButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.StopButton, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.SearchQueryInput, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.SearchFolderInput, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.ResumeButton, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.PauseButton, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1152, 84);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // SearchWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 654);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SearchWindow";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList FileIcons;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button ResumeButton;
        public System.Windows.Forms.TreeView ResultsView;
        public System.Windows.Forms.TextBox SearchFolderInput;
        public System.Windows.Forms.Label TimeText;
        public System.Windows.Forms.Label CountText;
        public System.Windows.Forms.Label FoundText;
        public System.Windows.Forms.Label StateText;
        public System.Windows.Forms.TextBox SearchQueryInput;
        public System.Windows.Forms.Timer StopwatchUpdateTimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}

