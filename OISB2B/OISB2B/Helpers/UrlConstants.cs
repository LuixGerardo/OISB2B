using System;
using System.Collections.Generic;
using System.Text;

namespace OISB2B.Helpers
{
    public static class UrlConstants
    {
        #region Integracion OIS
        public const string ServicioOIS = "https://www.oisimobile.com/BETAWC/";

        public const string GenerateKeyOIS = "https://www.oiscentral.com/oisc/api/Crypto/key";
        public const string GetUserListOIS = "https://www.oisimobile.com/OISWC/Config.svc/UserList";


        public const string LoginOIS = "Config.svc/Config";
        #endregion

        //TenantId Admin
        //public const string AppType = "Pro";
        public const string AppType = "Basic";

        public const string TitlePro = "OIS Pro";
        public const string TitleBasic = "OIS Basic";

    }
}
