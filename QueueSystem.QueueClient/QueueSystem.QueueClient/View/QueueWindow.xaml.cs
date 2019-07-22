using QueueSystem.QueueClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QueueSystem.QueueClient.View
{
    /// <summary>
    /// Interaction logic for QueueWindow.xaml
    /// </summary>
    public partial class QueueWindow : Window
    {

        private QueueVM VM = new QueueVM();

        public QueueWindow()
        {
            InitializeComponent();

            this.Closing += QueueWindow_Closing;
            this.Loaded += QueueWindow_Loaded;
        }

        private void QueueWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = -additionalInfoTextBlock.ActualWidth;
            doubleAnimation.To = canMain.ActualWidth;
            doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            doubleAnimation.Duration = new Duration(TimeSpan.Parse("0:0:13"));
            additionalInfoTextBlock.BeginAnimation(Canvas.RightProperty, doubleAnimation);
        }

            private void QueueWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
            {
                VM.OnWindowClosing();
            }

            private void FullscreenBtn_Click(object sender, RoutedEventArgs e)
            {
                bool isBtnChecked = (sender as MenuItem).IsChecked;
            
                if (isBtnChecked)
                {
                    WindowState = WindowState.Maximized;
                    WindowStyle = WindowStyle.None;
                    
                }
                else
                {
                    WindowState = WindowState.Normal;
                    WindowStyle = WindowStyle.SingleBorderWindow;

                }
                toolbarMenu.IsOverflowOpen = false;
                

            }

            private void ConnectMenuItem_Click(object sender, RoutedEventArgs e)
            {
                toolbarMenu.IsOverflowOpen = false;

                var btn = sender as MenuItem;

            }

            private void TextBlockFontSizeControl_TargetUpdated(object sender, DataTransferEventArgs e)
            {
                var textBlock = sender as TextBlock;
                if (textBlock.Text.Length > 5)
                {
                    (e.TargetObject as TextBlock).FontSize = 150;
                }
                else
                {
                    (e.TargetObject as TextBlock).FontSize = 200;
                }
            }
        }
    }
