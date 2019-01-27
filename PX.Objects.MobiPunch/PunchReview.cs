using PX.Data;

namespace PX.Objects.MobiPunch
{
    public class PunchReview : PXGraph<PunchReview>
    {
        public PXCancel<PunchEmployee> Cancel;

        public PXFilter<PunchEmployee> Filter;

        [PXFilterable]
        public PXSelect<
            PunchEmployeeActivity, 
            Where<PunchEmployeeActivity.employeeID, Equal<Current<PunchEmployee.employeeID>>,
                Or<Current<PunchEmployee.employeeID>, IsNull>>> EmployeeActivity;
    }
}