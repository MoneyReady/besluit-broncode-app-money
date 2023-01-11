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
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using DigiD.Common.NFC.Enums;
using DigiD.Common.Services;
using DigiD.Common.SessionModels;
using Xamarin.Forms;

namespace DigiD.Common.Helpers
{
    public static class StringHelper
    {
        public static DateTime ToDate(this string input)
        {
            try
            {
                return DateTime.Parse(input, CultureInfo.DefaultThreadCurrentCulture);
            }
            catch (Exception e)
            {
                var props = new Dictionary<string, string>
                {
                    { "input", input },
                    { "locale", CultureInfo.DefaultThreadCurrentCulture.Name}
                };
                AppCenterHelper.TrackError(e, props);

                return DateTime.MinValue;
            }
        }
        public static string StripHtml(this string text)
        {
            const string subst = "<[^>]*>";
            var result = text != null ? Regex.Replace(text, subst, string.Empty) : "";
            return result;
        }

        public static Uri ToUri(this string path)
        {
            return new Uri(HttpSession.HostName + path);
        }

        public static string ChangeForA11y(this string text)
        {
            if (!DependencyService.Get<IA11YService>().IsInVoiceOverMode() || text == null)
                return text;

            string result;
            if (text.EndsWith(" "))
                result = text.TrimEnd();
            else
                result = text + " ";

            return result.StripHtml();
        }

        public static string Translate(this DocumentType documentType)
        {
            switch (documentType)
            {
                case DocumentType.DrivingLicense:
                    return AppResources.DrivingLicense;
                case DocumentType.IDCard:
                    return AppResources.IDCard;
                case DocumentType.Passport:
                    return AppResources.Passport;
                default:
                    return AppResources.eID;
            }
        }

        public static byte[] GetBytes(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        public static byte[] Hash(this string str)
        {
            using var hash = new SHA256Managed();
            return hash.ComputeHash(Encoding.UTF8.GetBytes(str));
        }

        public static byte[] FromBase16(this string hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper(CultureInfo.InvariantCulture) + input.Substring(1);
            }
        }

        public static string ReplaceEmoticons(this string text)
        {
            return Regex.Replace(text, @"[^\u0000-\u007F]+", "?");
        }

        public static bool TryGetFromBase64String(string input, out byte[] output)
        {
            output = null;
            try
            {
                output = Convert.FromBase64String(input);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
