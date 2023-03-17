using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ImageCompressorTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // 设置默认值
            trackBar.Value = 50;
            lblQuality.Text = $"{trackBar.Value}%";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = openFileDialog.FileName;
                    picOriginal.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void btnCompress_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilePath.Text))
            {
                MessageBox.Show("请选择要压缩的图像文件.");
                return;
            }

            // Get the quality value from the track bar
            int quality = trackBar.Value;

            // Load the original image
            Image originalImage = Image.FromFile(txtFilePath.Text);

            // Create an encoder parameter for the quality level
            EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, quality);

            // Get the codec for the JPEG file format
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");

            // Create a new encoder parameters object and set the quality parameter
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            // Create a new memory stream to hold the compressed image
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Save the compressed image to the memory stream using the JPEG codec and the quality parameter
                originalImage.Save(memoryStream, jpegCodec, encoderParams);

                // Load the compressed image from the memory stream
                Image compressedImage = Image.FromStream(memoryStream);

                // Display the compressed image in the picture box
                picCompressed.Image = compressedImage;

                // Display the compressed file size in the label
                lblFileSize.Text = $"文件大小: {memoryStream.Length / 1024} KB";
            }
        }

        // 获取图片编码器
        private ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.MimeType == mimeType)
                {
                    return codec;
                }
            }
            return null;
        }

        public void trackBar_Scroll(object sender, EventArgs e)
        {
            // 更新标签和压缩质量

            // 获取滑动条的值
            int quality = trackBar.Value;

            // 显示压缩质量
            lblQuality.Text = $"压缩质量: {quality}%";

            //// 获取原始图片路径
            //string originalFilePath = txtFilePath.Text;

            //// 如果原始图片路径为空，则返回
            //if (string.IsNullOrEmpty(originalFilePath))
            //{
            //    return;
            //}

            //// 加载原始图片
            //Image originalImage = Image.FromFile(originalFilePath);

            //// 压缩原始图片
            //Image compressedImage = CompressImage(originalImage, quality);

            //// 显示压缩后的图片
            //picCompressed.Image = compressedImage;

            //// 计算压缩后的文件大小
            //long compressedFileSize = GetImageFileSize(compressedImage);

            //// 显示压缩后的文件大小
            //lblFileSize.Text = $"File Size: {GetSizeString(compressedFileSize)}";

            //// 释放图片资源
            //originalImage.Dispose();
            //compressedImage.Dispose();
        }

        // 压缩图片
        private Image CompressImage(Image originalImage, int quality)
        {
            // 设置图片压缩编码器的参数
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            // 使用图片压缩编码器压缩原始图片
            MemoryStream stream = new MemoryStream();
            originalImage.Save(stream, jpegCodec, encoderParams);

            // 从内存流中创建并返回压缩后的图片
            return Image.FromStream(stream);
        }

        // 获取图片文件大小
        private long GetImageFileSize(Image image)
        {
            // 将图片保存到内存流中
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, image.RawFormat);

                // 返回内存流的长度
                return stream.Length;
            }
        }

        // 将文件大小转换为易读的字符串
        private string GetSizeString(long fileSize)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = fileSize;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len /= 1024;
            }
            return $"{len:0.##} {sizes[order]}";
        }

        private void picCompressed_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // 显示上下文菜单
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        /// <summary>
        /// 创建了一个新的 Bitmap 对象，并将其 PixelFormat 属性设置为 PixelFormat.Format32bppArgb。
        /// 接下来，我们使用 Graphics 对象将原始图片绘制到新的 Bitmap 对象上，然后将其保存到文件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 创建一个保存文件对话框
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPEG文件 (*.jpg)|*.jpg|PNG文件 (*.png)|*.png";
            saveFileDialog.Title = "保存图片";
            saveFileDialog.ShowDialog();

            #region .NET Framework中
            //// 如果用户选择了文件保存路径，则保存图片
            //if (saveFileDialog.FileName != "")
            //{
            //    // 保存图片
            //    picCompressed.Image.Save(saveFileDialog.FileName); 
            //}
            #endregion

            #region .NET 6中
            // 如果用户选择了文件保存路径，则保存图片
            if (saveFileDialog.FileName != "")
            {
                // 将图片转换为 32 位 ARGB 格式
                Bitmap bitmap = new Bitmap(picCompressed.Image.Width, picCompressed.Image.Height, PixelFormat.Format32bppArgb);
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.DrawImage(picCompressed.Image, new Rectangle(0, 0, picCompressed.Image.Width, picCompressed.Image.Height));
                }

                // 保存图片
                bitmap.Save(saveFileDialog.FileName);
            }
            #endregion
        }
    }
}