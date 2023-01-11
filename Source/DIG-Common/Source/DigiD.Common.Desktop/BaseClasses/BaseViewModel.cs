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
﻿using DigiD.Common.Constants;
using DigiD.Common.Helpers;
using DigiD.Common.Interfaces;
using DigiD.Common.Services;
#if DEBUG
using System.Diagnostics;
#endif
using System.Windows.Input;
using DigiD.Common.Enums;
using DigiD.Common.SessionModels;
using Xamarin.Forms;

namespace DigiD.Common.BaseClasses
{
    public class BaseViewModel : CommonBaseViewModel
    {
        public BaseViewModel(bool disableLogging = false) : base(disableLogging)
        {
            CanExecute = true;
            IsError = false;
            IsLandingPageActive = false;
#if A11YTEST
            HasBackButton = true;
#endif
        }
    }
}
