using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUINotes
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            //这个的作用是：
            //1. 初始化XAML组件
            //2. 隐藏默认的标题栏 3. 用WinUI的TitleBar替换系统标题栏 
            this.InitializeComponent();

            //确保页面被加载
            if (rootFrame.Content == null)
            {
                rootFrame.Navigate(typeof(Views.NotePage));
            }

            //Hide the default title bar.
            ExtendsContentIntoTitleBar = true;
            //Replace system title bar with WinUI TitleBar.
            SetTitleBar(AppTitleBar);

            //上述代码的原理,是通过将窗口内容扩展到标题栏区域，并使用自定义的XAML元素（AppTitleBar）
            //来替代默认的系统标题栏，从而实现更灵活的界面设计和自定义功能。


            InitializeComponent();
        }

        private void AppTitleBar_BackRequested(TitleBar sender, object args)
        {
            if(rootFrame.CanGoBack == true)
            {
                rootFrame.GoBack();
            }
        }
    }
}
