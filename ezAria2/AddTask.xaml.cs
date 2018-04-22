﻿using Arthas.Controls.Metro;
using System;
using System.Threading.Tasks;
using System.Windows;


namespace ezAria2
{
    /// <summary>
    /// AddTask.xaml 的交互逻辑
    /// </summary>
    public partial class AddTask : MetroWindow
    {
        public AddTask()
        {
            InitializeComponent();
        }

        private void MetroTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if(UriBox.Text== "请输入链接地址")
            {
                UriBox.Text = "";
            }
        }

        private void MetroButton_Click_Add(object sender, RoutedEventArgs e)
        {
            Add();
            Close();
        }

        private void MetroButton_Click_Cancle(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private async void Add()
        {
            await Aria2Methords.AddUri(UriBox.Text);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.Text))
            {
                UriBox.Text = (string)iData.GetData(DataFormats.Text)+Environment.NewLine;
                UriBox.Select(UriBox.Text.Length, 0);
            }
        }
    }
}
