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
using DigiD.Common.EID.Interfaces;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Asn1.X9;

namespace DigiD.Common.EID.Models.SecurityInfoObjects
{
    public class CADomainParameterInfo : Asn1Encodable, IAsn1Info
    {
        public DerObjectIdentifier OID { get; }
        public AlgorithmIdentifier DomainParameter { get; }
        public X9ECParameters Algorithm => new X9ECParameters(Asn1Sequence.GetInstance(DomainParameter.Parameters));

        public CADomainParameterInfo(Asn1Sequence sequence)
        {
            if (sequence == null)
                throw new ArgumentNullException(nameof(sequence));

            OID = (DerObjectIdentifier) sequence[0];
            DomainParameter = AlgorithmIdentifier.GetInstance(sequence[1]);
        }

        public override string ToString()
        {
            return $"CADomainParameters\r\nOID: {OID}\r\nDomainParameter: {DomainParameter.Algorithm}\r\n";
        }

        public override Asn1Object ToAsn1Object()
        {
            var v = new Asn1EncodableVector { OID, DomainParameter };
            return new DerSequence(v);
        }
    }
}
