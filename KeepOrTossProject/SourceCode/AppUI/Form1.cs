
using BusinessLogic;
using System.Runtime.CompilerServices;

namespace AppUI
{
    public partial class MainForm : Form
    {
        KeepOrTossLogic logic;
        const int MinimumWidth = 900;
        const int MinimumHeight = 750;
        const int YOffsetToX = 40;
        Image? currentImage;


        int i = 0;

        public MainForm(KeepOrTossLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            currentImage = null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            i = 0;
            logic.inputDirectory = directoryTextBox.Text;
            if (logic.inputDirectory == "" || logic.VerifyDirectory(logic.inputDirectory) == false)
            {
                MessageBox.Show("Invalid directory, please input existing directory path");
                return;
            }
            logic.allImageFiles = logic.GetAllImageFiles(logic.inputDirectory);

            logic.deletionDirectory = logic.CreateDeletionDirectory("ToToss", logic.inputDirectory);

            //display first image
            if (logic.allImageFiles != null && logic.allImageFiles.Count > 0)
            {
                currentImage = DisplayImage(logic.allImageFiles[i], imagePictureBox, this);

            }
            else
            {
                MessageBox.Show("No image files were found in the provided directory");
                return;
            }

            //transition ui to Image display and keep/toss buttons
            SwapUI();


        }


        private void keepButton_Click(object sender, EventArgs e)
        {
            currentImage.Dispose();
            i++;
            if (i < logic.allImageFiles.Count)
            {
                currentImage = DisplayImage(logic.allImageFiles[i], imagePictureBox, this);

            }
            else
            {
                //reset ui to first page
                MessageBox.Show($"Completed! Check the \"ToToss\" folder inside the path {logic.inputDirectory} Returning to main menu.");
                SwapUI();
            }
        }
        private void tossButton_Click(object sender, EventArgs e)
        {
            //TODO: Toss bug with accessing an image that is already being processed by another process
            currentImage.Dispose();
            logic.MoveFileIntoDirectory(logic.allImageFiles[i], logic.deletionDirectory);
            i++;
            if (i < logic.allImageFiles.Count)
            {
                currentImage = DisplayImage(logic.allImageFiles[i], imagePictureBox, this);

            }
            else
            {
                MessageBox.Show($"Completed! Check the \"ToToss\" folder {logic.inputDirectory} Returning to main menu.");
                SwapUI();
                keepButton.Focus();
                tossButton.Focus();
            }


        }

        private void SwapUI()
        {

            insertDirectoryLabel.Visible = !insertDirectoryLabel.Visible;
            directoryTextBox.Visible = !directoryTextBox.Visible;
            directoryTextBox.Text = "";
            okButton.Visible = !okButton.Visible;

            keepButton.Visible = !keepButton.Visible;
            tossButton.Visible = !tossButton.Visible;
            imagePictureBox.Visible = !imagePictureBox.Visible;

        }

        private Size UpdateProportions(Size size, int currentDimension, bool aroundWidth)
        {
            if (aroundWidth)
            {
                return new Size(currentDimension, (size.Height * currentDimension) / size.Width);
            }
            return new Size((size.Width * currentDimension) / size.Height, currentDimension);

        }

        private Point CenterImagePoint(Size formSize, Size imageSize)
        {
            int xOffSet = 0;
            int yOffSet = 0;

            Point centerPoint = new Point(formSize.Width / 2, formSize.Height / 2);

            xOffSet = imageSize.Width / 2;
            yOffSet = imageSize.Height / 2;

            return new Point(centerPoint.X - xOffSet, centerPoint.Y - yOffSet);
        }

        private Image DisplayImage(string file, PictureBox picBox, Form form)
        {
            Image image = Image.FromFile(file);
            Size imageSize = image.Size;
            //resize image to fit within form 
            if (imageSize.Width > imageSize.Height)
            {
                imageSize = UpdateProportions(imageSize, MinimumWidth, true);
            }
            else
            {
                imageSize = UpdateProportions(imageSize, MinimumHeight, false);
            }

            picBox.Size = imageSize;
            //center image within form
            Point centerPoint = CenterImagePoint(new Size(form.Width, form.Height), picBox.Size);
            centerPoint = new Point(centerPoint.X, centerPoint.Y - YOffsetToX);
            picBox.Location = centerPoint;
            imagePictureBox.Image = image;

            return image;
        }


    }
}