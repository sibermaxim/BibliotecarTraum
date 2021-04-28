using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using Bibliotecar.TableBook.Author;
using Bibliotecar.TableBook.Book;
using Bibliotecar.TableBook.BookAnons;
using Bibliotecar.TableBook.BookTags;
using Bibliotecar.TableBook.Series;
using SevenZip;
using fb = System.Windows.Forms;
using RadioButton = System.Windows.Controls.RadioButton;
using TreeNode = Bibliotecar.TagsTitle.TreeNode;
using TreeView = System.Windows.Controls.TreeView;

namespace Bibliotecar
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    /// 
    
    public partial class MainWindow
    {
        //текущие настройки
        private static string _currentdirApplication;
        private string _strFolderLib;

        //Вкладка авторы
        private string _strFindCondishion = "А";
        private DataAuthor _pIAutor;

        //Вкладка жанры
        private TreeView _treeviews;

        private static Splash _pWindSplash;
            
        //классы таблиц
        private ListDataAuthor _pTableAuthor;
        private ListDataBook _pTableBook;
        private ListDataBookAnons _pTableBookAnons;
        private ListDataBookTags _pTableBookTags;
        private ListDataSeries _pTableSeries;

        delegate void SetNoArgsDelegate();
        delegate void SetProgressDelegate(ProgressEventArgs args);
        delegate void SetInfoDelegate(FileInfoEventArgs args);

        /*******************************************************************
        * Функция:         InitDataBook
        * назначение:      Визуальное отображение инициализации
        * 
        * ********************************************************************/
        private void InitDataBook()
        {
            string tmpFolder;

            _pWindSplash = new Splash();

            _pWindSplash.Show();
            _pWindSplash.titleWrk.Content = "Распаковка файлов";
            //using (var extr = new SevenZipExtractor(Properties.Settings.Default.strFiledataName))
            //    _pWindSplash.pb_Extract2.Maximum = extr.ArchiveFileData.Count;

             //Extract();

            tmpFolder = _currentdirApplication + "\\db\\";
            //серии книг
            _pWindSplash.pb_Extract2.IsIndeterminate = true;
            _pWindSplash.titleWrk.Content = "Распаковка серии книг";
            System.Windows.Forms.Application.DoEvents();
            _pTableSeries = new ListDataSeries(tmpFolder, Properties.Settings.Default.NameSeries);
            //анонс книг
            _pWindSplash.pb_Extract2.IsIndeterminate = true;
            _pWindSplash.titleWrk.Content = "Распаковка аннотаций книг";
            System.Windows.Forms.Application.DoEvents();
            _pTableBookAnons = new ListDataBookAnons(tmpFolder, Properties.Settings.Default.ameBookanno);
             //список книг
            _pWindSplash.titleWrk.Content = "Распаковка названий книг";
            System.Windows.Forms.Application.DoEvents();
            _pTableBook = new ListDataBook(tmpFolder, Properties.Settings.Default.NameBook);
             //список авторов
            _pWindSplash.titleWrk.Content = "Распаковка авторов книг";
            System.Windows.Forms.Application.DoEvents();
            _pTableAuthor = new ListDataAuthor(tmpFolder, Properties.Settings.Default.NameAuthor);

            var queruAutorTmp =   from autorName in _pTableAuthor.DataAuthorList
                                  where autorName.Name.Substring(0, 1).Contains(_strFindCondishion) 
                                  select (autorName);

             listBox.ItemsSource = queruAutorTmp;                               //указываем источник данных  
             listBox.SelectedValue = listBox.Items[0];                          //выделяем первый элемент коллекции
             //спиок жанров
            _pWindSplash.titleWrk.Content = "Распаковка жанров книг";
            System.Windows.Forms.Application.DoEvents();
            _pTableBookTags = new ListDataBookTags(tmpFolder, Properties.Settings.Default.nameBooktags);
             
            _pWindSplash.Close();
        }

        private void Extract()
        {
            SevenZipBase.SetLibraryPath(@"c:\Program Files\7-Zip\7z.dll");
            string fileName = "";
            string directory = "";
            Dispatcher.Invoke(new SetNoArgsDelegate(() =>
            {
                fileName = Properties.Settings.Default.strFiledataName;
                directory = _currentdirApplication;
            }));
            using (var extr = new SevenZipExtractor(fileName))
            {
                extr.Extracting += ExtrExtracting;
                extr.FileExtractionStarted += ExtrFileExtractionStarted;
                extr.ExtractionFinished += ExtrExtractionFinished;
                extr.ExtractArchive(directory);
            }
        }

        void ExtrExtractionFinished(object sender, EventArgs e)
        {
            Dispatcher.Invoke(new SetNoArgsDelegate(() =>
            {
                _pWindSplash.pb_Extract1.Value = 0;
                _pWindSplash.pb_Extract2.Value = 0;
            }));
        }

        void ExtrFileExtractionStarted(object sender, FileInfoEventArgs e)
        {
            Dispatcher.Invoke(new SetInfoDelegate(args =>
            {
                System.Windows.Forms.Application.DoEvents();
                _pWindSplash.pb_Extract2.Value += 1;
            }), e);
        }

        void ExtrExtracting(object sender, ProgressEventArgs e)
        {
            Dispatcher.Invoke(new SetProgressDelegate(args =>
            {
               System.Windows.Forms.Application.DoEvents();
               _pWindSplash.pb_Extract1.Value += args.PercentDelta;

            }), e);
        }
        
        /*******************************************************************
        * Функция:         MainWindow
        * назначение:      Инициализация приложения
        * 
        * ********************************************************************/
        public MainWindow()
        {
            InitializeComponent();

            _currentdirApplication = Directory.GetCurrentDirectory();
            _strFolderLib = Properties.Settings.Default.strFolderLib;

            if (false == File.Exists(Properties.Settings.Default.strFiledataName))
                return;

//            autorListBook.SelectedCellsChanged += AutorListBookSelectionChanged;
            
            InitDataBook();

        }

        /**********************************************************
        *  имя процедуры:  FolderNmameLibClick
        *  назначение:     задание файла библиотеки
        *  входные данные: 
        *  выходные данные:
        * ********************************************************/
        private void FolderNmameLibClick(object sender, RoutedEventArgs e)
        {
            FileSetting pWindowFileSet = new FileSetting(_currentdirApplication);

            if(true == pWindowFileSet.ShowDialog())
            {
            }
        }

        /**********************************************************
        *  имя процедуры:  ListBoxSelectionChanged
        *  назначение:     список книг на вкладке "Авторы"
        *  входные данные: 
        *  выходные данные:
        * ********************************************************/
        private void ListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i;
            i = listBox.SelectedIndex;

            //Смена источника
            if (0 > i)
                return;

            _pIAutor = (DataAuthor) e.AddedItems[0];

            var queryBook = from DataBook dataBook in _pTableBook.DataBookList
                            where dataBook.IdAuthor == _pIAutor.Id
                            join seriesBook in _pTableSeries.DataSeriesList
                            on dataBook.Series equals seriesBook.Id
                            select new
                            {
                                ID = dataBook.Id,
                                dataBook.NameBook,
                                dataBook.Year,
                                dataBook.Number,
                                seriesBook.Series
                           };
            try
            {
                if (0 < queryBook.Count())
                {
                    autorListBook.ItemsSource = queryBook;
                    autorListBook.SelectedIndex = 0;
                }
                else
                    autorListBook.ItemsSource = null;
                
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }

        private void TitleTagsBookSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            
            _treeviews = (TreeView)sender;
            TreeNode selectedTvi = (TreeNode)_treeviews.SelectedItem;

            if (null == selectedTvi.FindCondition)
                return;

            var queruBookDataTmp = (from prod in _pTableAuthor.DataAuthorList
                                    join category in _pTableBook.DataBookList on prod.Id equals category.IdAuthor
                                    join bookTags in _pTableBookTags.DataBookTags
                                    on category.Id equals bookTags.Id
                                    where bookTags.Name == selectedTvi.FindCondition
                                    select new
                                    {
                                        category.Id, 
                                        category.NameBook,
                                        category.IdAuthor,
                                        category.Lang,
                                        category.Series,
                                        category.Year,
                                        category.Transl,
                                        category.Path,
                                        category.Fname,
                                        category.Size,
                                        category.Added,
                                        category.Crc32,
                                        author = prod.Name
                                    });

            ListCollectionView collection = new ListCollectionView(queruBookDataTmp.ToList());
            collection.GroupDescriptions.Add(new PropertyGroupDescription("author"));
            GridBookTag.ItemsSource = collection;
        }

        /**********************************************************
        *  имя процедуры:  AutorListBookMouseDoubleClick
        *  назначение:     Запуск книги
        *  входные данные: 
        *  выходные данные:
        * ********************************************************/
        private void AutorListBookMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DataBook pI = (DataBook) autorListBook.SelectedValue;
            Process.Start(_currentdirApplication + @"\\AlReader2\\AlReader2.exe", 
                          _strFolderLib + "\\" + pI.Path + pI.Fname + ".zip");

        }

        /**********************************************************
        *  имя процедуры:  FolderLibClick
        *  назначение:     задание каталога библиотеки
        *  входные данные: strFiled - строка файла
        *  выходные данные:
        * ********************************************************/
        private void FolderLibClick(object sender, RoutedEventArgs e)
        {
            fb.FolderBrowserDialog nn = new FolderBrowserDialog();

            nn.SelectedPath = _strFolderLib;
            nn.ShowDialog();
            _strFolderLib = nn.SelectedPath;
            Properties.Settings.Default.strFolderLib = _strFolderLib;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Upgrade();
        }

        /**********************************************************
        *  имя процедуры:  GridBookTag_SelectionChanged
        *  назначение:     анонс для выбранной книги по списку жанров
        *  входные данные: 
        *  выходные данные:
        * ********************************************************/
        private void GridBookTag_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int i = GridBookTag.SelectedIndex, indexFind;
            string tmp;

            TreeNode selectedTvi = (TreeNode)_treeviews.SelectedItem;

            if (null == selectedTvi.FindCondition)
                return;

            var queruBookDataTmp = (from prod in _pTableAuthor.DataAuthorList
                                    join category in _pTableBook.DataBookList on prod.Id equals category.IdAuthor
                                    join bookTags in _pTableBookTags.DataBookTags
                                    on category.Id equals bookTags.Id
                                    where bookTags.Name == selectedTvi.FindCondition
                                    select new
                                    {
                                        category.Id,
                                        category.NameBook,
                                        category.IdAuthor,
                                        category.Lang,
                                        category.Series,
                                        category.Year,
                                        category.Transl,
                                        category.Path,
                                        category.Fname,
                                        category.Size,
                                        category.Added,
                                        category.Crc32,
                                        author = prod.Name
                                    });

            var colum = queruBookDataTmp.ToArray();
            var ttt = colum[i];
            int findCondishn = (int) ttt.Id;
            
            IEnumerable<DataBookAnons> queryBookAnon = from DataBookAnons dataBook in _pTableBookAnons.DataBookAnonsList
                                                       where dataBook.Id == findCondishn
                                                       select dataBook;

            //описание найдено
            if (0 < queryBookAnon.Count())
            {
                foreach (DataBookAnons pA in queryBookAnon)
                {
                    tmp = pA.BookAnons;
                    do
                    {
                        indexFind = tmp.IndexOf("\\n");
                        if (indexFind > 0)
                            tmp = tmp.Substring(0, indexFind - 1) + '\n' + tmp.Substring(indexFind + 2);
                        else
                        {
                            if (indexFind == 0)
                                tmp = '\n' + tmp.Substring(indexFind + 2);
                        }
                    } while (indexFind >= 0);
                    txtAnonsTag.Text = tmp;
//                    titleFolderAuthor.Content = "Папка - " + pI.Path;
//                    titleFileAuthor.Content = "Файл - " + pI.Fname;
                }
            }
            else
                txtAnonsTag.Text = "Нет данных";
        }

        /**********************************************************
        *  имя процедуры:  txtAnons_MouseRightButtonDown
        *  назначение:     анонс для выбранной книги
        *  входные данные: 
        *  выходные данные:
        * ********************************************************/
        private void AutorListBookSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tmp;
            int indexFind;

           if (0 == autorListBook.SelectedItems.Count)
                 return;

           var queryBook = from DataBook dataBook in _pTableBook.DataBookList
                            where dataBook.IdAuthor == _pIAutor.Id
                            join seriesBook in _pTableSeries.DataSeriesList
                            on dataBook.Series equals seriesBook.Id
                            select new
                            {
                                ID = dataBook.Id,
                                dataBook.NameBook,
                                dataBook.Year,
                                dataBook.Path,
                                dataBook.Fname,
                                dataBook.Number,
                                seriesBook.Series
                            };
            var tmpListDataBook = queryBook.ToArray();
            var tmpDataBook = tmpListDataBook[autorListBook.SelectedIndex];
            indexFind = (int) tmpDataBook.ID;

            IEnumerable<DataBookAnons> queryBookAnon = from DataBookAnons dataBook in _pTableBookAnons.DataBookAnonsList
                                                       where dataBook.Id == indexFind
                                                       select dataBook;

            //описание найдено
            if (0 < queryBookAnon.Count())
            {
                foreach (DataBookAnons pA in queryBookAnon)
                {
                    tmp = pA.BookAnons;
                    do
                    {
                        indexFind = tmp.IndexOf("\\n");
                        if (indexFind > 0)
                            tmp = tmp.Substring(0, indexFind - 1) + '\n' + tmp.Substring(indexFind + 2);
                        else
                        {
                            if (indexFind == 0)
                                tmp = '\n' + tmp.Substring(indexFind + 2);
                        }
                    } while (indexFind >= 0);
                    txtAnons.Text = tmp;
                    titleFolderAuthor.Content = "Папка - " + tmpDataBook.Path;
                    titleFileAuthor.Content = "Файл - " + tmpDataBook.Fname;
                }
            }
            else
                txtAnons.Text = "Нет данных";
        }

        /**********************************************************
        *  имя процедуры:  StartFind
        *  назначение:     запуск поиска книги по условию
        *  входные данные: нет
        *  выходные данные:
        * ********************************************************/
        private void StartFind(object sender, RoutedEventArgs e)
        {
            var queruBookDataTmp = (from bookTags in _pTableBookTags.DataBookTags
                                    join category in _pTableBook.DataBookList on bookTags.Id
                                    equals category.Id
                                    where category.NameBook.Contains(FindCriterion.Text)
                                    join prod in _pTableAuthor.DataAuthorList
                                    on category.IdAuthor equals prod.Id
                                    select new
                                    {
                                        bookName = category.NameBook,
                                        author = prod.Name,
                                        nameTag = bookTags.Name
                                    });
            GridFind.ItemsSource = queruBookDataTmp;
        }

        /**********************************************************
        *  имя процедуры:  PbtBChecked
        *  назначение:     Выбор стартовой буквы автора
        *  входные данные: 
        *  выходные данные:
        * ********************************************************/
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton tmpbtn = (RadioButton) sender;

            _strFindCondishion = (string)tmpbtn.Content;
            var queruAutorTmp = from autorName in _pTableAuthor.DataAuthorList
                                where autorName.Name.Substring(0, 1).Contains(_strFindCondishion)
                                select (autorName);

            listBox.ItemsSource = queruAutorTmp;                               //указываем источник данных  
            listBox.SelectedValue = listBox.Items[0];                          //выделяем первый элемент коллекции
        }

        /**********************************************************
        *  имя процедуры:  MenuItem_Click
        *  назначение:     Показ диалога о программе
        *  входные данные: 
        *  выходные данные:
        * ********************************************************/
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            About pwAbout = new About();

            pwAbout.ShowDialog();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            String strCond;

            var queruAutor = from autorName in _pTableAuthor.DataAuthorList
                                where autorName.Name.Substring(0, 1).Contains(_strFindCondishion)
                                select (autorName);

            var listAutorAll = queruAutor.ToList();

            strCond = strFindCondition.Text;

            var queruAutorFindCondit = from autorName in _pTableAuthor.DataAuthorList
                                       where autorName.Name.StartsWith(strCond)
                                       select (autorName);

            var listAutorCondit = queruAutorFindCondit.ToList();
            if (0 < listAutorCondit.Count)
            {
                listBox.SelectedIndex = listAutorAll.IndexOf(listAutorCondit[0]);
                listBox.ScrollIntoView(listBox.SelectedItem);
            }
        }

        private void listBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }
    }
}
