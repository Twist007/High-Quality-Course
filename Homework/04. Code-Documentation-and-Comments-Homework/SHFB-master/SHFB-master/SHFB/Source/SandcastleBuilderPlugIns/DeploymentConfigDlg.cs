//===============================================================================================================
// System  : Sandcastle Help File Builder Plug-Ins
// File    : DeploymentConfigDlg.cs
// Author  : Eric Woodruff  (Eric@EWoodruff.us)
// Updated : 05/03/2015
// Note    : Copyright 2007-2015, Eric Woodruff, All rights reserved
// Compiler: Microsoft Visual C#
//
// This file contains a form that is used to configure the settings for the Output Deployment plug-in
//
// This code is published under the Microsoft Public License (Ms-PL).  A copy of the license should be
// distributed with the code and can be found at the project website: https://GitHub.com/EWSoftware/SHFB.  This
// notice, the author's name, and all copyright notices must remain intact in all applications, documentation,
// and source files.
//
//    Date     Who  Comments
// ==============================================================================================================
// 09/24/2007  EFW  Created the code
// 07/05/2009  EFW  Added support for MS Help Viewer deployment
// 02/06/2012  EFW  Added support for renaming MSHA file
// 03/09/2014  EFW  Added support for Open XML deployment
// 04/03/2014  EFW  Added support for markdown content deployment
// 05/03/2015  EFW  Removed support for the MS Help 2 file format
//===============================================================================================================

using System;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

using Sandcastle.Core;

namespace SandcastleBuilder.PlugIns
{
    /// <summary>
    /// This form is used to configure the settings for the <see cref="DeploymentPlugIn"/>
    /// </summary>
    internal partial class DeploymentConfigDlg : Form
    {
        #region Private data members
        //=====================================================================

        private XmlDocument config;     // The configuration
        #endregion

        #region Properties
        //=====================================================================

        /// <summary>
        /// This is used to return the configuration information
        /// </summary>
        public string Configuration
        {
            get { return config.OuterXml; }
        }
        #endregion

        #region Constructor
        //=====================================================================

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="currentConfig">The current XML configuration XML fragment</param>
        public DeploymentConfigDlg(string currentConfig)
        {
            XPathNavigator navigator, root, msHelpViewer;
            string value;
            bool renameMSHA;

            InitializeComponent();

            lnkProjectSite.Links[0].LinkData = "https://GitHub.com/EWSoftware/SHFB";

            // Load the current settings
            config = new XmlDocument();
            config.LoadXml(currentConfig);
            navigator = config.CreateNavigator();

            root = navigator.SelectSingleNode("configuration");

            if(root.IsEmptyElement)
                return;

            value = root.GetAttribute("deleteAfterDeploy", String.Empty);

            if(!String.IsNullOrEmpty(value))
                chkDeleteAfterDeploy.Checked = Convert.ToBoolean(value, CultureInfo.InvariantCulture);

            value = root.GetAttribute("verboseLogging", String.Empty);

            if(!String.IsNullOrEmpty(value))
                chkVerboseLogging.Checked = Convert.ToBoolean(value, CultureInfo.InvariantCulture);

            // Get HTML Help 1 deployment information
            ucHtmlHelp1.LoadFromSettings(DeploymentLocation.FromXPathNavigator(root, "help1x"));

            // Get MS Help Viewer deployment information
            msHelpViewer = root.SelectSingleNode("deploymentLocation[@id='helpViewer']");

            if(msHelpViewer != null)
            {
                if(!Boolean.TryParse(msHelpViewer.GetAttribute("renameMSHA", String.Empty).Trim(), out renameMSHA))
                    renameMSHA = false;

                chkRenameMSHA.Checked = renameMSHA;
            }

            ucMSHelpViewer.LoadFromSettings(DeploymentLocation.FromXPathNavigator(root, "helpViewer"));

            // Get website deployment information
            ucWebsite.LoadFromSettings(DeploymentLocation.FromXPathNavigator(root, "website"));

            // Get Open XML deployment information
            ucOpenXml.LoadFromSettings(DeploymentLocation.FromXPathNavigator(root, "openXml"));

            // Get markdown content deployment information
            ucMarkdownContent.LoadFromSettings(DeploymentLocation.FromXPathNavigator(root, "markdown"));
        }
        #endregion

        #region Event handlers
        //=====================================================================

        /// <summary>
        /// Close without saving
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Go to the Sandcastle Help File Builder project site
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void lnkProjectSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start((string)e.Link.LinkData);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                MessageBox.Show("Unable to launch link target.  Reason: " + ex.Message, Constants.AppName,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Validate the configuration and save it
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            XmlAttribute attr;
            XmlNode root, mshv;
            DeploymentLocation htmlHelp1, msHelpViewer, website, openXml, markdown;
            bool isValid = false;

            epErrors.Clear();

            htmlHelp1 = ucHtmlHelp1.CreateDeploymentLocation();
            msHelpViewer = ucMSHelpViewer.CreateDeploymentLocation();
            website = ucWebsite.CreateDeploymentLocation();
            openXml = ucOpenXml.CreateDeploymentLocation();
            markdown = ucMarkdownContent.CreateDeploymentLocation();

            if(htmlHelp1 == null)
                tabConfig.SelectedIndex = 0;
            else
                if(msHelpViewer == null)
                    tabConfig.SelectedIndex = 2;
                else
                    if(website == null)
                        tabConfig.SelectedIndex = 3;
                    else
                        if(openXml == null)
                            tabConfig.SelectedIndex = 4;
                        else
                            if(markdown == null)
                                tabConfig.SelectedIndex = 5;
                            else
                                isValid = true;

            if(isValid && htmlHelp1.Location == null && msHelpViewer.Location == null &&
              website.Location == null && openXml.Location == null && markdown.Location == null)
            {
                tabConfig.SelectedIndex = 0;
                epErrors.SetError(chkDeleteAfterDeploy, "At least one help file format must have a target " +
                    "location specified");
                isValid = false;
            }

            if(!isValid)
                return;

            // Store the changes
            root = config.SelectSingleNode("configuration");
            attr = root.Attributes["deleteAfterDeploy"];

            if(attr == null)
            {
                attr = config.CreateAttribute("deleteAfterDeploy");
                root.Attributes.Append(attr);
            }

            attr.Value = chkDeleteAfterDeploy.Checked.ToString().ToLowerInvariant();

            attr = root.Attributes["verboseLogging"];

            if(attr == null)
            {
                attr = config.CreateAttribute("verboseLogging");
                root.Attributes.Append(attr);
            }

            attr.Value = chkVerboseLogging.Checked.ToString().ToLowerInvariant();

            htmlHelp1.ToXml(config, root, "help1x");
            msHelpViewer.ToXml(config, root, "helpViewer");
            website.ToXml(config, root, "website");
            openXml.ToXml(config, root, "openXml");
            markdown.ToXml(config, root, "markdown");

            mshv = root.SelectSingleNode("deploymentLocation[@id='helpViewer']");

            if(mshv != null)
            {
                attr = mshv.Attributes["renameMSHA"];

                if(attr == null)
                {
                    attr = config.CreateAttribute("renameMSHA");
                    mshv.Attributes.Append(attr);
                }

                attr.Value = chkRenameMSHA.Checked.ToString().ToLowerInvariant();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion
    }
}
