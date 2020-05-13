using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.InSight.Controls.Display;
using Cognex.InSight;
using InspSensor.Utility;
using InspSensor.MesageManager;
using System.Threading;

namespace InspSensor.CustomControls.Inspection
{
    public partial class TrayInspection : UserControl
    {
        public EventHandler SettingDoneEvent;
        private CvsInSightDisplay mCvsInsightDisplay = null;
        private string mFinderTypeName = "Tray";
        private bool isInit = true;
        private bool checkSearchRegionR1 = true;
        private bool checkSearchRegionF1 = true;
        public TrayInspection()
        {
            isInit = true;
            InitializeComponent();
            isInit = false;
        }
        public void Init(CvsInSightDisplay insightDisplay)
        {
            mCvsInsightDisplay = insightDisplay;

            if (insightDisplay.Connected)
            {
                isInit = true;
                UpdateGUIParams();
                isInit = false;
            }
        }
        private void UpdateGUIParams()
        {
            try
            {
                checkSearchRegionF1 = true;
                checkSearchRegionR1 = true;
                var tag = GetTag(ResourceUtility.GetString(string.Format("RtInsp{0}EnableF", mFinderTypeName)));
                if (tag != null)
                {
                    bool isEnableF = (bool)GetValue(tag.Location);
                    chxEnableF.Checked = (bool)isEnableF;
                }

                tag = GetTag(ResourceUtility.GetString(string.Format("RtInsp{0}ContrastThresholdF", mFinderTypeName)));
                if (tag != null)
                {
                    float thresholdF = (float)GetValue(tag.Location);
                    numContrastThresholdF.Value = (decimal)thresholdF;
                }

                tag = GetTag(ResourceUtility.GetString(string.Format("RtInsp{0}AngleRangeF", mFinderTypeName)));
                if (tag != null)
                {
                    float angleRangeF = (float)GetValue(tag.Location);
                    numAngleRangeF.Value = (decimal)angleRangeF;
                }

                tag = GetTag(ResourceUtility.GetString(string.Format("RtInsp{0}ScoreThresholdF", mFinderTypeName)));
                if (tag != null)
                {
                    float scoreThresholdF = (float)GetValue(tag.Location);
                    numScoreThresholdF.Value = (decimal)scoreThresholdF;
                }

                tag = GetTag(ResourceUtility.GetString(string.Format("RtInsp{0}ShowgraphicF", mFinderTypeName)));
                if (tag != null)
                {
                    int showGraphicF = (int)GetValue(tag.Location);
                    numShowGraphicF.Value = (int)showGraphicF;
                }


                tag = GetTag(ResourceUtility.GetString(string.Format("RtInsp{0}EnableR", mFinderTypeName)));
                if (tag != null)
                {
                    bool isEnableR = (bool)GetValue(tag.Location);
                    chxEnableR.Checked = (bool)isEnableR;
                }

                tag = GetTag(ResourceUtility.GetString(string.Format("RtInsp{0}ContrastThresholdR", mFinderTypeName)));
                if (tag != null)
                {
                    float thresholdR = (float)GetValue(tag.Location);
                    numContrastThresholdR.Value = (decimal)thresholdR;
                }

                tag = GetTag(ResourceUtility.GetString(string.Format("RtInsp{0}AngleRangeR", mFinderTypeName)));
                if (tag != null)
                {
                    float angleRangeR = (float)GetValue(tag.Location);
                    numAngleRangeR.Value = (decimal)angleRangeR;
                }

                tag = GetTag(ResourceUtility.GetString(string.Format("RtInsp{0}ScoreThresholdR", mFinderTypeName)));
                if (tag != null)
                {
                    float scoreThresholdR = (float)GetValue(tag.Location);
                    numScoreThresholdR.Value = (decimal)scoreThresholdR;
                }

                tag = GetTag(ResourceUtility.GetString(string.Format("RtInsp{0}ShowgraphicR", mFinderTypeName)));
                if (tag != null)
                {
                    int showGraphicR = (int)GetValue(tag.Location);
                    numShowGraphicR.Value = (int)showGraphicR;
                }

                tag = GetTag(ResourceUtility.GetString(string.Format("RtInsp{0}FirstTimeExposure", mFinderTypeName)));
                if (tag != null)
                {
                    float firstTimeExp = (float)GetValue(tag.Location);
                    numExposureTimeForFirstTray.Value = (decimal)firstTimeExp;
                }

                tag = GetTag(ResourceUtility.GetString(string.Format("RtAlignTrayContrastThresh")));
                if (tag != null)
                {
                    float Value = (float)GetValue(tag.Location);
                    numAlignPocketContrastThresh.Value = (decimal)Value;
                }

                tag = GetTag(ResourceUtility.GetString(string.Format("RtAlignTrayAngleRange")));
                if (tag != null)
                {
                    float Value = (float)GetValue(tag.Location);
                    numAlignPocketAngleRange.Value = (decimal)Value;
                }

                tag = GetTag(ResourceUtility.GetString(string.Format("RtAlignTrayScoreThresh")));
                if (tag != null)
                {
                    float Value = (float)GetValue(tag.Location);
                    numAlignPocketScoreThresh.Value = (decimal)Value;
                }

                tag = GetTag(ResourceUtility.GetString(string.Format("RtAlignTrayGraphic")));
                if (tag != null)
                {
                    float Value = (float)GetValue(tag.Location);
                    numAlignPocketGraphic.Value = (decimal)Value;
                }

                tag = GetTag(ResourceUtility.GetString(string.Format("RtAlignTrayEnable")));
                if (tag != null)
                {
                    bool isEnable = (bool)GetValue(tag.Location);
                    chxAlignPocketonTrayEnable.Checked = (bool)isEnable;
                }

                tag = GetTag(ResourceUtility.GetString(string.Format("RtAlignTrayNumofPocket")));
                if (tag != null)
                {
                    int Value = (int)GetValue(tag.Location);
                    numNumberAlignPocket.Value = (int)Value;
                    numAPNumbPocket.Value = (int)Value;
                }

                if (cbxSearchRegionAlignPocket != null)
                    cbxSearchRegionAlignPocket.Items.Clear();

                if (cbxAPSearchRegion != null)
                    cbxAPSearchRegion.Items.Clear();

                if (cbxPocketTolerance != null)
                    cbxPocketTolerance.Items.Clear();

                for (int i = 0; i < (int)numNumberAlignPocket.Value; ++i)
                {
                    cbxSearchRegionAlignPocket.Items.Add(string.Format("Region{0}", i + 1));
                    cbxAPSearchRegion.Items.Add(string.Format("Region{0}", i + 1));
                    cbxPocketTolerance.Items.Add(string.Format("Pocket{0}", i + 1));
                }

                cbxSearchRegionAlignPocket.SelectedIndex = 0;
                cbxAPSearchRegion.SelectedIndex = 0;
                cbxPocketTolerance.SelectedIndex = 0;

                tag = GetTag("Align.Tray.XTTEnable");
                if (tag != null)
                {
                    bool isEnable = (bool)GetValue(tag.Location);
                    chxEnableSendXTT.Checked = (bool)isEnable;
                }

                tag = GetTag("Inspection.6.AcquisitionSettings.ExposureTime");
                if (tag != null)
                {
                    float Value = (float)GetValue(tag.Location);
                    numAPExposure.Value = (decimal)Value;
                }

                tag = GetTag("Align.Pocket.Tolerance.Enable");
                if (tag != null)
                {
                    bool isEnable = (bool)GetValue(tag.Location);
                    chxPocketToleranceEnable.Checked = (bool)isEnable;
                }

                tag = GetTag("Align.Pocket.Tolerance.X_1");
                if (tag != null)
                {
                    float Value = (float)GetValue(tag.Location);
                    numToleranceX.Value = (decimal)Value;
                }

                tag = GetTag("Align.Pocket.Tolerance.Y_1");
                if (tag != null)
                {
                    float Value = (float)GetValue(tag.Location);
                    numToleranceY.Value = (decimal)Value;
                }

                tag = GetTag("Align.Pocket.Tolerance.T_1");
                if (tag != null)
                {
                    float Value = (float)GetValue(tag.Location);
                    numToleranceTheta.Value = (decimal)Value;
                }

                tag = GetTag("Align.Pocket.Limit.Enable");
                if (tag != null)
                {
                    bool isEnable = (bool)GetValue(tag.Location);
                    chxPocketLimitEnable.Checked = (bool)isEnable;
                }

                tag = GetTag("Align.Pocket.Litmit.Max.X");
                if (tag != null)
                {
                    float Value = (float)GetValue(tag.Location);
                    numPocketLimMaxX.Value = (decimal)Value;
                }

                tag = GetTag("Align.Pocket.Litmit.Max.Y");
                if (tag != null)
                {
                    float Value = (float)GetValue(tag.Location);
                    numPocketLimMaxY.Value = (decimal)Value;
                }

                tag = GetTag("Align.Pocket.Litmit.Max.Theta");
                if (tag != null)
                {
                    float Value = (float)GetValue(tag.Location);
                    numPocketLimMaxTheta.Value = (decimal)Value;
                }

                tag = GetTag("Align.Pocket.Litmit.Min.X");
                if (tag != null)
                {
                    float Value = (float)GetValue(tag.Location);
                    numPocketLimMinX.Value = (decimal)Value;
                }

                tag = GetTag("Align.Pocket.Litmit.Min.Y");
                if (tag != null)
                {
                    float Value = (float)GetValue(tag.Location);
                    numPocketLimMinY.Value = (decimal)Value;
                }

                tag = GetTag("Align.Pocket.Litmit.Min.Theta");
                if (tag != null)
                {
                    float Value = (float)GetValue(tag.Location);
                    numPocketLimMinTheta.Value = (decimal)Value;
                }

                UpdateValueTrayInspection();

                //update display 8 pocket
                tag = GetTag("RtInspTrayInspection8Pocket");
                if (tag != null)
                {
                    if (!(Boolean)GetValue(tag.Location))
                    {
                        this.tabControl1.TabPages.Remove(this.tabPage4);
                        this.tabControl1.TabPages.Remove(this.tabPage3);
                        this.tabControl1.TabPages.Remove(this.tabPage5);
                    }
                    else
                    {
                        if (!this.tabControl1.TabPages.Contains(this.tabPage3))
                        {
                            this.tabControl1.TabPages.Add(this.tabPage3);
                        }
                        if (!this.tabControl1.TabPages.Contains(this.tabPage4))
                        {
                            this.tabControl1.TabPages.Add(this.tabPage4);
                        }
                        if (!this.tabControl1.TabPages.Contains(this.tabPage5))
                        {
                            this.tabControl1.TabPages.Add(this.tabPage5);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        #region insight function
        private void InsightClickButton(CvsCellLocation location)
        {
            try
            {
                mCvsInsightDisplay.InSight.ClickButton(location);
            }
            catch { }
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
            try
            {
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
                else
                    return null;
            }
            catch { return null; }
        }
        private void InsightSetValue(CvsCellLocation location, float value)
        {
            try
            {
                mCvsInsightDisplay.InSight.SetFloat(location, value);
            }
            catch { }
        }

        private void InsightSetValue(CvsCellLocation location, int value)
        {
            try
            {
                mCvsInsightDisplay.InSight.SetInteger(location, value);
            }
            catch { }
        }

        private void InsightSetValue(CvsCellLocation location, string value)
        {
            try
            {
                mCvsInsightDisplay.InSight.SetString(location, value);
            }
            catch { }
        }

        private void InsightSetValue(CvsCellLocation location, bool value)
        {
            try
            {
                mCvsInsightDisplay.InSight.SetCheckBox(location, value);
            }
            catch { }
        }
        #endregion

        private void UpdateValueTrayInspection()
        {
            var tag = GetTag(ResourceUtility.GetString("RtInspTrayEnableF_2"));
            if (tag != null)
            {
                bool bEnableF_2 = (bool)GetValue(tag.Location);
                chxEnableF2.Checked = bEnableF_2;
            }

            tag = GetTag(ResourceUtility.GetString("RtInspTrayEnableR_2"));
            if (tag != null)
            {
                chxEnableR2.Checked = (bool)GetValue(tag.Location);
            }
            tag = GetTag(ResourceUtility.GetString("RtInspTrayMultiPatternShowOffset_FW"));
            if (tag != null)
            {
                chxShowOffsetF.Checked = (bool)GetValue(tag.Location);
            }
            tag = GetTag(ResourceUtility.GetString("RtInspTrayMultiPatternShowOffset_RV"));
            if (tag != null)
            {
                chxShowOffsetR.Checked = (bool)GetValue(tag.Location);
            }


        }

        private void btnTrainRegionF_Click(object sender, EventArgs e)
        {
            string nameTag = string.Format("RtInsp{0}TrainRegionF", mFinderTypeName);
            var tag = GetTag(ResourceUtility.GetString(nameTag));
            if (tag != null)
            {
                EditCellGraphic(tag.Location);
            }
            MessageLoggerManager.Log.Info(String.Format("[Action] Click Train Region F1"));
        }
        private void EditCellGraphic(CvsCellLocation location)
        {
            try
            {
                mCvsInsightDisplay.EditCellGraphic(location);
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSearchRegionF_Click(object sender, EventArgs e)
        {
            checkSearchRegionF1 = true;
            //update value for Search Region F
            var tag = GetTag(ResourceUtility.GetString(string.Format("RtInsp{0}ContrastThresholdF", mFinderTypeName)));
            if (tag != null)
            {
                float thresholdF = (float)GetValue(tag.Location);
                numContrastThresholdF.Value = (decimal)thresholdF;
            }

            tag = GetTag(ResourceUtility.GetString(string.Format("RtInsp{0}AngleRangeF", mFinderTypeName)));
            if (tag != null)
            {
                float angleRangeF = (float)GetValue(tag.Location);
                numAngleRangeF.Value = (decimal)angleRangeF;
            }

            tag = GetTag(ResourceUtility.GetString(string.Format("RtInsp{0}ScoreThresholdF", mFinderTypeName)));
            if (tag != null)
            {
                float scoreThresholdF = (float)GetValue(tag.Location);
                numScoreThresholdF.Value = (decimal)scoreThresholdF;
            }

            string nameTag = string.Format("RtInsp{0}SearchRegionF", mFinderTypeName);
            tag = GetTag(ResourceUtility.GetString(nameTag));
            if (tag != null)
            {
                EditCellGraphic(tag.Location);
            }
            MessageLoggerManager.Log.Info(String.Format("[Action] Click Search Region F1"));
        }

        private void btnTrainPMF_Click(object sender, EventArgs e)
        {
            string nameTag = string.Format("RtInsp{0}TrainButtonF", mFinderTypeName);
            var tag = GetTag(ResourceUtility.GetString(nameTag));
            if (tag != null)
            {
                InsightClickButton(tag.Location);
            }

            Thread.Sleep(50);
            UpdateValueTrayInspection();
            MessageLoggerManager.Log.Info(String.Format("[Action] Click Train F1"));
        }

        private void btnTrainRegionF2_Click(object sender, EventArgs e)
        {
            try
            {
                string nameTag = string.Format("RtInsp{0}TrainRegionF_2", mFinderTypeName);
                var tag = GetTag(ResourceUtility.GetString(nameTag)); //GetTag(nameTag)
                string test = ResourceUtility.GetString(nameTag);
                if (tag != null)
                {
                    EditCellGraphic(tag.Location);
                }
                MessageLoggerManager.Log.Info(String.Format("[Action] Click Train Region F2"));
            }
            catch { }
        }

        private void btnSearchRegionF2_Click(object sender, EventArgs e)
        {
            checkSearchRegionF1 = false;
            try
            {
                //update for value for Search Reion F2
                var tag = GetTag("Inspection.1.TrayInspection.FW.ContrastThreshold_2");
                if (tag != null)
                {
                    float thresholdF = (float)GetValue(tag.Location);
                    numContrastThresholdF.Value = (decimal)thresholdF;
                }

                tag = GetTag("Inspection.1.TrayInspection.FW.AngleRange_2");
                if (tag != null)
                {
                    float angleRangeF = (float)GetValue(tag.Location);
                    numAngleRangeF.Value = (decimal)angleRangeF;
                }

                tag = GetTag("Inspection.1.TrayInspection.FW.ScoreThreshold_2");
                if (tag != null)
                {
                    float scoreThresholdF = (float)GetValue(tag.Location);
                    numScoreThresholdF.Value = (decimal)scoreThresholdF;
                }

                string nameTag = string.Format("RtInsp{0}SearchRegionF_2", mFinderTypeName);
                tag = GetTag(ResourceUtility.GetString(nameTag));
                if (tag != null)
                {
                    EditCellGraphic(tag.Location);
                }
                MessageLoggerManager.Log.Info(String.Format("[Action] Click Search Region F2"));
            }

            catch { }
        }

        private void btnTrainPMF2_Click(object sender, EventArgs e)
        {
            try
            {
                string nameTag = string.Format("RtInsp{0}TrainButtonF_2", mFinderTypeName);
                var tag = GetTag(ResourceUtility.GetString(nameTag));
                if (tag != null)
                {
                    InsightClickButton(tag.Location);
                }

                Thread.Sleep(50);
                UpdateValueTrayInspection();
                MessageLoggerManager.Log.Info(String.Format("[Action] Click Train F2"));
            }
            catch { }
        }

        private void btnTrainGoldenF_Click(object sender, EventArgs e)
        {
            string nameTag = string.Format("RtInsp{0}TrainGoldenButtonF", mFinderTypeName);
            var tag = GetTag(ResourceUtility.GetString(nameTag));
            if (tag != null)
            {
                InsightClickButton(tag.Location);
            }
            MessageLoggerManager.Log.Info(String.Format("[Action] Click button Train Golden F"));
        }

        private void numContrastThresholdF_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //Forward
                if (checkSearchRegionF1)
                {
                    string nameTag = string.Format("Inspection.1.TrayInspection.FW.ContrastThreshold");
                    var tag = GetTag(nameTag);
                    if (tag != null)
                    {
                        InsightSetValue(tag.Location, (float)numContrastThresholdF.Value);
                    }
                    MessageLoggerManager.Log.Info(String.Format("[Action] Contrast Threshold F : " + (float)numContrastThresholdF.Value));
                }
                else
                {
                    //Forward  region 2
                    string nameTag = string.Format("Inspection.1.TrayInspection.FW.ContrastThreshold_2");
                    var tag = GetTag(nameTag);
                    if (tag != null)
                    {
                        InsightSetValue(tag.Location, (float)numContrastThresholdF.Value);
                    }
                    MessageLoggerManager.Log.Info(String.Format("[Action] Contrast Threshold F2 : " + (float)numContrastThresholdF.Value));
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void numAngleRangeF_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkSearchRegionF1)
                {
                    //Forward
                    string nameTag = string.Format("Inspection.1.TrayInspection.FW.AngleRange");
                    var tag = GetTag(nameTag);
                    if (tag != null)
                    {
                        InsightSetValue(tag.Location, (float)numAngleRangeF.Value);
                    }
                    MessageLoggerManager.Log.Info(String.Format("[Action] Angle Range F : " + (float)numAngleRangeF.Value));
                }
                else
                {
                    //Forward region 2
                    string nameTag = string.Format("Inspection.1.TrayInspection.FW.AngleRange_2");
                    var tag = GetTag(nameTag);
                    if (tag != null)
                    {
                        InsightSetValue(tag.Location, (float)numAngleRangeF.Value);
                    }
                    MessageLoggerManager.Log.Info(String.Format("[Action] Angle Range F : " + (float)numAngleRangeF.Value));
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void numScoreThresholdF_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkSearchRegionF1)
                {
                    //Foward
                    string nameTag = string.Format("Inspection.1.TrayInspection.FW.ScoreThreshold");
                    var tag = GetTag(nameTag);
                    if (tag != null)
                    {
                        InsightSetValue(tag.Location, (float)numScoreThresholdF.Value);
                    }
                    MessageLoggerManager.Log.Info(String.Format("[Action] Score Threshold F : " + (float)numScoreThresholdF.Value));
                }
                else
                {
                    //Foward Region 2
                    string nameTag = string.Format("Inspection.1.TrayInspection.FW.ScoreThreshold_2");
                    var tag = GetTag(nameTag);
                    if (tag != null)
                    {
                        InsightSetValue(tag.Location, (float)numScoreThresholdF.Value);
                    }
                    MessageLoggerManager.Log.Info(String.Format("[Action] Score Threshold F2 : " + (float)numScoreThresholdF.Value));
                }
            }
            catch (Exception ex)
            {

            }
        }


    }
}
