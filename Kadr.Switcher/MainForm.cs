﻿using Asbt.Utils;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace dotSwitcher
{
    public class SysTrayApp : Form
    {
        private Switcher engine;
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        private MenuItem power;
        private Settings settings;

        public SysTrayApp(Switcher engine)
        {            
            this.engine = engine;
            InitSettings();

            CRegistry.SetAutoRun();

            trayMenu = new ContextMenu();
            power = new MenuItem("", OnPower);
            trayMenu.MenuItems.Add(power);
            trayMenu.MenuItems.Add("Созлаш", OnSettings);
            trayMenu.MenuItems.Add("-");
            trayMenu.MenuItems.Add("Ёпиш", OnExit);
            
            trayIcon = new NotifyIcon();
            trayIcon.Text = "dotSwitcher";
            trayIcon.Icon = Asbt.Switcher.Properties.Resources.icon;

            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
            
        }

        private void InitSettings()
        {
            settings = new Settings();
            settings.Reload();
            if (settings.SwitchHotkey.KeyData == Keys.None)
            {
                settings.SwitchHotkey = new KeyboardEventArgs(Keys.Pause, false);
            }
            SaveSettings();
        }

        private void SaveSettings()
        {
            engine.SwitchHotkey = settings.SwitchHotkey;
            settings.Save();
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;

            engine.Error += OnEngineError;
            engine.Start();
            UpdateMenu();
            base.OnLoad(e);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            engine.Error -= OnEngineError;
            base.OnClosing(e);
        }

        private void OnEngineError(object sender, SwitcherErrorArgs args)
        {
            var ex = args.Error;
            trayIcon.ShowBalloonTip(2000, "dotSwitcher error", ex.ToString(), ToolTipIcon.None);
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UpdateMenu()
        {
            power.Text = engine.IsStarted() ? "Тўхтатиш" : "Ишлатиш";
        }

        private void OnPower(object sender, EventArgs e)
        {
            if (engine.IsStarted()) { engine.Stop(); }
            else { engine.Start(); }
            UpdateMenu();
        }

        private void OnSettings(object sender, EventArgs e)
        {
            engine.Stop();
            var settingsForm = new SettingsForm(settings);
            settingsForm.FormClosed += (a, b) => engine.Start();
            var result = settingsForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                SaveSettings();
            }
            else
            {
                settings.Reload();
            }
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                trayIcon.Dispose();
            }
            base.Dispose(isDisposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SysTrayApp));
            this.SuspendLayout();
            // 
            // SysTrayApp
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SysTrayApp";
            this.ResumeLayout(false);

        }
    }
}
