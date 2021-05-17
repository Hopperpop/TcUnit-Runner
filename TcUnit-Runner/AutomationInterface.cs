﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCatSysManagerLib;

namespace TcUnit.TcUnit_Runner
{
    /// <summary>
    /// This class provides the functionality to access the TwinCAT automation interface, which
    /// is a complement to the VS DTE and that gives access to certain TwinCAT specific functions
    /// integrated into Visual Studio
    /// </summary>
    class AutomationInterface
    {
        private ITcSysManager14 sysManager = null;
        private ITcConfigManager configManager = null;
        private ITcSmTreeItem plcTreeItem = null;
        private ITcSmTreeItem routesTreeItem = null;
        private ITcSmTreeItem realTimeTasksTreeItem = null;
        //private ITcSmTreeItem testTreeItem = null;

        public AutomationInterface(EnvDTE.Project project)
        {
            sysManager = (ITcSysManager14)project.Object;
            configManager = (ITcConfigManager)sysManager.ConfigurationManager;
            plcTreeItem = sysManager.LookupTreeItem(Constants.PLC_CONFIGURATION_SHORTCUT);
            routesTreeItem = sysManager.LookupTreeItem(Constants.RT_CONFIG_ROUTE_SETTINGS_SHORTCUT);
            realTimeTasksTreeItem = sysManager.LookupTreeItem(Constants.REAL_TIME_CONFIGURATION_ADDITIONAL_TASKS);
        }



        public AutomationInterface(VisualStudioInstance vsInst) : this(vsInst.GetProject())
        { }

        public ITcSysManager14 ITcSysManager
        {
            get
            {
                return this.sysManager;
            }
        }

        public ITcSmTreeItem PlcTreeItem
        {
            get
            {
                return this.plcTreeItem;
            }
        }

        public ITcSmTreeItem RealTimeTasksTreeItem
        {
            get
            {
                return this.realTimeTasksTreeItem;
            }
        }

        public ITcSmTreeItem RoutesTreeItem
        {
            get
            {
                return this.routesTreeItem;
            }
        }

        public string ActiveTargetPlatform
        {
            set
            {
                this.configManager.ActiveTargetPlatform = value;
            }
            get
            {
                return this.configManager.ActiveTargetPlatform;
            }
        }

        public string TargetNetId
        {
            set
            {
                this.sysManager.SetTargetNetId(value);
            }
            get
            {
                return sysManager.GetTargetNetId();
            }
        }

        public void ActivateConfiguration()
        {
            sysManager.ActivateConfiguration();
        }

        public void StartRestartTwinCAT()
        {
            sysManager.StartRestartTwinCAT();
        }
    }
}
