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
﻿namespace DigiD.Common.Enums
{
    public enum MessagePageType
	{
		AppBlocked,
		ActivationTimeElapsed,
		ActivationCompleted,
		ActivationCancelled,
		ActivationFailed,
        ActivationFailedTooManyDevices,
        ActivationLetterBlocked,
        ActivationLetterExpired,
        ActivationDisabled,
        ActivationPending,
        ActivationFailedTooSoon,
        ActivationFailedTooFast,
        AccountBlocked,
        GBAFailed,
        LoginUnknown,
		LoginSuccess,
	    NoBSN,
        LoginCancelled,
        LoginAborted,
		NoInternetConnection,
		ErrorOccoured,
		InvalidScan,
		ScanTimeout,
        SessionTimeout,
        ChallengeFailed,
        HostUnknown,
        SSLException,
        BrowserUnsupported,
        NoNFCSupport,
        UpgradeAccountWithNFCSuccess,
        UpgradeAccountWithNFCFailed,
        UpgradeAccountWithNFCError,
        UpgradeAccountWithNFCCancelled,
	    UpgradeAccountWithNFCAborted,
        ReRequestLetterSuccess,
        NetworkTimeout,
        PasswordChangeSuccess,
        ActivateSMSAuthenticationSuccess,
        ActivateSMSAuthenticationBlocked,
        PhoneNumberChangeSuccess,
        WIDRandomizeSuccess,
        WIDRandomizeFailed,
        WIDSuspended,
        WIDCancelled,
        WIDFirstUse,
        WIDChangePINSuccess,
        WIDResumePINSuccess,
	    WIDResumePUKSuccess,
        WIDResumeFailed,
        WIDPINBlocked,
        WIDPUKBlocked,
        WIDFailed,
	    WIDLoginFailed,
        VerificationCodeFailed,
        WIDActivationSuccess,
        WIDActivationFailed,
        WIDReActivationSuccess,
        WIDReActivationFailed,
        WIDRetractSuccess,
        WIDNotSupported,
        WIDReaderTimeout,
        WIDActivationNeeded,
        InvalidAuthenticationLevel,
        UnknownError,
        NotActivated,
        ReactivationNeeded,
        InsufficientLoginLevel,
        RDADisabled,
        UpgradeAccountWithNFCNoDocuments,
        UpgradeAccountWithIDCheckerSuccess,
        EmailChange,
        EmailAdd,
        EmailRemove,
        AuthenticationAborted,
        AppActivationWithAppSuccess,
        ActivateViaRequestStationCancel,
        AccountCancelledSuccess,
        ChangePinSuccess,
        ChangePinFailed,
        ChangePinMaxReached,
        DeviceNotSupported,
        ActivateViaRequestStationCodeExpired,
        DeactivateAppSuccess,
        ActivationPendingNoSMSCheck, // Gebruiker heeft een account aangevraagd, maar dan zonder SMS controle
        InAppActivationCodeBlocked,
        InAppActivationCodeExpired,
        EmailRegistrationTooManyMails,
        EmailRegistrationMaximumReached,
        EmailRegistrationCodeBlocked, //te vaak foutieve code ingevoerd
        UpgradeAndAuthenticateFailed,
        EmailRegistrationAlreadyVerified,
        EmailRegistrationSuccess,
        EmailRegistrationSuccessfulVerified,
        AppDeactivated,
        NoValidDocuments,
        RequestAccountBlockedTemporarily,
        RequestAccountInvalid,
        RequestAccountNotAvailable,
        RequestAccountDeceased,
        RequestAccountTooOftenDay,
        RequestAccountTooOftenMonth,
        RequestAccountAccountBlocked,
        RequestAccountBRPTimeout,
        RequestAccountNotLatestAddress,
        RequestAccountAddressUnderInvestigating,
        RequestAccountAddressAbroad,
        UpgradeAndAuthenticateAborted,
        ClassifiedDeceased,
        ContactHelpDesk,
    }
}

