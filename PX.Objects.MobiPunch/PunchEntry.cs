using System;
using System.Collections;
using System.Collections.Generic;
using PX.SM;
using PX.Data;


namespace PX.Objects.MobiPunch
{
    public class PunchEntry : PXGraph<PunchEntry, PunchEmployee>
    {
        public PXSelect<PunchEmployee> Document;
    }
}