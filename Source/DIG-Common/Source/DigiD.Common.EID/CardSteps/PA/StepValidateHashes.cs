// De openbaarmaking van dit bestand is in het kader van de WOO geschied en 
// dus gericht op transparantie en niet op hergebruik. In het geval dat dit 
// bestand hergebruikt wordt, is de EUPL licentie van toepassing, met 
// uitzondering van broncode waarvoor een andere licentie is aangegeven.
//
// Het archief waar dit bestand deel van uitmaakt is te vinden op:
//   https://github.com/MinBZK/woo-verzoek-broncode-digid-app
//
// Eventuele kwetsbaarheden kunnen worden gemeld bij het NCSC via:
//   https://www.ncsc.nl/contact/kwetsbaarheid-melden
// onder vermelding van "Logius, openbaar gemaakte broncode DigiD-App" 
//
// Voor overige vragen over dit WOO-verzoek kunt u mailen met:
//   mailto://open@logius.nl
//
﻿using System.Linq;
using System.Threading.Tasks;
using DigiD.Common.EID.BaseClasses;
using DigiD.Common.EID.Helpers;
using DigiD.Common.EID.Interfaces;
using DigiD.Common.NFC.Helpers;

namespace DigiD.Common.EID.CardSteps.PA
{
    internal class StepValidateHashes : BaseSecureStep, IStep
    {
        public StepValidateHashes(ISecureCardOperation operation) : base(operation)
        {
        }

        public Task<bool> Execute()
        {
            foreach (var dg in Operation.GAP.Card.DataGroups.OrderBy(x => x.Key))
            {
                var hash = AesHelper.CalculateHash(dg.Value.Bytes, Operation.GAP.Card.MessageDigestAlgorithm, Operation.GAP.Card.KeyLength);
                if (!Operation.GAP.Card.EF_SOd.Hashes[dg.Key].SequenceEqual(hash))
                    return Task.FromResult(false);

                Debugger.WriteLine($"DG{dg.Key}\r\n" +
                                   $"Stored:     {Operation.GAP.Card.EF_SOd.Hashes[dg.Key].ToHexString()}\r\n" +
                                   $"Calculated: {hash.ToHexString()}");
            }

            return Task.FromResult(true);
        }
    }
}
