// Copyright (c) Code Impressions, LLC. All Rights Reserved.
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
using Transmitly.ChannelProvider.Infobip.Configuration.Voice;
using Transmitly.Delivery;

namespace Transmitly.ChannelProvider.Infobip.ConfigurationTests
{
	/// <summary>
	/// Infobip values live on the channel or report itself, so nothing has to be registered for them to be kept.
	/// </summary>
	[TestClass]
	public sealed class ExtendedPropertiesTests
	{
		[TestMethod]
		public void EmailSettings_SetOnTheChannel_AreReadFromTheDispatchedEmail()
		{
			// Core hands the channel's extended properties to the email it builds for dispatch.
			IExtendedProperties bag = new ExtendedProperties();
			var channel = Mock.Of<IEmailChannelConfiguration>(c => c.ExtendedProperties == bag);
			channel.Infobip().TemplateId = 42;

			var email = Mock.Of<IEmail>(e => e.ExtendedProperties == bag).Infobip();

			Assert.AreEqual(42, email.TemplateId);
			Assert.IsTrue(email.Track, "Track defaults to true.");
			Assert.AreSame(channel.Infobip().AmpHtml, email.AmpHtml, "The AMP template configuration must be created once and kept.");
		}

		[TestMethod]
		public void SmsSettings_AreKept_AndValidated()
		{
			IExtendedProperties bag = new ExtendedProperties();
			var channel = Mock.Of<ISmsChannelConfiguration>(c => c.ExtendedProperties == bag);
			channel.Infobip().EntityId = "entity-1";

			Assert.AreEqual("entity-1", Mock.Of<ISms>(s => s.ExtendedProperties == bag).Infobip().EntityId);
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => channel.Infobip().ApplicationId = new string('a', 51));
		}

		[TestMethod]
		public void VoiceSettings_HaveDefaults_AndAreValidated()
		{
			IExtendedProperties bag = new ExtendedProperties();
			var voice = Mock.Of<IVoiceChannelConfiguration>(c => c.ExtendedProperties == bag).Infobip();

			Assert.AreEqual(MachineDetection.Enabled, voice.MachineDetection);
			Assert.AreEqual(VoiceGender.Unspecified, voice.VoiceGender);
			voice.Pause = 3;
			Assert.AreEqual(3, Mock.Of<IVoice>(v => v.ExtendedProperties == bag).Infobip().Pause);
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => voice.RingTimeout = 46);
		}

		[TestMethod]
		public void DeliveryReportValues_RoundTrip_WithoutRegistration()
		{
			var report = new DeliveryReport(DeliveryReport.Event.StatusChanged(), "Sms", "Infobip", null, null, "msg-1", CommunicationsStatus.Info("Infobip", "Pending"), null, null, null);

			report.Infobip().Sms.MessageId = "sms-1";
			report.Infobip().Sms.SmsCount = 2;
			report.Infobip().Voice.MessageId = "voice-1";
			report.Infobip().Email.MessageId = "email-1";
			report.Infobip().Email.SendingIp = "192.0.2.10";

			Assert.AreEqual("sms-1", report.Infobip().Sms.MessageId);
			Assert.AreEqual(2, report.Infobip().Sms.SmsCount);
			Assert.AreEqual("voice-1", report.Infobip().Voice.MessageId);
			Assert.AreEqual("email-1", report.Infobip().Email.MessageId);
			Assert.AreEqual("192.0.2.10", report.Infobip().Email.SendingIp);
		}
	}
}
