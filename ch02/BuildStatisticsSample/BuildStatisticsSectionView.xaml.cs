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

namespace Company.BuildStatisticsSample
{
    /// <summary>
    /// Interaction logic for BuildStatisticsSectionView.xaml
    /// </summary>
    public partial class BuildStatisticsSectionView : UserControl
    {
        public BuildStatisticsSectionView()
        {
            InitializeComponent();
            DataContext = this;
        }

        public int RecentlyCompletedBuildCount
        {
            get { return (int)GetValue(RecentlyCompletedBuildCountProperty); }
            set { SetValue(RecentlyCompletedBuildCountProperty, value); }
        }

        public static readonly DependencyProperty RecentlyCompletedBuildCountProperty =
            DependencyProperty.Register("RecentlyCompletedBuildCount", typeof(int), typeof(BuildStatisticsSectionView), new PropertyMetadata(0));
    }
}
