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

namespace WPF.Lesson14
{
    using System.Collections.ObjectModel;
    using Model;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Post> Posts { get; set; }
        public ObservableCollection<Post> NewPosts { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Posts = new ObservableCollection<Post>();
            NewPosts = new ObservableCollection<Post>();
            LoadData();

            DataContext = this;
        }

        private void LoadData()
        {
            Posts.Add(new Post { Description = "It looks like a bug in the", Title = "Disable TabStop" });
            Posts.Add(new Post { Description = "Hi, m using Telerik controls with version 2013.2.724.40", Title = "Customizing UWP" });
            Posts.Add(new Post { Description = "This article will demonstrate how.", Title = "Customizing WPF" });

            NewPosts.Add(new Post
            {
                Description = "I wonder if there is anyway to change focus from the current control and move it to other control in",
                Title = "How to move focus in WPF?",
                Visitors = new List<Visitor>
                {
                    new Visitor{Name = "Glopis", Age = 19},
                    new Visitor{Name = "Bolmk", Age = 21},
                    new Visitor{Name = "FotRy", Age = 25},
                }
            });
            NewPosts.Add(new Post
            {
                Description = "Hi all. I have a WPF Window, and I'd like the user to be able to focus on the next element with just pressing Enter, instead of Tab",
                Title = "Programatically set focus",
                Visitors = new List<Visitor>
                {
                    new Visitor{Name = "VLpoE", Age = 18},
                    new Visitor{Name = "CopCo", Age = 22},
                    new Visitor{Name = "XopTY", Age = 24},
                }
            });
            NewPosts.Add(new Post
            {
                Description = "How do I programmatically reorder the tabs in a TabControl? I need to sort the tabs depending on some conditions.",
                Title = "Programmatically change the tab order",
                Visitors = new List<Visitor>
                {
                    new Visitor{Name = "XMon", Age = 20},
                    new Visitor{Name = "ZOpiUY", Age = 26},
                    new Visitor{Name = "ADpOu", Age = 27},
                    new Visitor{Name = "QWrPol", Age = 28},
                }
            });
        }


        private void LoadDataOld()
        {
            Posts.Add(new Post { Description = "It looks like a bug in the Expander template:\r\n\r\nhttp://social.msdn.microsoft.com/Forums/en-US/wpf/thread/e51ad4f5-95d3-4c3e-be87-7917e4d81fa0/\r\n\r\nHere\'s a full workaround (ugly, I know):", Title = "Disable TabStop on Expander" });
            Posts.Add(new Post { Description = "Hi,\r\nI\'m using Telerik controls with version 2013.2.724.40, and VS 2010.\r\nIn the following code example, I\'d like to use tab to navigate only between the 3 TextBoxes. IsTabStop is set to false, but the tab still stops at the RadExpander, is it an expected behavior?", Title = "IsTabStop doesn't work as expected?" });
            Posts.Add(new Post { Description = "This article will demonstrate how to create a ControlTemplate for the WPF Expander control to customize its appearance and behavior. First, a simplified version of the default template is explained in detail.", Title = "Customizing WPF Expander with ControlTemplate" });
            Posts.Add(new Post { Description = "Styling gurus, I need help coming up with an Expander style that looks like the one found in Visual Studio's code editor. So far, I have come up with this", Title = "WPF Expander button style with + and -" });
            Posts.Add(new Post { Description = "The bounding rectangle of all the monitors is the virtual screen. The desktop covers the virtual screen instead of a single monitor. The following illustration shows a possible arrangement of three monitors.", Title = "The Virtual Screen" });
            Posts.Add(new Post { Description = "This is a list with short descriptions of the top-of-the-line features of the Telerik RadDateTimePicker control:\r\n\r\nDatePicker and TimePicker controls: DatePicker and TimePicker are both incorporated in the RadDateTimePicker control. You can choose to use either one or both.", Title = "Telerik RadDateTimePicker!" });
        }
    }
}
