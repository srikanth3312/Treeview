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
                destinationTreeView.Items.Add(item);
            }
        }

        // Event handler for Transfer button click
        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            TransferItem();
        }

        // Transfer the selected item from sourceTreeView to destinationTreeView
        private void TransferItem()
        {
            if (draggedItem != null)
            {
                // Remove the selected item from sourceTreeView
                sourceTreeView.Items.Remove(draggedItem);

                // Add the selected item to destinationTreeView
                destinationTreeView.Items.Add(draggedItem);

                draggedItem = null;
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
                // Remove the selected item from the original parent
                ((TreeViewItem)draggedItem.Parent).Items.Remove(draggedItem);

                // Add the selected item to the destinationTreeView
                destinationTreeView.Items.Add(draggedItem);
            }
        }
    }
}