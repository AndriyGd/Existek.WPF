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
using System.Collections.ObjectModel;

namespace WPF.Lesson13
{
    using Model;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Post> Posts { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Posts = new ObservableCollection<Post>();
            LoadData();

            DataContext = this;
        }

        private void LoadData()
        {
            Posts.Add(new Post{Description = "It looks like a bug in the Expander template:\r\n\r\nhttp://social.msdn.microsoft.com/Forums/en-US/wpf/thread/e51ad4f5-95d3-4c3e-be87-7917e4d81fa0/\r\n\r\nHere\'s a full workaround (ugly, I know):", Title = "Disable TabStop on Expander" });
            Posts.Add(new Post{Description = "Hi,\r\nI\'m using Telerik controls with version 2013.2.724.40, and VS 2010.\r\nIn the following code example, I\'d like to use tab to navigate only between the 3 TextBoxes. IsTabStop is set to false, but the tab still stops at the RadExpander, is it an expected behavior?", Title = "IsTabStop doesn't work as expected?" });
            Posts.Add(new Post{Description = "This article will demonstrate how to create a ControlTemplate for the WPF Expander control to customize its appearance and behavior. First, a simplified version of the default template is explained in detail.", Title = "Customizing WPF Expander with ControlTemplate" });
            Posts.Add(new Post{Description = "Styling gurus, I need help coming up with an Expander style that looks like the one found in Visual Studio's code editor. So far, I have come up with this", Title = "WPF Expander button style with + and -" });
            Posts.Add(new Post{Description = "The bounding rectangle of all the monitors is the virtual screen. The desktop covers the virtual screen instead of a single monitor. The following illustration shows a possible arrangement of three monitors.", Title = "The Virtual Screen" });
            Posts.Add(new Post{Description = "This is a list with short descriptions of the top-of-the-line features of the Telerik RadDateTimePicker control:\r\n\r\nDatePicker and TimePicker controls: DatePicker and TimePicker are both incorporated in the RadDateTimePicker control. You can choose to use either one or both.", Title = "Telerik RadDateTimePicker!" });
        }
    }
}
