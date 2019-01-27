using System;
using System.Collections;
using System.Collections.Generic;
using PX.SM;
using PX.Data;


namespace PX.Objects.MobiPunch
{
    public class TimePunchedAttribute : PXIntAttribute,
                                        IPXFieldSelectingSubscriber
    {
        private Type _PunchInDateTime;
        public TimePunchedAttribute(Type punchInDateTime) : base()
        {
            _PunchInDateTime = punchInDateTime;
        }

        public override void FieldSelecting(PXCache sender, PXFieldSelectingEventArgs e)
        {
            if (e.Row == null) return;

            //string screenID = sender.GetValue(e.Row, _PunchInDateTime.Name) as string;
            //if (!string.IsNullOrEmpty(screenID))
            //{
            //    var siteMapNode = PXSiteMap.Provider.FindSiteMapNodeByScreenID(screenID);
            //    if (siteMapNode != null)
            //    {
            //        e.ReturnValue = siteMapNode.Title;
            //    }
            //}
        }
    }
}