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
﻿using System;
using DigiD.Common.Helpers;

namespace DigiD.Common.Models
{
    public class ObfuscatedString
    {
        private readonly byte[] _key;
        private readonly byte[] _value;
        
        public ObfuscatedString(string key, string value)
        {
            _key = Convert.FromBase64String(key);
            _value = Convert.FromBase64String(value);
        }

        public override string ToString()
        {
            return _value.DeObfuscate(_key);
        }
    }
}
