// Deze broncode is openbaar gemaakt vanwege een Woo-verzoek zodat deze 
// gericht is op transparantie en niet op hergebruik. Hergebruik van 
// de broncode is toegestaan onder de EUPL licentie, met uitzondering 
// van broncode waarvoor een andere licentie is aangegeven.
//
// Het archief waar dit bestand deel van uitmaakt is te vinden op:
//   https://github.com/MinBZK/woo-besluit-broncode-digid-app
//
// Eventuele kwetsbaarheden kunnen worden gemeld bij het NCSC via:
//   https://www.ncsc.nl/contact/kwetsbaarheid-melden
// onder vermelding van "Logius, openbaar gemaakte broncode DigiD-App" 
//
// Voor overige vragen over dit Woo-besluit kunt u mailen met open@logius.nl
//
// This code has been disclosed in response to a request under the Dutch
// Open Government Act ("Wet open Overheid"). This implies that publication 
// is primarily driven by the need for transparence, not re-use.
// Re-use is permitted under the EUPL-license, with the exception 
// of source files that contain a different license.
//
// The archive that this file originates from can be found at:
//   https://github.com/MinBZK/woo-besluit-broncode-digid-app
//
// Security vulnerabilities may be responsibly disclosed via the Dutch NCSC:
//   https://www.ncsc.nl/contact/kwetsbaarheid-melden
// using the reference "Logius, publicly disclosed source code DigiD-App" 
//
// Other questions regarding this Open Goverment Act decision may be
// directed via email to open@logius.nl
//
﻿using System;
using System.Collections.Generic;
using DigiD.Common.Enums;
using DigiD.Common.Models;
using Xamarin.Forms;

namespace DigiD.Common.Constants
{
    public static class AppConfigConstants
    {
        private const string iOSPublicFile = "SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS"; //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
        private const string AndroidPublicFile = "SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS"; //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS

        public const string A11YEffectGroupName = "DigiD.A11Y.Effect";

        internal const string HostKey = "SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS";
        internal const string PinKey = "SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS";
        internal static readonly ObfuscatedString PublicFileUrl = new ObfuscatedString(HostKey, Device.RuntimePlatform == Device.Android ? AndroidPublicFile : iOSPublicFile);

        public static ReleaseType ReleaseType => ReleaseType.Productie;
        public static TimeSpan DefaultHttpTimeout => TimeSpan.FromSeconds(60);
        public static TimeSpan SessionTimeout { get; set; } = TimeSpan.FromSeconds(120);
        public static TimeSpan DisplayLockTimeout { get; set; } = TimeSpan.FromSeconds(60);

        public static readonly IReadOnlyList<ObfuscatedString> HostWhiteList = new List<ObfuscatedString>
        {
#if PROD
            new ObfuscatedString(HostKey, "SSSSSSSSSSSS"), //digid.nl
#elif PREPROD
            new ObfuscatedString(HostKey, "SSSSSSSSSSSS"), //digid.nl
            new ObfuscatedString(HostKey, "SSSSSSSSSSSSSSSSSSSSSSSS"), //SSSSSSSSSSSSSSSSS
            new ObfuscatedString(HostKey, "SSSSSSSSSSSSSSSSSSSSSSSS"), //SSSSSSSSSSSSSSSSS
#else
            new ObfuscatedString(HostKey, "SSSSSSSSSSSS"), //digid.nl
            new ObfuscatedString(HostKey, "SSSSSSSSSSSSSSSSSSSSSSSS"), //SSSSSSSSSSSSSSSSS
            new ObfuscatedString(HostKey, "SSSSSSSSSSSSSSSSSSSSSSSS"), //SSSSSSSSSSSSSSSSS
            new ObfuscatedString(HostKey, "SSSSSSSSSSSSSSSS"), //SSSSSSSSSSS
            new ObfuscatedString(HostKey, "SSSSSSSSSSSSSSSS"), //SSSSSSSSSSS
            new ObfuscatedString(HostKey, "SSSSSSSSSSSSSSSS"), //SSSSSSSSSSS
            new ObfuscatedString(HostKey, "SSSSSSSSSSSSSSSS"), //SSSSSSSSSSS
            new ObfuscatedString(HostKey, "SSSSSSSSSSSSSSSS"), //SSSSSSSSSSS
            new ObfuscatedString(HostKey, "SSSSSSSSSSSSSSSS"), //SSSSSSSSSSS
            new ObfuscatedString(HostKey, "SSSSSSSSSSSSSSSS"), //SSSSSSSSSSS
            new ObfuscatedString(HostKey, "SSSSSSSSSSSSSSSS"), //SSSSSSSSSSS
            new ObfuscatedString(HostKey, "SSSSSSSSSSSSSSSS"), //SSSSSSSSSSS
            new ObfuscatedString(HostKey, "SSSSSSSSSSSSSSSS"), //SSSSSSSSSSS
            new ObfuscatedString(HostKey, "SSSSSSSSSSSSSSSS"), //SSSSSSSSSSS
            new ObfuscatedString(HostKey, "SSSSSSSSSSSSSSSSSSSS"), //SSSSSSSSSSSSSSS
#endif
        };

        //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
        internal static List<string> Exclusions { get; } = new List<string>
        {
            "SSSSSSSSSSSSSSS",
            "SSSSSSSSSSSSSSSSS",
            "SSSSSSSSSSSSSSSS",
            "SSSSSSSSSSSSSSS",
            "SSSSSSSSSSSSSSS",
            "SSSSSSSSSSSSSSS",
            "SSSSSSSSSSSSSSS",
            "SSSSSSSSSSSSSSS",
            "SSSSSSSSSSSSSSS",
            "SSSSSSSSSSSSSSS",
            "SSSSSSSSSSSSSSS",
            "SSSSSSSSSSSSSSS",
            "SSSSSSSSSSSSSSS",
        };

#if PROD
        public static readonly ObfuscatedString PiwikBaseUrl = new ObfuscatedString(HostKey, "SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS"); //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
#else
        public static readonly ObfuscatedString PiwikBaseUrl = new ObfuscatedString(HostKey, "SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS"); //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
#endif

        public const int QRCodeValidationTime = 15;
        public const int RatingLimit = 5;
    }
}
