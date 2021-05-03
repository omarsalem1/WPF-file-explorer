using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_lab_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DirectoryInfo current_dir;
        string currdrive;
        public MainWindow()
        {
            InitializeComponent();
           
            Loaded += MainWindow_Loaded;
            Driveslistbox.SelectionChanged += Driveslistbox_SelectionChanged;
            contentlistbox.SelectionChanged += Contentlistbox_SelectionChanged;
           
        }

        private void Contentlistbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          history.Text+= @"\" + contentlistbox.SelectedItem;
            current_dir = new DirectoryInfo(history.Text);
            
            history.Items.Add(history.Text);
            DirectoryInfo[] folder = current_dir.GetDirectories();
            FileInfo[] files = current_dir.GetFiles();


            contentlistbox.Items.Clear();


            foreach (DirectoryInfo fol in folder)
            {
                contentlistbox.Items.Add(fol.Name);
            }
            foreach (FileInfo f in files)
            {
                contentlistbox.Items.Add(f.Name);

            }
        }

        private void Driveslistbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
           currdrive = Driveslistbox.SelectedItem.ToString();
            current_dir = new DirectoryInfo(currdrive);
            history.Text = currdrive;
            history.Items.Add(currdrive);
            DirectoryInfo[] folder = current_dir.GetDirectories();
            FileInfo[] files = current_dir.GetFiles();
           

            contentlistbox.Items.Clear();
           

            foreach (DirectoryInfo fol in folder)
            {
                contentlistbox.Items.Add(fol.Name);
            }
            foreach (FileInfo f in files)
            {
               contentlistbox.Items.Add(f.Name);

            }
           

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo DR in drives)
            {
               
                Driveslistbox.Items.Add(DR.Name);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            current_dir = new DirectoryInfo(history.Text);

            history.Items.Add(history.Text);
            DirectoryInfo[] folder = current_dir.GetDirectories();
            FileInfo[] files = current_dir.GetFiles();


            contentlistbox.Items.Clear();


            foreach (DirectoryInfo fol in folder)
            {
                contentlistbox.Items.Add(fol.Name);
            }
            foreach (FileInfo f in files)
            {
                contentlistbox.Items.Add(f.Name);

            }

        }
    }
}
