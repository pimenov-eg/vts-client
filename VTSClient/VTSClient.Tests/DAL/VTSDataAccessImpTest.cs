using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using VTSClient.DAL;
using VTSClient.Services.VTSService.Entities;

namespace VTSClient.Tests.DAL
{
    public class VTSDataAccessImpTest : VTSDataAccessImpBase
    {
        protected override string DbPath
        {
            get => Environment.CurrentDirectory;
        }
    }
}