using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Controls;
using Microsoft.VisualStudio.TeamFoundation.Build;

namespace Company.BuildStatisticsSample 
{
    [TeamExplorerSection("E52594FD-490A-4218-9D89-25B16500AA32", TeamExplorerPageIds.Builds, 10)]
    public class BuildStatisticsSection : ITeamExplorerSection 
    {
        public BuildStatisticsSection()
        {
            Title = "Build Statistics";
            IsExpanded = true;
            IsVisible = true;
            IsBusy = false;
            SectionContent = new BuildStatisticsSectionView();
        }

        public void Cancel() 
        {
        }

        public object GetExtensibilityService(Type serviceType)
        {
            return null;
        }

        private IServiceProvider m_ServiceProvider;
        public void Initialize(object sender, SectionInitializeEventArgs e)
        {
            m_ServiceProvider = e.ServiceProvider;
            Refresh();
        }

        private bool m_IsBusy;
        public bool IsBusy
        {
            get { return m_IsBusy; }
            private set { m_IsBusy = value; OnPropertyChanged("IsBusy"); }
        }

        private bool m_IsExpanded;
        public bool IsExpanded
        {
            get { return m_IsExpanded; }
            set { m_IsExpanded = value; OnPropertyChanged("IsExpanded"); }
        }

        private bool m_IsVisible;
        public bool IsVisible
        {
            get { return m_IsVisible; }
            set { m_IsVisible = value; OnPropertyChanged("IsVisible"); }
        }

        public void Loaded(object sender, SectionLoadedEventArgs e)
        {
        }

        public async void Refresh()
        {
            await RefreshAsync();
        }

        public async Task RefreshAsync()
        {
            try
            {
                IsBusy = true;

                var contextManager = (ITeamFoundationContextManager)m_ServiceProvider.GetService(typeof(ITeamFoundationContextManager));
                var buildService = (IVsTeamFoundationBuild)m_ServiceProvider.GetService(typeof(IVsTeamFoundationBuild));
                var buildServer = buildService.BuildServer;

                var buildDetailSpec = buildServer.CreateBuildDetailSpec(contextManager.CurrentContext.TeamProjectName);
                buildDetailSpec.Status = BuildStatus.All ^ BuildStatus.InProgress ^ BuildStatus.NotStarted; //Only completed builds
                buildDetailSpec.MinFinishTime = DateTime.Now.AddHours(-1);

                //Performance optimizations
                buildDetailSpec.InformationTypes = new string[] { }; 
                buildDetailSpec.QueryOptions = QueryOptions.None;

                IBuildQueryResult buildQueryResult = null;
                await Task.Run(() =>
                {
                    buildQueryResult = buildServer.QueryBuilds(buildDetailSpec);
                });

                View.RecentlyCompletedBuildCount = buildQueryResult.Builds.Length;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void SaveContext(object sender, SectionSaveContextEventArgs e)
        {
        }

        private object m_View;
        public object SectionContent
        {
            get { return m_View; }
            private set { m_View = value; OnPropertyChanged("SectionContent"); }
        }

        public BuildStatisticsSectionView View
        {
            get { return SectionContent as BuildStatisticsSectionView; }
        }

        private string m_Title;
        public string Title
        {
            get { return m_Title; }
            private set { m_Title = value; OnPropertyChanged("Title"); }
        }

        public void Dispose()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}