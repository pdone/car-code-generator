
namespace 挪车码生成器
{
    partial class Main
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pbxQRCode = new System.Windows.Forms.PictureBox();
            this.tbxTel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpenDir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxQRCode
            // 
            this.pbxQRCode.Location = new System.Drawing.Point(13, 13);
            this.pbxQRCode.Name = "pbxQRCode";
            this.pbxQRCode.Size = new System.Drawing.Size(350, 350);
            this.pbxQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxQRCode.TabIndex = 0;
            this.pbxQRCode.TabStop = false;
            // 
            // tbxTel
            // 
            this.tbxTel.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.tbxTel.Location = new System.Drawing.Point(369, 209);
            this.tbxTel.MaxLength = 11;
            this.tbxTel.Name = "tbxTel";
            this.tbxTel.Size = new System.Drawing.Size(172, 32);
            this.tbxTel.TabIndex = 1;
            this.tbxTel.Text = "18888888888";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(369, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 193);
            this.label1.TabIndex = 2;
            this.label1.Text = "使用方法：\r\n1.输入手机号码\r\n2.保存到桌面\r\n3.用作图软件添加“扫码挪车”字样后打印出来\r\n4.临时停车的时候放在车头显眼位置";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(369, 247);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(172, 55);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnOpenDir
            // 
            this.btnOpenDir.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpenDir.Location = new System.Drawing.Point(369, 308);
            this.btnOpenDir.Name = "btnOpenDir";
            this.btnOpenDir.Size = new System.Drawing.Size(172, 55);
            this.btnOpenDir.TabIndex = 5;
            this.btnOpenDir.Text = "打开保存目录";
            this.btnOpenDir.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 375);
            this.Controls.Add(this.btnOpenDir);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxTel);
            this.Controls.Add(this.pbxQRCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pbxQRCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxQRCode;
        private System.Windows.Forms.TextBox tbxTel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOpenDir;
    }
}

