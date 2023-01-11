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
﻿using DigiD.Common.Http.Models;
using Newtonsoft.Json;

namespace DigiD.Common.Models.ResponseModels
{
    public class CompleteChallengeResponse : BaseResponse
    {
        [JsonProperty("symmetric_key")]
        public string SymmetricKey { get; set; }

        [JsonProperty("iv")]
        public string IV { get; set; }

        public bool Success => !string.IsNullOrEmpty(Status) && Status.ToLowerInvariant() == "ok";
    }

    public class CompleteActivationResponse : BaseResponse
    {
        [JsonProperty("authentication_level")]
        public int AuthenticationLevel { get; set; }
    }
}
