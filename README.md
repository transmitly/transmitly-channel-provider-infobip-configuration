# Transmitly.ChannelProvider.Infobip.Configuration

Shared Infobip configuration and extension contracts for Transmitly channel providers.

## Should you use this package?

Use this package if you are building or extending an Infobip provider for the Transmitly ecosystem and need the shared configuration objects and provider-specific channel contracts.

If you just want to send communications through Infobip from an application, use [`Transmitly.ChannelProvider.Infobip`](https://github.com/transmitly/transmitly-channel-provider-infobip) instead.

## What This Package Provides

- `InfobipChannelProviderConfiguration` with `ApiKey`, `BasePath`, `ApiKeyPrefix`, `WebProxy`, and provider user-agent support.
- `ChannelProviders.Infobip(providerId)` for resolving a Transmitly channel-provider id.
- `email.Infobip()`, `sms.Infobip()`, and `voice.Infobip()` channel-specific extension points.
- Email contracts for features such as `TemplateId`, `AmpHtml`, tracking, and notify URLs.
- SMS contracts for features such as `ValidityPeriod`, `ApplicationId`, `EntityId`, and notify URLs.
- Voice contracts for features such as machine detection, recording, timeouts, and voice selection.
- Delivery-report interfaces and adaptor registration hooks for provider-specific extensions.

## Related Packages

- [Transmitly](https://github.com/transmitly/transmitly)
- [Transmitly.ChannelProvider.Infobip](https://github.com/transmitly/transmitly-channel-provider-infobip)
- [Transmitly.ChannelProvider.Infobip.Api](https://github.com/transmitly/transmitly-channel-provider-infobip-api)

---
_Copyright (c) Code Impressions, LLC. This open-source project is sponsored and maintained by Code Impressions and is licensed under the [Apache License, Version 2.0](http://apache.org/licenses/LICENSE-2.0.html)._
