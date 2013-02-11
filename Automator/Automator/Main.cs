#region | Usings |
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using AutoItHelper;
//----------------------------------------------------------------------
#endregion

namespace Automator
{
    public partial class Main : Form
    {
        #region | Member Variables |
        //----------------------------------------------------------------------
        static Thread _thread;
        bool _IsThreadRunning = false;

        DateTime _datetimeStart = new DateTime();
        DateTime _datetimeEnd = new DateTime();
        int _iKeyCount;
        //----------------------------------------------------------------------
        #endregion

        #region | Events |

        ///----------------------------------------------------------------------
        /// <summary>
        /// Handles the Load event of the Main control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        ///----------------------------------------------------------------------
        private void Main_Load(object sender, EventArgs e)
        {
            //----------------------------------------------------------------------
            // Set the status
            //----------------------------------------------------------------------
            SetStatus("Click START to Begin Automation.");
        }

        ///----------------------------------------------------------------------
        /// <summary>
        /// Handles the Click event of the buttonStart control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        ///----------------------------------------------------------------------
        private void buttonStart_Click(object sender, EventArgs e)
        {
            //----------------------------------------------------------------------
            // Check that only one instance of the thread is running at a time
            //----------------------------------------------------------------------
            if (_IsThreadRunning)
            {
                return;
            }

            //----------------------------------------------------------------------
            // Run the DEPlayer AutoIt simulation
            //----------------------------------------------------------------------
            _thread = new Thread(RunAutomation);
            _thread.Start();

            //----------------------------------------------------------------------
            // Set the status
            //----------------------------------------------------------------------
            SetStatus("Start...");

            //----------------------------------------------------------------------
            // Found through testing that it seems that we need to initiate a 
            //  tooltip before spawning the thread - if we don't then the tooltip
            //  messages later on - do not show.  By doing this however, they 
            //  work perfectly.
            //----------------------------------------------------------------------
            //SetTooltip("");
        }

        ///----------------------------------------------------------------------
        /// <summary>
        /// Handles the Click event of the buttonQuit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        ///----------------------------------------------------------------------
        private void buttonQuit_Click(object sender, EventArgs e)
        {
            //----------------------------------------------------------------------
            // Close this application
            //----------------------------------------------------------------------
            this.Close();
        }

        ///----------------------------------------------------------------------
        /// <summary>
        /// Handles the Click event of the buttonSaveSettings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        ///----------------------------------------------------------------------
        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            //----------------------------------------------------------------------
            // Save the User settings
            //----------------------------------------------------------------------
            SaveUserSettings();
        }

        ///----------------------------------------------------------------------
        /// <summary>
        /// Handles the Click event of the buttonUndoChanges control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        ///----------------------------------------------------------------------
        private void buttonUndoChanges_Click(object sender, EventArgs e)
        {
            //----------------------------------------------------------------------
            // Load the User settings
            //----------------------------------------------------------------------
            LoadUserSettings();

            //----------------------------------------------------------------------
            // Set the status
            //----------------------------------------------------------------------
            SetStatus("Settings Re-loaded...");
        }

        ///----------------------------------------------------------------------
        /// <summary>
        /// Handles the FormClosing event of the Main control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
        ///----------------------------------------------------------------------
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //----------------------------------------------------------------------
            // Kill the thread just in case it is still running
            //----------------------------------------------------------------------
            if (_thread != null)
            {
                _thread.Abort();
            }
        }

        #endregion

        #region | Public Methods |

        ///----------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        ///----------------------------------------------------------------------
        public Main()
        {
            InitializeComponent();

            //----------------------------------------------------------------------
            // Load the User settings
            //----------------------------------------------------------------------
            LoadUserSettings();
        }

        #endregion

        #region | Private Methods |

        ///----------------------------------------------------------------------
        /// <summary>
        /// Loads the user settings.
        /// </summary>
        ///----------------------------------------------------------------------
        private void LoadUserSettings()
        {
            //----------------------------------------------------------------------
            // Lookup the control values from the User settings
            //----------------------------------------------------------------------
            textboxDelayKeyEntry.Text = Properties.Settings.Default.DelayKeyEntry.ToString();
            textboxDelayButton.Text = Properties.Settings.Default.DelayButton.ToString();
            textboxMaxStringLen.Text = Properties.Settings.Default.MaxStringLen.ToString();
        }

        ///----------------------------------------------------------------------
        /// <summary>
        /// Saves the user settings.
        /// </summary>
        ///----------------------------------------------------------------------
        private void SaveUserSettings()
        {
            //----------------------------------------------------------------------
            // Get the current User settings from controls
            //----------------------------------------------------------------------
            Properties.Settings.Default.DelayKeyEntry = Convert.ToInt32(textboxDelayKeyEntry.Text);
            Properties.Settings.Default.DelayButton = Convert.ToInt32(textboxDelayButton.Text);
            Properties.Settings.Default.MaxStringLen = Convert.ToInt32(textboxMaxStringLen.Text);

            //----------------------------------------------------------------------
            // Save the user settings
            //----------------------------------------------------------------------
            Properties.Settings.Default.Save();

            //----------------------------------------------------------------------
            // Set the status
            //----------------------------------------------------------------------
            SetStatus("Settings have been saved.");
        }

        ///----------------------------------------------------------------------
        /// <summary>
        /// Sets the status
        /// </summary>
        /// <param name="sMessage">The s message.</param>
        ///----------------------------------------------------------------------
        private void SetStatus(string vsMessage)
        {
            //----------------------------------------------------------------------
            // Set the status label -- Thread safe delegate
            //----------------------------------------------------------------------
            labelStatus.Invoke((MethodInvoker)delegate()
                { labelStatus.Text = vsMessage; }, null);

            //----------------------------------------------------------------------
            // Set the tooltip
            //----------------------------------------------------------------------
            AutoItX.ToolTip(vsMessage);
        }

        #endregion

        #region | AutoIt Private Methods |

        ///----------------------------------------------------------------------
        /// <summary>
        /// Automate the DE Player simulation
        /// </summary>
        ///----------------------------------------------------------------------
        private void RunAutomation()
        {
            //----------------------------------------------------------------------
            // Initialize variables
            //----------------------------------------------------------------------
            _iKeyCount = 0;
            _IsThreadRunning = true;

            //----------------------------------------------------------------------
            // Set the status
            //----------------------------------------------------------------------
            SetStatus("Running...");

            //----------------------------------------------------------------------
            // Set the AutoIt options
            //----------------------------------------------------------------------
            AutoItX.SetOptions(true, Convert.ToInt32(textboxDelayKeyEntry.Text));

            //----------------------------------------------------------------------
            // Start the application
            //----------------------------------------------------------------------
            StartApplication();

            //----------------------------------------------------------------------
            // Start the timer
            //----------------------------------------------------------------------
            _datetimeStart = DateTime.Now;
            textboxTimeStart.Invoke((MethodInvoker)delegate()
                { textboxTimeStart.Text = _datetimeStart.ToLongTimeString(); }, null);

            //----------------------------------------------------------------------
            // Automate Notepad
            //----------------------------------------------------------------------
            RunNotepad();

            //----------------------------------------------------------------------
            // Get the end time
            //----------------------------------------------------------------------
            _datetimeEnd = DateTime.Now;

            //----------------------------------------------------------------------
            // Do calculations / formatting
            //----------------------------------------------------------------------
            TimeSpan ts = _datetimeEnd - _datetimeStart;

            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}",
                ts.Hours, ts.Minutes, ts.Seconds);

            double dTotalSeconds = ts.TotalSeconds;

            float fTotalSeconds = (float)dTotalSeconds;

            float fKeyPerSecond = _iKeyCount / fTotalSeconds;

            float fKeyPerMin = fKeyPerSecond * 60;

            float fKeyPerHour = fKeyPerMin * 60;

            //----------------------------------------------------------------------
            // Write values to the textbox controls - Invoke to be thread safe
            //----------------------------------------------------------------------
            textboxTimeEnd.Invoke((MethodInvoker)delegate()
                { textboxTimeEnd.Text = _datetimeEnd.ToLongTimeString(); }, null);
            
            textboxTimeElapsed.Invoke((MethodInvoker)delegate()
                { textboxTimeElapsed.Text = elapsedTime; }, null);

            textboxKeyTotal.Invoke((MethodInvoker)delegate()
                { textboxKeyTotal.Text = _iKeyCount.ToString(); }, null);

            textboxKeyMetrics.Invoke((MethodInvoker)delegate()
                { textboxKeyMetrics.Text = string.Format("{0:0}/s, {1:0}/m, {2:0}/h", fKeyPerSecond, fKeyPerMin, fKeyPerHour); }, null);

            //----------------------------------------------------------------------
            // Set the status
            //----------------------------------------------------------------------
            SetStatus("Automation Complete!");

            _IsThreadRunning = false;
        }

        ///----------------------------------------------------------------------
        /// <summary>
        /// Starts the application.
        /// </summary>
        ///----------------------------------------------------------------------
        private static void StartApplication()
        {
            //----------------------------------------------------------------------
            // Run the specified application
            //----------------------------------------------------------------------
            AutoItX.Run("notepad.exe");
        }

        ///----------------------------------------------------------------------
        /// <summary>
        /// Pause before clicking next button
        /// </summary>
        ///----------------------------------------------------------------------
        private void NextActionDelay()
        {
            AutoItX.Sleep(Convert.ToInt32(textboxDelayButton.Text));
        }

        ///----------------------------------------------------------------------
        /// <summary>
        /// Sends key commands.
        /// </summary>
        /// <param name="vText">The text.</param>
        ///----------------------------------------------------------------------
        private void SendKeys(string vsText)
        {
            //----------------------------------------------------------------------
            // Truncate string length if longer than max
            //----------------------------------------------------------------------
            if (vsText.Length >  Convert.ToInt32(textboxMaxStringLen.Text))
            {
                vsText = vsText.Substring(0, Convert.ToInt32(textboxMaxStringLen.Text));
            }

            //----------------------------------------------------------------------
            // Send the command text
            //----------------------------------------------------------------------
            AutoItX.Send(vsText);

            //----------------------------------------------------------------------
            // Count the number of keys
            //----------------------------------------------------------------------
            _iKeyCount += vsText.Length;
        }

        #endregion

        #region | Example Code |

        ///----------------------------------------------------------------------
        /// <summary>
        /// Runs the notepad example
        /// </summary>
        ///----------------------------------------------------------------------
        private void RunNotepad()
        {
            //----------------------------------------------------------------------
            // Wait for initial window
            //----------------------------------------------------------------------
            AutoItX.WinWaitActiveWindow("Untitled - Notepad");

            //----------------------------------------------------------------------
            // Move and Resize the window
            //----------------------------------------------------------------------
            NextActionDelay();
            SetStatus("Move and Resize Window...");
            AutoItX.WinMove("Untitled - Notepad", 100, 100, 500, 400);
            NextActionDelay();
            AutoItX.WinMove("Untitled - Notepad", 0, 100, 600, 500);

            //----------------------------------------------------------------------
            // Now that the Notepad window is active type some text
            //----------------------------------------------------------------------
            SetStatus("Typing...");
            SendKeys("This is a test of the AUTOMATOR.{ENTER}You will be AUTOMATED.{ENTER}");
            NextActionDelay();
            SendKeys("+{UP 2}");
            NextActionDelay();

            //----------------------------------------------------------------------
            // Get the text from the window and show tooltip
            //----------------------------------------------------------------------
            string sText = AutoItX.WinGetText("Untitled - Notepad");
            AutoItX.ToolTip(string.Format("Text From Window: \"{0}\"", sText.Replace("\r", "").Replace("\n", "")));
            AutoItX.Sleep(3000);

            //----------------------------------------------------------------------
            // Move the mouse around
            //----------------------------------------------------------------------
            SetStatus("Moving the Mouse...");
            AutoItX.MouseMove(0, 0, 50);
            AutoItX.MouseMove(300, 300, 50);
            AutoItX.MouseMove(600, 300, 50);
            NextActionDelay();

            //----------------------------------------------------------------------
            // Set message
            //----------------------------------------------------------------------
            SetStatus("Closing Notepad...");

            //----------------------------------------------------------------------
            // Now quit by pressing Alt-f and then x (File menu -> Exit)
            //----------------------------------------------------------------------
            NextActionDelay();
            SendKeys("!f");
            NextActionDelay();
            SendKeys("x");

            //----------------------------------------------------------------------
            // Now a screen will pop up and ask to save the changes, the window is 
            //  called "Notepad" and has some text "Yes" and "No"
            //----------------------------------------------------------------------
            AutoItX.WinWaitActiveWindow("Notepad");
            SendKeys("n");

            //----------------------------------------------------------------------
            // Set message
            //----------------------------------------------------------------------
            SetStatus("Automation Complete!");
        }

        #endregion
    }
}