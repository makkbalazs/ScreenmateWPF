using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using WpfAnimatedGif;

namespace Screenmate.Views
{
    /// <summary>
    /// Interaction logic for CanvasWindow.xaml
    /// </summary>
    public partial class CanvasWindow : Window
    {
        private Dispatcher _dispatcher;

        public Dispatcher Dispatcher { get { return _dispatcher; } }

        public CanvasWindow()
        {
            InitializeComponent();
            _dispatcher = Dispatcher.CurrentDispatcher;
        }

        public void moveRon(double x, double y)
        {
            if (x == 0 && y == 0 && !Ron.Tag.Equals(0))
            {
                var image = new BitmapImage(new Uri("/images/RonDown2.png", UriKind.Relative));
                ImageBehavior.SetAnimatedSource(Ron, image);
                Ron.Tag = 0;
            }
            else if (x >= y && -x < y && !Ron.Tag.Equals(1))
            {
                var image = new BitmapImage(new Uri("/images/RonWalkRight.gif", UriKind.Relative));
                ImageBehavior.SetAnimatedSource(Ron, image);
                Ron.Tag = 1;
            }
            else if (x < y && -x <= y && !Ron.Tag.Equals(2))
            {
                var image = new BitmapImage(new Uri("/images/RonWalkDown.gif", UriKind.Relative));
                ImageBehavior.SetAnimatedSource(Ron, image);
                Ron.Tag = 2;
            }
            else if (x <= y && -x > y && !Ron.Tag.Equals(3))
            {
                var image = new BitmapImage(new Uri("/images/RonWalkLeft.gif", UriKind.Relative));
                ImageBehavior.SetAnimatedSource(Ron, image);
                Ron.Tag = 3;
            }
            else if (x > y && -x >= y && !Ron.Tag.Equals(4))
            {
                var image = new BitmapImage(new Uri("/images/RonWalkUp.gif", UriKind.Relative));
                ImageBehavior.SetAnimatedSource(Ron, image);
                Ron.Tag = 4;
            }

            Canvas.SetLeft(Ron, Canvas.GetLeft(Ron) + x);
            Canvas.SetTop(Ron, Canvas.GetTop(Ron) + y);
        }
    }
}
