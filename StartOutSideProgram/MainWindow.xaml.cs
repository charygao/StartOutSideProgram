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
            for (int i = 0; i < Myset.Default.ApplicationName.Count; i++)
            {
                if (Myset.Default.ApplicationName[i].StartsWith("./"))
                {
                    outsideAppFullPath = Myset.Default.ApplicationName[i].Replace("./", System.Threading.Thread.GetDomain().BaseDirectory);
                }
                else
                {
                    outsideAppFullPath = Myset.Default.ApplicationName[i];
                }
                try
                {
                    if (Myset.Default.ApplicationName.Count <= i)
                    {
                        Process.Start(outsideAppFullPath, Myset.Default.Parameter[i]);
                    }
                    else
                    {
                        Process.Start(outsideAppFullPath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\noutsideAppFullPath = " + outsideAppFullPath + "\nParameter=" + Myset.Default.Parameter);
                }
            }
            //InitializeComponent();
            this.Close();
        }
    }
}
