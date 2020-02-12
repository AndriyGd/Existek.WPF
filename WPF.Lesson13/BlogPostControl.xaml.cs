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

namespace WPF.Lesson13
{
    /// <summary>
    /// Interaction logic for BlogPostControl.xaml
    /// </summary>
    public partial class BlogPostControl : UserControl
    {
        public string PostTitle
        {
            get => (string) GetValue(PostTitleProperty);
            set => SetValue(PostTitleProperty, value);
        }
        public string PostDescription
        {
            get => (string) GetValue(PostDescriptionProperty);
            set => SetValue(PostDescriptionProperty, value);
        }

        public static readonly DependencyProperty PostTitleProperty = DependencyProperty.Register(nameof(PostTitle),
            typeof(string), typeof(BlogPostControl),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnPostTitleChanged));

        public static readonly DependencyProperty PostDescriptionProperty = DependencyProperty.Register(
            nameof(PostDescription), typeof(string), typeof(BlogPostControl),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnPostDescriptionChanged));

        private static void OnPostDescriptionChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is BlogPostControl post)
            {
                post.TxtbPostDescription.Text = e.NewValue?.ToString();
            }
        }

        private static void OnPostTitleChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is BlogPostControl post)
            {
                post.TxtbPostTitle.Text = e.NewValue?.ToString();
            }
        }

        public BlogPostControl()
        {
            InitializeComponent();
        }
    }
}
