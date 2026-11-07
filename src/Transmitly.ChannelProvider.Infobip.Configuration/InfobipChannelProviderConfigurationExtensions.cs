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

using Transmitly.Channel.Configuration.Email;
using Transmitly.Channel.Configuration.Sms;
using Transmitly.Channel.Configuration.Voice;
using Transmitly.ChannelProvider.Infobip.Configuration;
using Transmitly.ChannelProvider.Infobip.Configuration.Email;
using Transmitly.ChannelProvider.Infobip.Configuration.Sms;
using Transmitly.ChannelProvider.Infobip.Configuration.Voice;
using Transmitly.Delivery;
using Transmitly.Util;

namespace Transmitly
{
	public static class InfobipChannelProviderConfigurationExtensions
	{
		/// <summary>
		/// Gets the channel provider id for Infobip.
		/// </summary>
		/// <param name="channelProviders">Channel providers object.</param>
		/// <param name="providerId">Optional channel provider Id.</param>
		/// <returns>Infobip channel provider id.</returns>
		public static string Infobip(this ChannelProviders channelProviders, string? providerId = null)
		{
			Guard.AgainstNull(channelProviders);
			return channelProviders.GetId(InfobipConstant.Id, providerId);
		}

		/// <summary>
		/// Infobip specific settings for an email channel.
		/// </summary>
		/// <param name="email">Email Channel.</param>
		/// <returns>Infobip email properties.</returns>
		public static IEmailExtendedChannelProperties Infobip(this IEmailChannelConfiguration email)
		{
			return new EmailExtendedChannelProperties(Guard.AgainstNull(email).ExtendedProperties);
		}

		/// <summary>
		/// Infobip specific settings
		/// </summary>
		/// <param name="email">Email being dispatched.</param>
		/// <returns>Infobip email properties.</returns>
		public static IEmailExtendedChannelProperties Infobip(this IEmail email)
		{
			return new EmailExtendedChannelProperties(Guard.AgainstNull(email).ExtendedProperties);
		}

		/// <summary>
		/// Infobip specific settings for an sms channel.
		/// </summary>
		/// <param name="sms">Sms Channel.</param>
		/// <returns>Infobip Sms properties.</returns>
		public static ISmsExtendedChannelProperties Infobip(this ISmsChannelConfiguration sms)
		{
			return new SmsExtendedChannelProperties(Guard.AgainstNull(sms).ExtendedProperties);
		}

		/// <summary>
		/// Infobip specific settings
		/// </summary>
		/// <param name="sms">Sms being dispatched.</param>
		/// <returns>Infobip Sms properties.</returns>
		public static ISmsExtendedChannelProperties Infobip(this ISms sms)
		{
			return new SmsExtendedChannelProperties(Guard.AgainstNull(sms).ExtendedProperties);
		}

		/// <summary>
		/// Infobip specific settings for a voice channel.
		/// </summary>
		/// <param name="voice">Voice Channel.</param>
		/// <returns>Infobip voice properties.</returns>
		public static IVoiceExtendedChannelProperties Infobip(this IVoiceChannelConfiguration voice)
		{
			return new VoiceExtendedChannelProperties(Guard.AgainstNull(voice).ExtendedProperties);
		}

		/// <summary>
		/// Infobip specific settings
		/// </summary>
		/// <param name="voice">Voice being dispatched.</param>
		/// <returns>Infobip voice properties.</returns>
		public static IVoiceExtendedChannelProperties Infobip(this IVoice voice)
		{
			return new VoiceExtendedChannelProperties(Guard.AgainstNull(voice).ExtendedProperties);
		}

		/// <summary>
		/// Infobip specific values for a delivery report.
		/// </summary>
		/// <param name="deliveryReport">Delivery Report.</param>
		/// <returns>Infobip delivery report properties.</returns>
		public static IDeliveryReportExtendedProperties Infobip(this DeliveryReport deliveryReport)
		{
			return new DeliveryReportExtendedProperties(deliveryReport);
		}
	}
}