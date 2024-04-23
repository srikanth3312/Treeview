using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TreeViewTransfer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TreeViewItem draggedItem;

        public MainWindow()
        {
            InitializeComponent();
            InitializeSourceTreeView();
            InitializeDestinationTreeView();
        }

        // Initialize the Source TreeView
        private void InitializeSourceTreeView()
        {
            // Add items to the source TreeView
            for (int i = 0; i < 5; i++)
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = "Item " + i;

                for (int j = 0; j < 3; j++)
                {
                    TreeViewItem subItem = new TreeViewItem();
                    subItem.Header = "SubItem " + j;
                    item.Items.Add(subItem);
                }

                sourceTreeView.Items.Add(item);
            }
        }

        // Initialize the Destination TreeView
        private void InitializeDestinationTreeView()
        {
            // Add items to the destination TreeView
            for (int i = 5; i < 10; i++)
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = "Item " + i;

                for (int j = 0; j < 3; j++)
                {
                    TreeViewItem subItem = new TreeViewItem();
                    subItem.Header = "SubItem " + j;
                    item.Items.Add(subItem);
                }

                destinationTreeView.Items.Add(item);
            }
        }

        // Event handler for "To Destination" button click
        private void TransferToDestination_Click(object sender, RoutedEventArgs e)
        {
            TransferItem(sourceTreeView, destinationTreeView);
        }

        // Event handler for "To Source" button click
        private void TransferToSource_Click(object sender, RoutedEventArgs e)
        {
            TransferItem(destinationTreeView, sourceTreeView);
        }

        // Transfer selected item from one TreeView to another
        private void TransferItem(TreeView source, TreeView destination)
        {
            if (draggedItem != null)
            {
                var parent = (TreeViewItem)draggedItem.Parent;
                if (parent != null)
                {
                    parent.Items.Remove(draggedItem);
                }
                destination.Items.Add(draggedItem);
            }
        }

        // Dragging from SourceTreeView
        private void SourceTreeView_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.Source is TreeViewItem)
            {
                draggedItem = (TreeViewItem)e.Source;
            }
        }

        // Dragging from DestinationTreeView
        private void DestinationTreeView_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.Source is TreeViewItem)
            {
                draggedItem = (TreeViewItem)e.Source;
            }
        }

        // Drop into SourceTreeView
        private void SourceTreeView_Drop(object sender, DragEventArgs e)
        {
            if (draggedItem != null && e.Source == sourceTreeView)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        // Drop into DestinationTreeView
        private void DestinationTreeView_Drop(object sender, DragEventArgs e)
        {
            if (draggedItem != null && e.Source == destinationTreeView)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        // Save data
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveData(sourceTreeView, "SourceTreeViewData.txt");
            SaveData(destinationTreeView, "DestinationTreeViewData.txt");
            MessageBox.Show("Data has been saved successfully!");
        }

        // Save TreeView data to a file
        private void SaveData(TreeView treeView, string fileName)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
            {
                foreach (TreeViewItem item in treeView.Items)
                {
                    SaveTreeViewItem(file, item);
                }
            }
        }

        // Save TreeViewItem data to a file
        private void SaveTreeViewItem(System.IO.StreamWriter file, TreeViewItem item, int depth = 0)
        {
            for (int i = 0; i < depth; i++)
            {
                file.Write("\t");
            }
            file.WriteLine(item.Header.ToString());
            foreach (TreeViewItem subItem in item.Items)
            {
                SaveTreeViewItem(file, subItem, depth + 1);
            }
        }
    }
    }

