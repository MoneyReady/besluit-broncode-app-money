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
﻿using System.Linq;
using System.Threading.Tasks;
using DigiD.Common.EID.BaseClasses;
using DigiD.Common.EID.Helpers;
using DigiD.Common.EID.Interfaces;
using DigiD.Common.EID.Models.CardFiles;

namespace DigiD.Common.EID.CardSteps.CAv1
{
    /// <summary>
    /// Send a MSE command to the PCA to set up CA
    /// See step 12, page 25 of the PCA implementation guidelines.
    /// </summary>
    internal class StepSetAT : BaseSecureStep, IStep
    {
        public StepSetAT(ISecureCardOperation operation) : base(operation)
        {
            
        }

        public async Task<bool> Execute()
        {
            var oid = ((DG14)Operation.GAP.Card.DataGroups[14]).ChipAuthenticationInfo.OID.GetEncoded().Skip(2).ToArray();
            var command = CommandApduBuilder.GetMSESetATCAv1Command(oid, Operation.GAP.SMContext);
            var response = await CommandApduBuilder.SendAPDU("CAv1 Set AT", command, Operation.GAP.SMContext);

            return response.SW == 0x9000;
        }
    }
}
