using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cap_Register.Views.FlyoutAdmin
{
    public class FlyoutAdminFlyoutMenuItem
    {
        public FlyoutAdminFlyoutMenuItem()
        {
            TargetType = typeof(FlyoutAdminFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}