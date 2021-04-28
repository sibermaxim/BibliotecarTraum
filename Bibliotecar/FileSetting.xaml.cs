using System.Windows.Forms;

namespace Bibliotecar
{
    /// <summary>
    /// Interaction logic for FileSetting.xaml
    /// </summary>
    public partial class FileSetting
    {
        private readonly string _initDirFile;
        private string _getFileName;

        public FileSetting()
        {
            InitializeComponent();
        }   

        /*******************************************************************
        * Функция:         FileSetting
        * назначение:      Инициализация диалога
        * 
        * ********************************************************************/
        public FileSetting(string initFileDir)
        {
            InitializeComponent();

            _initDirFile = initFileDir;
        }

        /*******************************************************************
        * Функция:         SetFilename
        * назначение:      Вызов диалога выбора файла данных
        * 
        * ********************************************************************/
        private void SetFilename(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenFileDialog openFilenameDialog = new OpenFileDialog
                                                    {
                                                        InitialDirectory = _initDirFile,
                                                        Filter = Properties.Resources.FileNameSettingIndex
                                                    };

            if (System.Windows.Forms.DialogResult.OK == openFilenameDialog.ShowDialog())
            {
                strNameFileData.Text = openFilenameDialog.FileName;
                _getFileName = strNameFileData.Text;
            }

        }

        /*******************************************************************
        * Функция:         BtOkClick
        * назначение:      Применение выбранных установок
        * 
        * ********************************************************************/
        private void BtOkClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Properties.Settings.Default.strFiledataName = _getFileName;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Upgrade();
            this.DialogResult = true;
            bool h = (bool) this.DialogResult;
            this.Close();

        }
    }
}
