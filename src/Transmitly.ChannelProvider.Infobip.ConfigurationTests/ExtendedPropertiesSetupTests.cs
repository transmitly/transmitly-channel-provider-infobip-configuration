// ﻿﻿Copyright (c) Code Impressions, LLC. All Rights Reserved.
//  
//  Licensed under the Apache License, Version 2.0 (the "License")
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  
//      http://www.apache.org/licenses/LICENSE-2.0
//  
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

using Moq;
using Transmitly.Channel.Configuration.Email;
using Transmitly.Channel.Configuration.Sms;
using Transmitly.Channel.Configuration.Voice;
using Transmitly.ChannelProvider.Infobip.Configuration;
using Transmitly.ChannelProvider.Infobip.Configuration.Email;
using Transmitly.ChannelProvider.Infobip.Configuration.Sms;
using Transmitly.ChannelProvider.Infobip.Configuration.Voice;
using Transmitly.Delivery;

namespace Transmitly.ChannelProvider.Infobip.ConfigurationTests
{
	[TestClass]
	public sealed class ExtendedPropertiesSetupTests
	{
		[TestInitialize]
		public void Init()
		{
			// since the registration should happen in a single threaded env (Startup/Program.cs)
			// we'll reset and force each test execution to start 'fresh'
			InfobipChannelProviderExtendedProprtiesBuilderExtensions.Reset();
		}

		[TestMethod]
		public void SmsExtensionShouldReturnEmptyBagIfNotConfigured()
		{
			var smsConfig = new Mock<ISmsChannelConfiguration>();
			smsConfig.SetupAllProperties();
			var result = InfobipChannelProviderConfigurationExtensions.Infobip(smsConfig.Object);
			Assert.IsInstanceOfType<EmptySmsExtendedChannelProperites>(result);
		}

		[TestMethod]
		public void SmsExtensionShouldReturnConfiguredPropertyBag()
		{
			var smsConfig = new Mock<ISmsChannelConfiguration>();
			var mockBag = new Mock<ISmsExtendedChannelProperties>();
			mockBag.SetupAllProperties();

			InfobipChannelProviderExtendedProprtiesBuilderExtensions.AddSmsExtendedPropertiesAdaptor<MockSmsBag>(null);
			var result = InfobipChannelProviderConfigurationExtensions.Infobip(smsConfig.Object);

			Assert.IsInstanceOfType<MockSmsBag>(result);
		}

		[TestMethod]
		public void VoiceExtensionShouldReturnEmptyBagIfNotConfigured()
		{
			var smsConfig = new Mock<IVoiceChannelConfiguration>();
			smsConfig.SetupAllProperties();

			var result = InfobipChannelProviderConfigurationExtensions.Infobip(smsConfig.Object);
			Assert.IsInstanceOfType<EmptyVoiceExtendedChannelProperties>(result);
		}

		[TestMethod]
		public void VoiceExtensionShouldReturnConfiguredPropertyBag()
		{
			var smsConfig = new Mock<IVoiceChannelConfiguration>();
			var mockBag = new Mock<IVoiceExtendedChannelProperties>();
			mockBag.SetupAllProperties();

			InfobipChannelProviderExtendedProprtiesBuilderExtensions.AddVoiceExtendedPropertiesAdaptor<MockVoiceBag>(null);
			var result = InfobipChannelProviderConfigurationExtensions.Infobip(smsConfig.Object);

			Assert.IsInstanceOfType<MockVoiceBag>(result);
		}


		[TestMethod]
		public void EmailExtensionShouldReturnEmptyBagIfNotConfigured()
		{
			var smsConfig = new Mock<IVoiceChannelConfiguration>();
			smsConfig.SetupAllProperties();

			var result = InfobipChannelProviderConfigurationExtensions.Infobip(smsConfig.Object);
			Assert.IsInstanceOfType<EmptyVoiceExtendedChannelProperties>(result);
		}

		[TestMethod]
		public void EmailExtensionShouldReturnConfiguredPropertyBag()
		{
			var smsConfig = new Mock<IEmailChannelConfiguration>();
			var mockBag = new Mock<IEmailExtendedChannelProperties>();
			mockBag.SetupAllProperties();

			InfobipChannelProviderExtendedProprtiesBuilderExtensions.AddEmailExtendedPropertiesAdaptor<MockEmailBag>(null);
			var result = InfobipChannelProviderConfigurationExtensions.Infobip(smsConfig.Object);

			Assert.IsInstanceOfType<MockEmailBag>(result);
		}


		[TestMethod]
		public void DeliveryReportExtensionShouldReturnEmptyBagIfNotConfigured()
		{
			var report = new DeliveryReport(null, null, null, null, null, null, null, null, null, null);
			var result = InfobipChannelProviderConfigurationExtensions.Infobip(report);
			Assert.IsInstanceOfType<EmptyDeliveryReportExtendedProprties>(result);
		}

		[TestMethod]
		public void DeliveryExtensionShouldReturnConfiguredPropertyBag()
		{
			var report = new DeliveryReport(null, null, null, null, null, null, null, null, null, null);
			var mockBag = new Mock<IEmailExtendedChannelProperties>();
			mockBag.SetupAllProperties();

			InfobipChannelProviderExtendedProprtiesBuilderExtensions.AddDeliveryReportExtendedProprtiesAdaptor<MockDeliveryReportBag>(null);
			var result = InfobipChannelProviderConfigurationExtensions.Infobip(report);

			Assert.IsInstanceOfType<MockDeliveryReportBag>(result);
		}
	}
}
