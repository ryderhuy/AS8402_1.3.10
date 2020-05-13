using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.InSight.Net;
using Cognex.InSight;
using InspSensor.ConfigureUI;
using Cognex.InSight.Controls.Display;

namespace InspSensor
{
    public partial class InsightControls : UserControl, INotifyPropertyChanged
    {
        private CvsNetworkMonitor mMonitor = null;
        private CvsHostSensor mHostSensor = null;
        private CvsInSight mInSight = null;
        private Dictionary<string, object> mBindingObject = new Dictionary<string, object>();
        private List<string> mHostNameLst = new List<string>();
        private CvsImageOrientation mImageOrientation = CvsImageOrientation.Normal;
        private InsightConfigure mInsightConfigure = null;
        private string mHostIPAddress = string.Empty;
        private bool mCanPanImage = false;
        private bool mIsSavingToLocal = false;
        private bool mIsSavingToFTP = false;
        private string mJobFilePath = string.Empty;
        private int mSavingCount = 0;
        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsConnected
        {
            get
            {
                if (mInSight != null)
                {
                    return (mInSight.State != CvsInSightState.NotConnected);
                }
                else
                    return false;
            }
        }
        public bool CanPanImage
        {
            get { return mCanPanImage; }
            set { mCanPanImage = value; }
        }
        public string HostIPAddress
        {
            get { return mHostIPAddress; }
        }
        public List<string> HostNames
        {
            get { return mHostNameLst; }
            internal set
            {
                mHostNameLst = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("HostNames"));
                }
                //PropertyChanged.BeginInvoke(this, new PropertyChangedEventArgs("HostNames"), null, null);
            }
        }
        /// <summary>
        /// Called when the In-Sight SateChanged event raised.
        /// </summary>
        private void mInSight_StateChanged(object sender, CvsStateChangedEventArgs e)
        {
            UpdateControls(true);
        }
        private void UpdateControls(bool update)
        {
            //if (!IsConnected)
            //{
            //    viewToolStripMenuItem.Enabled = false;
            //    imageToolStripMenuItem.Enabled = false;
            //    sensorToolStripMenuItem.Enabled = false;
            //    optionsToolStripMenuItem.Enabled = false;
            //    cboDevices.Enabled = (cboDevices.Items.Count > 0);
            //    btnConnect.Text = "Connect";
            //    if (((ConnectStatus)statusCurrent.Tag == ConnectStatus.Connecting) && update)
            //    {
            //        UpdateStatus(ConnectStatus.Disconnected, "Connection Failed");
            //        MessageBox.Show(this, "Failed to Connect", "Error");
            //    }
            //    else
            //    {
            //        UpdateStatus(ConnectStatus.Disconnected);
            //    }
            //    btnConnect.Enabled = (cboDevices.Items.Count > 0);
            //}
            //else
            //{
            //    imageToolStripMenuItem.Enabled = true;
            //    sensorToolStripMenuItem.Enabled = true;
            //    customViewToolStripMenuItem.Checked = mInSight.JobInfo.AnyCustomViews;
            //    overlayToolStripMenuItem.Checked = cvsInSightDisplay1.ShowGrid;

            //    // When in live acquisition mode, disable invalid operations
            //    liveModeToolStripMenuItem.Checked = mInSight.LiveAcquisition;
            //    if (mInSight.LiveAcquisition)
            //    {
            //        sensorToolStripMenuItem.Enabled = false;
            //        viewToolStripMenuItem.Enabled = false;
            //        optionsToolStripMenuItem.Enabled = false;
            //    }
            //    else
            //    {
            //        sensorToolStripMenuItem.Enabled = true;
            //        viewToolStripMenuItem.Enabled = true;
            //        optionsToolStripMenuItem.Enabled = true;
            //    }
            //    cboDevices.Enabled = false;
            //    btnConnect.Text = "Disconnect";
            //    UpdateStatus(ConnectStatus.Connected);
            //    onlineToolStripMenuItem.Text = (mInSight.State == CvsInSightState.Offline) ? "Go Online" : "Go Offline";
            //}
        }
        public CvsInSight InSight
        {
            get
            {
                try
                {
                    CvsEasyView cvsEasyViewItems = mInSight.GetEasyView();
                }
                catch (Exception ex)
                {

                }
                return mInSight;
            }
            internal set
            {
                if (mInSight != null)
                {
                    mInSight.StateChanged -= new CvsStateChangedEventHandler(mInSight_StateChanged);
                    mInSight.ResultsChanged += new EventHandler(MInSight_ResultsChanged);
                }
                mInSight = value;
                if (mInSight != null)
                {
                    CvsEasyView cvsEasyViewItems = mInSight.GetEasyView();
                    mInSight.StateChanged += new CvsStateChangedEventHandler(mInSight_StateChanged);
                    mInSight.ResultsChanged += new EventHandler(MInSight_ResultsChanged);
                    mInSight.SaveCompleted += MInSight_SaveCompleted;
                }
            }
        }
        private void MInSight_SaveCompleted(object sender, CvsSaveCompletedEventArgs e)
        {
            string jobName = string.Empty;
            int index = mJobFilePath.LastIndexOf("//") + 2;
            jobName = mJobFilePath.Substring(index, mJobFilePath.Length - index);
            mSavingCount++;
            if (mIsSavingToFTP)
            {
                try
                {
                    InSight.File.SaveJobFile(jobName, false);
                    mIsSavingToFTP = false;
                    mIsSavingToLocal = true;
                }
                catch (Exception ex)
                {

                }
            }

            if (mSavingCount == 2 && mIsSavingToLocal)
            {
                mIsSavingToLocal = false;
                mSavingCount = 0;
                this.cvsInSightDisplay1.Cursor = Cursors.Default;
                MessageBox.Show(string.Format("Saved setting to: {0} success!", jobName), "Notification");
            }
        }
        private void MInSight_ResultsChanged(object sender, EventArgs e)
        {

        }
        public InsightControls()
        {
            InitializeComponent();
            Initilize();
        }
        private void Initilize()
        {
            mMonitor = new CvsNetworkMonitor();
            mMonitor.PingInterval = 0;

            mMonitor.HostsChanged += new EventHandler(mMonitor_HostsChanged);
            mMonitor.Enabled = true;

            cvsInSightDisplay1.InSightChanged += new System.EventHandler(this.cvsInSightDisplay1_InSightChanged);
            cvsInSightDisplay1.StatusInformationChanged += new System.EventHandler(cvsInSightDisplay1_StatusInformationChanged);

            mInsightConfigure = new InsightConfigure(this.cvsInSightDisplay1);
            mInsightConfigure.Hide();
        }
        private void mMonitor_HostsChanged(object sender, EventArgs e)
        {
            PopulateHostList();
        }
        private void PopulateHostList()
        {
            List<string> hostNames = new List<string>();

            // Traverse through the hosts, adding them to the combo box (cboDevices).
            foreach (CvsHostSensor host in mMonitor.Hosts)
            {
                hostNames.Add(host.Name);
            }
            HostNames = hostNames;
        }
        private void cvsInSightDisplay1_InSightChanged(object sender, EventArgs e)
        {
            InSight = cvsInSightDisplay1.InSight;
            PropertyChanged.BeginInvoke(this, new PropertyChangedEventArgs("IsConnected"), null, null);

            mImageOrientation = cvsInSightDisplay1.ImageOrientation;
        }
        private void cvsInSightDisplay1_StatusInformationChanged(object sender, EventArgs e)
        {
            PropertyChanged(this, new PropertyChangedEventArgs("StatusInfoChanged"));
        }
        public bool Binding(string mode, object controlObj)
        {
            if (mode == "ZoomImageIn")
                cvsInSightDisplay1.Edit.ZoomImageIn.Bind(controlObj);
            else if (mode == "ZoomImageOut")
                cvsInSightDisplay1.Edit.ZoomImageOut.Bind(controlObj);
            else if (mode == "ZoomImageToFill")
                cvsInSightDisplay1.Edit.ZoomImageToFill.Bind(controlObj);
            else if (mode == "ZoomImageToFit")
                cvsInSightDisplay1.Edit.ZoomImageToFit.Bind(controlObj);
            else if (mode == "ZoomImage1To1")
                cvsInSightDisplay1.Edit.ZoomImage1To1.Bind(controlObj);
            else if (mode == "ShowGrid")
                cvsInSightDisplay1.Edit.ShowGrid.Bind(controlObj);
            else if (mode == "ManualAcquire")
                cvsInSightDisplay1.Edit.ManualAcquire.Bind(controlObj);
            else if (mode == "LiveAcquire")
                cvsInSightDisplay1.Edit.LiveAcquire.Bind(controlObj);
            else if (mode == "Online")
                cvsInSightDisplay1.Edit.SoftOnline.Bind(controlObj);
            else if (mode == "Spreadsheet")
                cvsInSightDisplay1.Edit.ShowGrid.Bind(controlObj);
            else
                return false;
            mBindingObject.Add(mode, controlObj);
            return true;
        }
        public CvsHostSensor GetHostSensor()
        {
            return mHostSensor;
        }
        public string StatusInfoChanged
        {
            get { return cvsInSightDisplay1.StatusInformation; }
        }
        public CvsInSightDisplay GetInsightDisplay()
        {
            return this.cvsInSightDisplay1;
        }
        public void ConnectToSensor(string host)
        {
            try
            {
                if (!IsConnected)
                {
                    mHostSensor = mMonitor.Hosts[host];
                    cvsInSightDisplay1.Connect(mHostSensor.IPAddressString, "admin", "", false);
                    mHostIPAddress = mHostSensor.IPAddressString;
                }
                else
                {
                    cvsInSightDisplay1.Disconnect();
                    mHostSensor = null;
                    InSight = null;
                }
                Refresh();
            }
            catch (CvsException cvsEx)
            {
                mMonitor.Enabled = true;
            }
            catch (Exception ex)
            {

            }

            UpdateControls(false);
        }
        public void ManualTrigger()
        {
            if (!this.InSight.LiveAcquisition)
                this.InSight.ManualAcquire();
        }
        public bool SaveJobRemote(string path2File)
        {
            bool ret = false;
            mJobFilePath = path2File;
            try
            {
                InSight.File.SaveJobFile(path2File, true);
                cvsInSightDisplay1.Cursor = Cursors.WaitCursor;
                mIsSavingToFTP = true;
                ret = true;
            }
            catch (Exception ex)
            {

            }
            return ret;
        }
        public string GetRemotePath()
        {
            string sPath = "";
            if (cvsInSightDisplay1.Connected)
            {
                sPath = String.Format("ftp://{0}:{1}//", mHostIPAddress, 21);
            }
            return sPath;
        }
    }
}
