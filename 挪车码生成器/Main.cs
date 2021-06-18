using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Web.Script.Serialization;

namespace 挪车码生成器
{
    public partial class Main : Form
    {
        public const string ServiceUrl = "https://pdoner.cn/movecar/";
        public const string Regular = @"^1[3456789]\d{9}$";
        public const string FolderName = "\\我的挪车码";

        public UserData UserData;

        public Main()
        {
            InitializeComponent();
            Text = "挪车码生成器";
            Icon = Properties.Resources.logo;
            UserData = UserData.Load();
            tbxTel.Focus();
            tbxTel.Text = UserData.LastPhone;
            LoadPic(tbxTel.Text, pbxQRCode);

            tbxTel.TextChanged += (sender, e) =>
            {
                var tel = tbxTel.Text.Trim();
                if (string.IsNullOrWhiteSpace(tel)) return;
                if (tel.Length < 11) return;
                var isPhone = Regex.IsMatch(tel, Regular);
                if (isPhone)
                {
                    UserData.LastPhone = tel;
                    LoadPic(tel, pbxQRCode);
                }
            };

            btnSave.Click += (sender, e) =>
            {
                try
                {
                    if (Directory.Exists(UserData.LastSelectFoldPath) == false)
                    {
                        FolderBrowserDialog dialog = new FolderBrowserDialog
                        {
                            Description = "请选择保存路径",
                            RootFolder = Environment.SpecialFolder.DesktopDirectory
                        };
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            string foldPath = dialog.SelectedPath;
                            UserData.LastSelectFoldPath = foldPath;
                        }
                        else
                        {
                            return;
                        }
                    }
                    Directory.CreateDirectory(UserData.LastSelectFoldPath + FolderName);
                    string fileName = $"qr_{UserData.LastPhone}_{DateTime.Now:HHmmss}.jpg";
                    var savePath = Path.Combine(UserData.LastSelectFoldPath + FolderName, fileName);
                    pbxQRCode.Image.Save(savePath);
                    MessageBox.Show($"挪车码保存成功！\n保存路径：{savePath}", "", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                }
            };

            btnOpenDir.Click += (sender, e) =>
            {
                if (Directory.Exists(UserData.LastSelectFoldPath) == true)
                {
                    System.Diagnostics.Process.Start("explorer.exe", UserData.LastSelectFoldPath + FolderName);
                }
            };

            //关闭窗口退出主程序
            FormClosed += (sender, e) =>
            {
                UserData.Save();
                Environment.Exit(0);
            };
        }

        public void LoadPic(string content, PictureBox pb)
        {
            byte[] bytes = Encoding.Default.GetBytes(content);
            string str = Convert.ToBase64String(bytes);
            pb.Image = Utility.GenerateQRCode($"{ServiceUrl}?{str}", -1, 8);
        }
    }

    public class UserData
    {
        public string LastPhone { get; set; } = "18888888888";
        public string LastSelectFoldPath { get; set; }
        public bool Save()
        {
            try
            {
                var UserDataPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "挪车码生成器");
                var fullPath = Path.Combine(UserDataPath, "config.json");
                Directory.CreateDirectory(UserDataPath);
                File.WriteAllText(fullPath, Utility.Object2Json(this));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static UserData Load()
        {
            try
            {
                var UserDataPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "挪车码生成器");
                var tempData = new UserData();
                var fullPath = Path.Combine(UserDataPath, "config.json");
                Directory.CreateDirectory(UserDataPath);
                if (!File.Exists(fullPath))
                {
                    File.WriteAllText(fullPath, Utility.Object2Json(tempData));
                }
                StreamReader reader = File.OpenText(fullPath);
                var tempStr = reader.ReadToEnd();
                tempData = Utility.Json2Object<UserData>(tempStr);
                reader.Close();
                return tempData;
            }
            catch
            {
                return new UserData();
            }
        }
    }

    public class Utility
    {
        /// <summary>
        /// JSON转对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static T Json2Object<T>(string jsonStr)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                return js.Deserialize<T>(jsonStr);
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// 对象转JSON字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Object2Json(object obj)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                return js.Serialize(obj);
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="msg">信息</param>
        /// <param name="version">版本 1 ~ 40</param>
        /// <param name="pixel">像素点大小</param>
        /// <param name="icon_path">图标路径</param>
        /// <param name="icon_size">图标尺寸</param>
        /// <param name="icon_border">图标边框厚度</param>
        /// <param name="white_edge">二维码白边</param>
        /// <returns>位图</returns>
        public static Bitmap GenerateQRCode(string msg, int version, int pixel, string icon_path = null, int icon_size = 0, int icon_border = 0, bool white_edge = true)
        {

            QRCoder.QRCodeGenerator code_generator = new QRCoder.QRCodeGenerator();

            QRCoder.QRCodeData code_data = code_generator
                .CreateQrCode(plainText: msg,
                eccLevel: QRCoder.QRCodeGenerator.ECCLevel.M
               );

            QRCoder.QRCode code = new QRCoder.QRCode(code_data);

            Bitmap icon = null;
            if (!string.IsNullOrWhiteSpace(icon_path))
            {
                icon = new Bitmap(icon_path);
            }
            Bitmap bmp = code.GetGraphic(pixel, Color.Black, Color.White, icon, icon_size, icon_border, white_edge);

            return bmp;

        }
    }

}
