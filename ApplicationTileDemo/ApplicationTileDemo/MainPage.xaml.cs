using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ApplicationTileDemo.Resources;

namespace ApplicationTileDemo
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();

            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            ShellTile applicationTile = ShellTile.ActiveTiles.First();
            //ApplicationTile永远是所有已经激活了的磁贴中的第一个对象。

            //判断应用程序磁贴时候已经被pin到开始页面
            if (applicationTile != null)
            {
                int newCount=0;//消息数目,数目为0时，数字0将不会被显示到磁贴中去
                if (textBoxCount.Text != "")
                    newCount = int.Parse(textBoxCount.Text);

                //利用StandardTileData类型的数据来更新ApplicationTile
                //将用户输入的内容分别赋值给StandardTileData对象
                StandardTileData updateData = new StandardTileData
                {
                    Title=textBoxTitle.Text,
                    Count=newCount,
                    BackgroundImage=new Uri(textBoxBackgroundImage.Text,UriKind.RelativeOrAbsolute),
                    BackTitle=textBoxBackTitle.Text,
                    BackContent=textBoxBackContent.Text,
                    BackBackgroundImage=new Uri(textBoxBackBackgroundImage.Text,UriKind.RelativeOrAbsolute)
                };
                //调用磁贴对象的函数，传入StandardTileData的对象来更新应用程序磁贴
                applicationTile.Update(updateData);
                MessageBox.Show("已经更新ApplicationTile");
            }
        }

        // 用于生成本地化 ApplicationBar 的示例代码
        //private void BuildLocalizedApplicationBar()
        //{
        //    // 将页面的 ApplicationBar 设置为 ApplicationBar 的新实例。
        //    ApplicationBar = new ApplicationBar();

        //    // 创建新按钮并将文本值设置为 AppResources 中的本地化字符串。
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // 使用 AppResources 中的本地化字符串创建新菜单项。
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}