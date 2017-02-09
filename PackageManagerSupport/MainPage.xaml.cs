using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Management.Deployment;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using Windows.Web.Http.Filters;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PackageManagerSupport
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //PackageManager packageManager = new PackageManager();

            //IEnumerable<Windows.ApplicationModel.Package> packages =
            //    (IEnumerable<Windows.ApplicationModel.Package>)packageManager.FindPackages();

            //int packageCount = 0;
            //foreach (var package in packages)
            //{
            //    DisplayPackageInfo(package);

            //    packageCount += 1;
            //}

            //if (packageCount < 1)
            //{
            //    Debug.WriteLine("No packages were found.");
            //}

            //IEnumerable<Package> _lstPackages = Windows.Phone.Management.Deployment.InstallationManager.FindPackages();
            using (var protocolFilter = new HttpBaseProtocolFilter())
            {
                //Do not handle cookies automatically. you can set it as your requirements.
                protocolFilter.CookieUsageBehavior = HttpCookieUsageBehavior.NoCookies;
                //get CookieManager instance
                var cookieManager = protocolFilter.CookieManager;
                //get cookies
                var cookies = cookieManager.GetCookies(new Uri("https://www.baidu.com"));
                foreach (var cookie in cookies)
                {
                    Debug.Write(cookie.Value);
                }
                //you can also SetCookie
                //cookieManager.SetCookie(MyCookie);

                // Create a HttpClient
                var httpClient = new HttpClient(protocolFilter);
                await httpClient.GetAsync(new Uri("https://www.baidu.com"));
            }
        }

        private static void DisplayPackageInfo(Windows.ApplicationModel.Package package)
        {
            Debug.WriteLine("Name: {0}", package.Id.Name);

            Debug.WriteLine("FullName: {0}", package.Id.FullName);

            Debug.WriteLine("Version: {0}.{1}.{2}.{3}", package.Id.Version.Major, package.Id.Version.Minor,
                package.Id.Version.Build, package.Id.Version.Revision);

            Debug.WriteLine("Publisher: {0}", package.Id.Publisher);

            Debug.WriteLine("PublisherId: {0}", package.Id.PublisherId);

            Debug.WriteLine("Installed Location: {0}", package.InstalledLocation.Path);

            Debug.WriteLine("IsFramework: {0}", package.IsFramework);
        }
    }
}
