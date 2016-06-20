using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace StartOutSideProgram
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            string outsideAppFullPath;

            if (Myset.Default.ApplicationName.StartsWith("./"))
            {
                outsideAppFullPath=Myset.Default.ApplicationName.Replace("./", System.Threading.Thread.GetDomain().BaseDirectory);
            }
            else
            {
                outsideAppFullPath = Myset.Default.ApplicationName;
            }
            try
            {
                Process.Start(outsideAppFullPath, Myset.Default.Parameter);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\noutsideAppFullPath = " + outsideAppFullPath + "\nParameter=" + Myset.Default.Parameter);
            }
            InitializeComponent();
            this.Close();
        }
    }
}
