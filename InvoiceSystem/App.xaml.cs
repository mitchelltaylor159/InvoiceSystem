﻿using InvoiceSystem.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace InvoiceSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public void Application_Startup(object sender, StartupEventArgs e)
        {
            AppController Controller = new AppController();
        }
    }
}
