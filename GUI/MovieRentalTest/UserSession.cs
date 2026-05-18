namespace MovieRentalTest
{
    public static class UserSession
    {
        public static int CustomerID { get; private set; }
        public static int MemberShipID { get; private set; }
        public static string UserName { get; private set; }
        public static bool IsAdmin { get; private set; }
        public static bool IsLoggedIn => CustomerID > 0 || (IsAdmin && !string.IsNullOrEmpty(UserName));

        public static void Login(int customerId, int memberShipId, string userName, bool isAdmin)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("Username cannot be empty");

            CustomerID = customerId;
            MemberShipID = memberShipId;
            UserName = userName;
            IsAdmin = isAdmin;
        }

        public static void Logout()
        {
            CustomerID = 0;
            MemberShipID = 0;
            UserName = string.Empty;
            IsAdmin = false;
        }
    }
}