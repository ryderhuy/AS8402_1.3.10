using Cognex.InSight;
using Cognex.InSight.Controls.Display;
using InspSensor.MesageManager;
using InspSensor.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InspSensor
{
    public partial class Form1 : Form
    {
        string mDateOfVersion = "05/05/2020";
        private AccessLevel mCurrentAccessLevel = AccessLevel.Operator;
        //private PasswordFile mCurrentPasswordFile = null;
        private string mDefaultAdministratorPassword = "1";
        private string mDefaultSupervisorPassword = "1";
        private string mHostName = String.Empty;
        public CvsInSightDisplay mCvsInsightDisplay;
        //private FormPasswordPrompt mFormPasswordPromp = null;
        //private FileJobBrowser mFileJobBrowser = new FileJobBrowser("", "");
        string mCurrentHostName = string.Empty;
        Timer mReconnectCameraTimer = new Timer();
        int mCurrentSpreadSheetLoggingCount = 0;
        bool mIsFirstTimeMessage = true;
        BackgroundWorker mSaveLogAndImageWorker = new BackgroundWorker();
        string mSensorName = string.Empty;
        Timer mPlaybackTimer = new Timer();
        string mLogDirectory = string.Empty;
        string mImageDirectory = string.Empty;
        string mApplicationName = string.Empty;
        private bool mIsManualDisconnect = false;
        public Form1()
        {
            InitializeComponent();
            this.AutoSize = false;
            this.ControlBox = false;
            Load += InspForm_Load;
            LoadSettingFromProperties();
            mApplicationName = System.IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath);
            MessageManagerSavedFile.Init(mLogDirectory + "\\Log\\", mApplicationName, 30);
            MessageLoggerManager.Log.Info("Starting program...");
            btnLiveImage.Checked = false;
            //setupControl.CtrlDisplayControl.EnableAllInspectionEvent += CtrlDisplayControl_EnableAllInspectionEvent;
            UpdateControlsEnabled(false);
            UpdateStatus("");
            //this.setupControl.AllSettingDoneEvent += SetupControl_AllSettingDoneEvent;
            //this.intrisicControl.AllSettingDoneEvent += IntrisicControl_AllSettingDoneEnvent;
            //this.settingHWControl1.AllSettingDoneEvent += settingHWControl_AllSettingDoneEvent;
            //this.settingHWControl1.ExitEvent += exitButton1_ButtonClick;
            mSaveLogAndImageWorker.WorkerSupportsCancellation = true;
            //mSaveLogAndImageWorker.DoWork += MSaveLogAndImageWorker_DoWork;
            mReconnectCameraTimer.Interval = 20000;
            //mReconnectCameraTimer.Tick += MReconnectCameraTimer_Tick;
            mPlaybackTimer.Interval = 1000;
            //mPlaybackTimer.Tick += MPlaybackTimer_Tick;
        }

        private void btnLiveImage_CheckedChanged(object sender, EventArgs e)
        {
            if (btnLiveImage.Checked)
            {
                btnLiveImage.Image = Properties.Resources.Live1_on;
            }
            else
            {
                btnLiveImage.Image = Properties.Resources.Live1;
            }
        }
        private void InspForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //Set tooltip
            //toolTip.SetToolTip(btnZoomFit, ResourceUtility.GetString("RtZoomFitToolTip"));
            //toolTip.SetToolTip(btnZoomIn, ResourceUtility.GetString("RtZoomInToolTip"));
            //toolTip.SetToolTip(btnZoomOut, ResourceUtility.GetString("RtZoomOutToolTip"));
            //toolTip.SetToolTip(btnSaveImage, ResourceUtility.GetString("RtSaveImageToolTip"));
            //toolTip.SetToolTip(btnLiveImage, ResourceUtility.GetString("RtLiveImageToolTip"));
            //toolTip.SetToolTip(btnLogin, ResourceUtility.GetString("RtLoginToolTip"));
            //toolTip.SetToolTip(btnOnline, ResourceUtility.GetString("RtOnline"));
            //toolTip.SetToolTip(btnTeachMode, ResourceUtility.GetString("RtSensoMode"));
            //toolTip.SetToolTip(btnSaveSetting, ResourceUtility.GetString("RtSaveSetting"));
            //toolTip.SetToolTip(checkBoxSpreadsheet, ResourceUtility.GetString("RtShowSpreadsheet"));
            //toolTip.SetToolTip(btnRotationClockwise, ResourceUtility.GetString("RtRotationClockwise"));
            //toolTip.SetToolTip(btnRotationCounterClockwise, ResourceUtility.GetString("RtRotationCounterClockwise"));
            //toolTip.SetToolTip(btnTrigger, ResourceUtility.GetString("RtManualTrigger"));
            //toolTip.SetToolTip(chxHandPan, "Pan/Drag Image by mouse");

            //PerformedRequiredInit();

            this.insightControls1.PropertyChanged += InsightControls1_PropertyChanged;
            this.insightControls1.Binding("ZoomImageToFit", this.btnZoomFit);
            this.insightControls1.Binding("ZoomImageOut", this.btnZoomOut);
            this.insightControls1.Binding("ZoomImageIn", this.btnZoomIn);
            this.insightControls1.Binding("LiveAcquire", this.btnLiveImage);
            this.insightControls1.Binding("Online", this.btnOnline);
            this.insightControls1.Binding("Spreadsheet", this.checkBoxSpreadsheet);
            //insightControls1.MouseWheel += InsightControls1_MouseWheel;
            checkBoxSpreadsheet.Checked = false;
            checkBoxSpreadsheet.Visible = false;

            if (File.Exists(@"C:\ProgramData\Cognex\Firmware\Guiding System\AS8402.key"))
            {
                checkBoxSpreadsheet.Visible = true;
            }

            groupBoxPlayback.Visible = false;
            groupBoxSaveImage.Visible = false;
            groupBoxHandEye.Visible = false;
        }
        private void LoadSettingFromProperties()
        {
            txtLogDirectory.Text = Properties.Settings.Default.LogDirectory;
            txtImageDirectory.Text = Properties.Settings.Default.ImageDirectory;
            if (Properties.Settings.Default.LogDirectory != "")
            {
                mLogDirectory = Properties.Settings.Default.LogDirectory;
            }
            else
            {
                mLogDirectory = Environment.CurrentDirectory;
                //txtLogDirectory.Text = Environment.CurrentDirectory;
            }

            if (Properties.Settings.Default.ImageDirectory != "")
            {
                mImageDirectory = Properties.Settings.Default.ImageDirectory;
            }
            else
            {
                mImageDirectory = Environment.CurrentDirectory;
                //txtImageDirectory.Text = Environment.CurrentDirectory;
            }

            chxSaveRaw.Checked = Properties.Settings.Default.IsSaveRaw;
            chxSaveNGOnly.Checked = Properties.Settings.Default.IsSaveNGOnly;
            chxSaveGraphicImage.Checked = Properties.Settings.Default.IsSaveGraphic;
            numSavedDay.Value = decimal.Parse(Properties.Settings.Default.SavingDay.ToString());
        }
        private void MReconnectCameraTimer_Tick(object sender, EventArgs e)
        {
            //if (mCvsInsightDisplay != null && !insightControls1.IsConnected && !mIsManualDisconnect && mCvsInsightDisplay.State != CvsDisplayState.Connecting)
            //{
            //    try
            //    {
            //        insightControls1.ConnectToSensor(mCurrentHostName);
            //        insightControls1.GetInsightDisplay().ImageZoomMode = CvsDisplayZoom.Fit;
            //        mCvsInsightDisplay = insightControls1.GetInsightDisplay();
            //        MessageLoggerManager.Log.Warn("Auto reconnect Camera...");
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageLoggerManager.Log.Alarm("Auto reconnect Camera Fail!", ex);
            //    }
            //}
        }

        private void insightControls1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnTeachMode.Text = "Auto Mode";
            btnTeachMode.BackColor = Color.Lime;

            if (btnConnect.Text.Contains("Dis"))
            {
                lblExposureTime.Visible = false;
                numExposureTime.Visible = false;

                btnIntrisic.Visible = false;
                btnIntrisicDone.Visible = false;
                btnSetupInsp.Visible = false;
                btnSetupInspDone.Visible = false;
                btnSettingHW.Visible = false;
                btnSettingHWDone.Visible = false;

                //setupControl.Visible = false;
                //settingHWControl1.Visible = false;
                //intrisicControl.Visible = false;

                groupBoxSaveImage.Visible = false;
                groupBoxPlayback.Visible = false;
                groupBoxHandEye.Visible = false;
                //chxSaveGraphicImage.Visible = false;
                //chxSaveRaw.Visible = false;
                //chxSaveScreen.Visible = false;
                //btnPlaybackFirst.Visible = false;
                //btnPlaybackFolder.Visible = false;
                //btnPlaybackLast.Visible = false;
                //btnPlaybackNext.Visible = false;
                //btnPlaybackPrevious.Visible = false;

                //mSyncMessageTimer.Stop();
                if (mSaveLogAndImageWorker.IsBusy)
                {
                    mSaveLogAndImageWorker.CancelAsync();
                }

                // Disable Teaching mode
                string nameTag = string.Format("RtInspectionTeachingMode");
                var tag = GetTag(ResourceUtility.GetString(nameTag));
                if (tag != null)
                {
                    InsightSetValue(tag.Location, false);
                }
                mIsManualDisconnect = true;
            }
            else
            {
                mSensorName = comboBoxDevices.Text;
                //mSyncMessageTimer.Start();
                if (!mSaveLogAndImageWorker.IsBusy)
                {
                    mSaveLogAndImageWorker.RunWorkerAsync();
                }
                mIsManualDisconnect = false;
            }

            if (comboBoxDevices.SelectedItem != null)
            {
                this.insightControls1.ConnectToSensor(comboBoxDevices.SelectedItem.ToString());
                mCurrentHostName = comboBoxDevices.SelectedItem.ToString();
                mReconnectCameraTimer.Start();
            }
            this.insightControls1.GetInsightDisplay().ImageZoomMode = CvsDisplayZoom.Fit;
            mCvsInsightDisplay = insightControls1.GetInsightDisplay();

            MessageLoggerManager.Log.Info("[Action] Connect/Disconect...");
        }
        private void InsightControls1_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                PropertyChangedEventHandler delHandler = new PropertyChangedEventHandler(InsightControls1_PropertyChanged);
                Invoke(delHandler, sender, e);
            }
            else
            {
                string propertyName = e.PropertyName;
                switch (propertyName)
                {
                    case "HostNames":
                        {
                            comboBoxDevices.Items.Clear();
                            comboBoxDevices.Enabled = (this.insightControls1.HostNames.Count > 0);
                            foreach (var host in this.insightControls1.HostNames)
                            {
                                comboBoxDevices.Items.Add(host);
                            }

                            if (comboBoxDevices.Items.Count > 0)
                            {
                                this.btnConnect.Enabled = true;
                                if (this.insightControls1.IsConnected && (this.insightControls1.GetHostSensor() != null))
                                {
                                    comboBoxDevices.SelectedIndex = comboBoxDevices.Items.IndexOf(this.insightControls1.GetHostSensor().Name);
                                }
                                else
                                {
                                    comboBoxDevices.SelectedIndex = 0;
                                }
                            }
                        }
                        UpdateStatus("");
                        break;
                    case "IsConnected":
                        {
                            try
                            {
                                bool isControlConnected = this.insightControls1.IsConnected;
                                bool isDisplayConnected = this.mCvsInsightDisplay.Connected;
                                bool isConnected = isControlConnected || isDisplayConnected;
                                //MessageLoggerManager.Log.Info(String.Format("{0} to sensor", isConnected ? "Connected" : "Disconnected"));
                                comboBoxDevices.SelectedIndex = comboBoxDevices.Items.IndexOf(mCurrentHostName);
                                UpdateStatus(isConnected ? ConnectStatus.Connected : ConnectStatus.Disconnected, "");
                                if (isConnected)
                                    UpdateControlsEnabled();
                            }
                            catch (Exception ex) { }
                        }
                        break;
                    case "StatusInfoChanged":
                        {
                            this.toolStripStatusStatus.Text = this.insightControls1.StatusInfoChanged;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        private bool isDeleteOldFolder = false;
        private void UpdateControlsEnabled(bool isAuto = false)
        {
            bool isAdminLevel = mCurrentAccessLevel == AccessLevel.Administrator;
            bool isSupervisorLevel = mCurrentAccessLevel == AccessLevel.Supervisor;
            if (isAuto == true)
            {
                isSupervisorLevel = true;
            }
            //checkBoxSpreadsheet.Visible = isAdminLevel;
            //this.btnOpenJob.Visible = isAdminLevel;
            //this.btnSaveJob.Visible = isAdminLevel;
            this.isDeleteOldFolder = isAdminLevel | isSupervisorLevel;
            this.lblExposureTime.Visible = isAdminLevel | isSupervisorLevel;
            this.numExposureTime.Visible = isAdminLevel | isSupervisorLevel;

            this.btnSetupInsp.Visible = isAdminLevel | isSupervisorLevel;
            this.btnIntrisic.Visible = isAdminLevel | isSupervisorLevel;
            this.btnSettingHW.Visible = isAdminLevel | isSupervisorLevel;

            groupBoxPlayback.Visible = isAdminLevel | isSupervisorLevel;
            groupBoxSaveImage.Visible = isAdminLevel | isSupervisorLevel;
            groupBoxHandEye.Visible = isAdminLevel | isSupervisorLevel;
            //chxSaveGraphicImage.Visible = isAdminLevel | isSupervisorLevel;
            //chxSaveRaw.Visible = isAdminLevel | isSupervisorLevel;
            //chxSaveScreen.Visible = isAdminLevel | isSupervisorLevel;
            //btnPlaybackFirst.Visible = isAdminLevel | isSupervisorLevel;
            //btnPlaybackFolder.Visible = isAdminLevel | isSupervisorLevel;
            //btnPlaybackLast.Visible = isAdminLevel | isSupervisorLevel;
            //btnPlaybackNext.Visible = isAdminLevel | isSupervisorLevel;
            //btnPlaybackPrevious.Visible = isAdminLevel | isSupervisorLevel;

            //if (this.intrisicControl.Visible)
            //{
            //    this.intrisicControl.Visible = isAdminLevel | isSupervisorLevel;
            //}
            //if (this.setupControl.Visible)
            //{
            //    this.setupControl.Visible = isAdminLevel | isSupervisorLevel;
            //}
            //if (this.settingHWControl1.Visible)
            //{
            //    this.settingHWControl1.Visible = isAdminLevel | isSupervisorLevel;
            //}
            if (this.btnIntrisicDone.Visible)
            {
                this.btnIntrisicDone.Visible = isAdminLevel | isSupervisorLevel;
            }
            if (this.btnSetupInspDone.Visible)
            {
                this.btnSetupInspDone.Visible = isAdminLevel | isSupervisorLevel;
            }
            if (this.btnSettingHWDone.Visible)
            {
                this.btnSettingHWDone.Visible = isAdminLevel | isSupervisorLevel;
            }


            if (mCurrentAccessLevel > AccessLevel.Operator)
            {
                this.btnLogin.BackgroundImage = global::InspSensor.Properties.Resources.padlock_unlock;
            }
            else
            {
                this.btnLogin.BackgroundImage = global::InspSensor.Properties.Resources.locked_padlock;
            }

            if (this.insightControls1.IsConnected)
            {
                //handEyeStatus1.Init(mCvsInsightDisplay);
            }

            try
            {
                if (this.insightControls1.IsConnected)
                {
                    string nameTag = string.Format("RtInspectionTeachingMode");
                    var tag = GetTag(ResourceUtility.GetString(nameTag));
                    if (tag != null)
                    {
                        bool isTeaching = (bool)GetValue(tag.Location);
                        if (!isTeaching)
                        {
                            btnTeachMode.Text = "Auto Mode";
                            btnTeachMode.BackColor = Color.Lime;
                        }
                        else
                        {
                            btnTeachMode.Text = "Teach Mode";
                            btnTeachMode.BackColor = Color.Red;
                        }
                    }
                }
                // update inspection exposure time to HMI 
                if (this.insightControls1.IsConnected)
                {
                    mCvsInsightDisplay = insightControls1.GetInsightDisplay();
                    var tag = GetTag(ResourceUtility.GetString("RtInspAcqExposure"));
                    if (tag != null)
                    {
                        float exposure = (float)GetValue(tag.Location);
                        numExposureTime.Value = (decimal)exposure;
                    }
                }
            }
            catch
            { }
        }
        /// <summary>
        /// Updates status with the specified string.
        /// </summary>
        /// <param name="message"></param>
        private void UpdateStatus(string message)
        {
            UpdateStatus(ConnectStatus.NA, message);
        }

        /// <summary>
        /// Updates the message in the status bar.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="message"></param>
        private void UpdateStatus(ConnectStatus state, string message)
        {
            string statusText = "";
            toolStripStatusConnection.Tag = statusText;

            switch (state)
            {
                case ConnectStatus.Connecting:
                    statusText = "Connecting...";
                    break;
                case ConnectStatus.Disconnecting:
                    statusText = "Disconnecting...";
                    break;
                case ConnectStatus.Connected:
                    statusText = "Connected";
                    break;
                case ConnectStatus.Disconnected:
                    statusText = "Not connected";
                    break;
                case ConnectStatus.NA:
                    break;
            }

            toolStripStatusConnection.Text = statusText;

            //Update Control
            if (ConnectStatus.Connected == state)
            {
                this.btnConnect.Text = "Disconnect";
            }
            else
            {
                this.btnConnect.Text = "Connect";
            }


            //Title
            if (this.comboBoxDevices.Items.Count > 0)
            {
                if (ConnectStatus.Connected == state)
                    this.labelSensorStatus.Text = String.Format("Connect to {0}", this.comboBoxDevices.SelectedItem as String);
                else
                    this.labelSensorStatus.Text = "";
            }
            else
                this.labelSensorStatus.Text = "No sensor found";
        }
        private CvsSymbolicTag GetTag(string tagName)
        {
            try
            {
                if (mCvsInsightDisplay != null)
                {
                    var tags = mCvsInsightDisplay.InSight.GetSymbolicTagCollection();
                    CvsSymbolicTag tag = tags[tagName];
                    return tag;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetTag: " + ex.Message, "Error");
            }

            return null;
        }
        private object GetValue(CvsCellLocation location)
        {
            Cognex.InSight.Cell.CvsCell c = mCvsInsightDisplay.InSight.Results.Cells[location];
            if (c.GetType() == typeof(Cognex.InSight.Cell.CvsCellEditFloat))
            {
                return ((Cognex.InSight.Cell.CvsCellEditFloat)c).Value;
            }
            else if (c.GetType() == typeof(Cognex.InSight.Cell.CvsCellEditInt))
            {
                return ((Cognex.InSight.Cell.CvsCellEditInt)c).Value;
            }
            else if (c.GetType() == typeof(Cognex.InSight.Cell.CvsCellEditString))
            {
                return ((Cognex.InSight.Cell.CvsCellEditString)c).Text;
            }
            else if (c.GetType() == typeof(Cognex.InSight.Cell.CvsCellCheckBox))
            {
                return ((Cognex.InSight.Cell.CvsCellCheckBox)c).Checked;
            }
            return null;
        }

        private void InsightSetValue(CvsCellLocation location, float value)
        {
            mCvsInsightDisplay.InSight.SetFloat(location, value);
        }

        private void InsightSetValue(CvsCellLocation location, int value)
        {
            mCvsInsightDisplay.InSight.SetInteger(location, value);
        }

        private void InsightSetValue(CvsCellLocation location, string value)
        {
            mCvsInsightDisplay.InSight.SetString(location, value);
        }

        private void InsightSetValue(CvsCellLocation location, bool value)
        {
            mCvsInsightDisplay.InSight.SetCheckBox(location, value);
        }

        private void btnOnline_CheckedChanged(object sender, EventArgs e)
        {
            if (btnOnline.Checked)
            {
                btnOnline.Image = Properties.Resources.power_on;
            }
            else
            {
                btnOnline.Image = Properties.Resources.power;
            }
        }

        private void btnTrigger_Click(object sender, EventArgs e)
        {
            this.insightControls1.ManualTrigger();
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to save setting?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SaveJobSetting(false);
            }

            //MessageManager.MessageLoggerManager.Log.Info("[Action] Save Setting...");
        }
        private void SaveJobSetting(bool isNotify)
        {
            string jobName = "";
            var tag = GetTag(ResourceUtility.GetString("RtJobName"));
            if (tag != null)
            {
                jobName = (string)GetValue(tag.Location);
            }
            if (jobName.Contains("ftp"))
            {
                insightControls1.SaveJobRemote(jobName);
                if (isNotify)
                    MessageBox.Show(string.Format("Save setting done to ftp {0}!", jobName), "Notification");
            }
            else
            {
                insightControls1.SaveJobRemote(this.insightControls1.GetRemotePath() + "//" + jobName);
                if (isNotify)
                    MessageBox.Show(string.Format("Save setting done to camera {0}!", jobName), "Notification");
            }

        }
        
    }
}
