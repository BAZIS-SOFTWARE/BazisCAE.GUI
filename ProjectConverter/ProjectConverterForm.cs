using System.IO;

namespace ProjectConverter
{
    public partial class ProjectConverterForm : Form
    {
        public ProjectConverterForm()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var path = GetPath();
            txbPath.Text = path;
        }

        private void btnConverter_Click(object sender, EventArgs e) 
        {
            var path = txbPath.Text; 
            if (path == string.Empty) 
            {
                txbStatus.Text = "Не указан путь к проекту!";
                return;
            }
                
            var converter = new Converter();
            converter.ReadProject(path);
        }
        private string GetPath()
        {
            using (var fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Project Files|*.bpf;*.bpf2";
                fileDialog.Title = "Выберите файл проекта";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                    return fileDialog.FileName;
            }
            return string.Empty;
        }
    }
}
