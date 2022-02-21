using System;
using System.Collections.Generic;
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

namespace Lab17Wpf
{
    /// <summary>
    /// Логика взаимодействия для ColorPicker.xaml
    /// </summary>
    public partial class Indicator : UserControl
    {
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register(
                "Color",
                typeof(Color),
                typeof(Indicator),
                new FrameworkPropertyMetadata(
                    Colors.Black,
                    new PropertyChangedCallback(OnColorChanged)));
        public static DependencyProperty RedProperty =
            DependencyProperty.Register(
                "Red",
                typeof(byte),
                typeof(Indicator),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnColorRGBChanged)));
        public static readonly DependencyProperty GreenProperty =
           DependencyProperty.Register(
               "Green",
               typeof(byte),
               typeof(Indicator),
               new FrameworkPropertyMetadata(
                   new PropertyChangedCallback(OnColorRGBChanged)));
        public static readonly DependencyProperty BlueProperty =
           DependencyProperty.Register(
               "Blue",
               typeof(byte),
               typeof(Indicator),
               new FrameworkPropertyMetadata(
                   new PropertyChangedCallback(OnColorRGBChanged)));

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }
        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }
        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }

        private static void OnColorRGBChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Indicator indicator = (Indicator)d;
            Color color = indicator.Color;
            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;
            indicator.Color = color;
        }

        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            Indicator indicator = (Indicator)d;
            indicator.Red = newColor.R;
            indicator.Green = newColor.G;
            indicator.Blue = newColor.B;
        }
        public static readonly RoutedEvent ColorChangedEvent =
            EventManager.RegisterRoutedEvent(
                "ColorChanged",
                RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<Color>),
                typeof(ColorPicker));
        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }

        public Indicator()
        {
            InitializeComponent();
        }
    }
}
