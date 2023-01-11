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
﻿using System.Collections.Generic;
using System.Linq;
using DigiD.Common;
using DigiD.Common.Models.ResponseModels;
using DigiD.Common.SessionModels;
using Xamarin.CommunityToolkit.ObjectModel;

namespace DigiD.ViewModels
{
    public class MessageCenterViewModel : BaseNotificationsSettingsViewModel
    {
        public List<Message> Messages { get; set; }

        public bool HasMessages => Messages?.Count > 0;

#if A11YTEST
        public MessageCenterViewModel() : this ("a11ySessionId") { }
#endif

        public MessageCenterViewModel(MessageCenterResponse messages, bool canGoBack) : base(true)
        {
            PageId = "AP022";
            HeaderText = AppResources.AP022_Header;
            HasBackButton = canGoBack;

            if (!canGoBack)
            {
                NavCloseCommand = new AsyncCommand(async () =>
                {
                    await NavigationService.PopToRoot();
                });
            }

            LoadMessages(messages);
        }

        private void LoadMessages(MessageCenterResponse messages)
        {
            Messages = messages.Messages.OrderByDescending(x => x.DateTime).ToList();
            AppSession.AccountStatus.UnreadMessagesCount = 0;
        }
    }
}
