using System;
using PX.Data;


namespace PX.Objects.MobiPunch
{
    public class TimePunchedAttribute : PXIntAttribute,
                                        IPXFieldSelectingSubscriber
    {
        public static DateTime PunchDateTime => DateTime.Now; //PX.Common.PXTimeZoneInfo.Now;

        private Type _PunchInDateTime;
        private Type _PunchOutDateTime;

        public TimePunchedAttribute(Type punchInDateTime, Type punchOutDateTime) : this(punchInDateTime)
        {
            _PunchOutDateTime = punchOutDateTime;
        }

        public TimePunchedAttribute(Type punchInDateTime) : base()
        {
            _PunchInDateTime = punchInDateTime;
        }

        public override void FieldSelecting(PXCache sender, PXFieldSelectingEventArgs e)
        {
            if (e.Row == null)
            {
                return;
            }

            var punchInDateTimeValue = sender.GetValue(e.Row, _PunchInDateTime.Name) as DateTime?;

            if (punchInDateTimeValue == null)
            {
                return;
            }

            var punchOutDateTimeValue = _PunchOutDateTime != null
                ? (sender.GetValue(e.Row, _PunchOutDateTime.Name) as DateTime? ?? PunchDateTime)
                : PunchDateTime;

            e.ReturnValue = GetTimeBetween(punchInDateTimeValue, punchOutDateTimeValue);
        }

        protected virtual int GetTimeBetween(DateTime? startDateTime, DateTime? endDateTime)
        {
            if (startDateTime == null || endDateTime == null || !StartBeforeEnd(startDateTime.GetValueOrDefault(), endDateTime.GetValueOrDefault()))
            {
                return 0;
            }

            TimeSpan? timeSpan = endDateTime.GetValueOrDefault() - startDateTime.GetValueOrDefault();
            return Convert.ToInt32(timeSpan.Value.TotalMinutes);
        }

        public static bool StartBeforeEnd(DateTime startDateTime, DateTime endDateTime)
        {
            return DateTime.Compare(startDateTime, endDateTime) <= 0;
        }
    }
}