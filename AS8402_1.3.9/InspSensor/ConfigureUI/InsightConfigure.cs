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
using InspSensor.Utility;
using Cognex.InSight;

namespace InspSensor.ConfigureUI
{
    public partial class InsightConfigure : UserControl
    {
        private CvsInSightDisplay mCvsInsightDisplay = null;

        public InsightConfigure(CvsInSightDisplay insightDisplay): base()
        {
            InitializeComponent();
            mCvsInsightDisplay = insightDisplay;

            cbNumPanel.SelectedIndex = 0;

            if (insightDisplay.Connected)
            {
                UpdateParam();
            }
        }
        public void UpdateParam()
        {
            try
            {
                var tag = GetTag(ResourceUtility.GetString("RtInspPanelThreshold"));
                if (tag != null)
                {
                    float threshold = (float)GetValue(tag.Location);
                    nudPanelInspThreshold.Value = (decimal)threshold;
                }

                tag = GetTag(ResourceUtility.GetString("RtInspPanelShowgraphic"));
                if (tag != null)
                {
                    int showGraphic = (int)GetValue(tag.Location);
                    nudPanelInspShowGraphic.Value = (decimal)showGraphic;
                }

                tag = GetTag(ResourceUtility.GetString("RtInspTrayThreshold"));
                if (tag != null)
                {
                    float threshTray = (float)GetValue(tag.Location);
                    nudTrayInspThreshold.Value = (decimal)threshTray;
                }

                tag = GetTag(ResourceUtility.GetString("RtAlignmentPatmaxSorting"));
                if (tag != null)
                {
                    int iSort = (int)GetValue(tag.Location);
                    cbPatmaxSorting.SelectedIndex = iSort - 1;
                }
            }
            catch (Exception ex)
            {

            }
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
            return null;
        }
    }
}
