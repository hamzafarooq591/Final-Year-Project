namespace NashWebApi.Constant
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class NashConstants
    {
        public static class AzureBlobStorage
        {
            public const string CompaniesContainerName = "companies";
            public const string DefaultFilessContainerName = "default-files";
            public const string DefaultImagesContainerName = "default-images";
            public const string ImagesContainerName = "images";
            public const string NashCallRecordingsContainerName = "Nash-call-recordings";
            public const string NashEmailAttachmentsContainerName = "Nash-email-attachments";
            public const string StorageContainerName = "storage";
            public const string WelcomeEmailImagesContainerName = "images/welcome-email/";
        }

        public static class ErrorMessages
        {
            public const string CommentsAreNotAllowed = "Comments are not allowed";
            public const string EntityOwnershipError = "This Entity Is Not Associated with Your Account";
            public const string InvalidCommentSetting = "Invalid Comment Setting";
            public const string InvalidEntityType = "Invalid EntityType";
            public const string NoSeatsAvailable = "No Seats Available";
            public const string PutIdNotEqual = "The url id and model id does not match";
            public const string StageIdCannotBeNull = "Stage Id Cannot Be Null";
        }

        public static class Globals
        {
            public static TimeSpan AccessTokenExpirationTimeSpan = TimeSpan.FromDays(7.0);
            public static string[] BindingDateTimeFormat = new string[] { "yyyy-MM-dd", "yyyy-MM-ddTHH:mm" };
            public const int ContentMaxLength = 100;
            public const string DateFormat = "MM/dd/yyyy";
            public const string DateTimeFormat = "MM/dd/yyyy hh:mm tt";
            public const string DefaultAccountImage = "Images/fileManager/Add_Logo.svg";
            public const string DefaultContactImage = "Images/person.png";
            public const string DefaultTeamImage = "Images/fileManager/Add_Team_Logo.png";
            public const int ExpiryDays = 60;
            public static readonly List<int> NashCEONotificationDays;
            [DecimalConstant(0, 0, (uint) 0, (uint) 0, (uint) 10)]
            public static readonly decimal PartnersPercentage = 10M;
            public const string PartnersSubDomain = "partners";
            public const int ReplacementInt = 0;
            public const string ReplacementString = "";
            public const int SubscriptionInvoiceDueDays = 5;
            public const string TimeFormat = "hh:mm tt";
            public const int TrialDays = 14;
            public const int SessionDuration = 300;

            static Globals()
            {
                List<int> list1 = new List<int> { 
                    1,
                    7,
                    14
                };
                NashCEONotificationDays = list1;
            }
        }

        public static class Integrations
        {
            public const string GoogleAppName = "Nash App";
            public const string GoogleDefaultGroupName = "System Group: My Contacts";
            public const string GoogleDefaultTagName = "imported-from-google";
        }

        public static class TwilioProfitMargin
        {
            private const double PhoneNumber = 10.0;

            public static double AddPhoneNumberProfitMarging(double basePrice) => 
                (basePrice + ((basePrice * 10.0) / 100.0));
        }
    }
}

