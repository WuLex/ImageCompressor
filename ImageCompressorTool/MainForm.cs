using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ImageCompressorTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // ����Ĭ��ֵ
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
                MessageBox.Show("��ѡ��Ҫѹ����ͼ���ļ�.");
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
                lblFileSize.Text = $"�ļ���С: {memoryStream.Length / 1024} KB";
            }
        }

        // ��ȡͼƬ������
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
            // ���±�ǩ��ѹ������

            // ��ȡ��������ֵ
            int quality = trackBar.Value;

            // ��ʾѹ������
            lblQuality.Text = $"ѹ������: {quality}%";

            //// ��ȡԭʼͼƬ·��
            //string originalFilePath = txtFilePath.Text;

            //// ���ԭʼͼƬ·��Ϊ�գ��򷵻�
            //if (string.IsNullOrEmpty(originalFilePath))
            //{
            //    return;
            //}

            //// ����ԭʼͼƬ
            //Image originalImage = Image.FromFile(originalFilePath);

            //// ѹ��ԭʼͼƬ
            //Image compressedImage = CompressImage(originalImage, quality);

            //// ��ʾѹ�����ͼƬ
            //picCompressed.Image = compressedImage;

            //// ����ѹ������ļ���С
            //long compressedFileSize = GetImageFileSize(compressedImage);

            //// ��ʾѹ������ļ���С
            //lblFileSize.Text = $"File Size: {GetSizeString(compressedFileSize)}";

            //// �ͷ�ͼƬ��Դ
            //originalImage.Dispose();
            //compressedImage.Dispose();
        }

        // ѹ��ͼƬ
        private Image CompressImage(Image originalImage, int quality)
        {
            // ����ͼƬѹ���������Ĳ���
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            // ʹ��ͼƬѹ��������ѹ��ԭʼͼƬ
            MemoryStream stream = new MemoryStream();
            originalImage.Save(stream, jpegCodec, encoderParams);

            // ���ڴ����д���������ѹ�����ͼƬ
            return Image.FromStream(stream);
        }

        // ��ȡͼƬ�ļ���С
        private long GetImageFileSize(Image image)
        {
            // ��ͼƬ���浽�ڴ�����
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, image.RawFormat);

                // �����ڴ����ĳ���
                return stream.Length;
            }
        }

        // ���ļ���Сת��Ϊ�׶����ַ���
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
                // ��ʾ�����Ĳ˵�
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        /// <summary>
        /// ������һ���µ� Bitmap ���󣬲����� PixelFormat ��������Ϊ PixelFormat.Format32bppArgb��
        /// ������������ʹ�� Graphics ����ԭʼͼƬ���Ƶ��µ� Bitmap �����ϣ�Ȼ���䱣�浽�ļ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ����һ�������ļ��Ի���
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPEG�ļ� (*.jpg)|*.jpg|PNG�ļ� (*.png)|*.png";
            saveFileDialog.Title = "����ͼƬ";
            saveFileDialog.ShowDialog();

            #region .NET Framework��
            //// ����û�ѡ�����ļ�����·�����򱣴�ͼƬ
            //if (saveFileDialog.FileName != "")
            //{
            //    // ����ͼƬ
            //    picCompressed.Image.Save(saveFileDialog.FileName); 
            //}
            #endregion

            #region .NET 6��
            // ����û�ѡ�����ļ�����·�����򱣴�ͼƬ
            if (saveFileDialog.FileName != "")
            {
                // ��ͼƬת��Ϊ 32 λ ARGB ��ʽ
                Bitmap bitmap = new Bitmap(picCompressed.Image.Width, picCompressed.Image.Height, PixelFormat.Format32bppArgb);
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.DrawImage(picCompressed.Image, new Rectangle(0, 0, picCompressed.Image.Width, picCompressed.Image.Height));
                }

                // ����ͼƬ
                bitmap.Save(saveFileDialog.FileName);
            }
            #endregion
        }
    }
}