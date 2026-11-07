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

using System;

namespace Transmitly.ChannelProvider.Infobip.Configuration.Email
{
	/// <summary>
	/// Infobip values for an email delivery report.
	/// </summary>
	public interface IEmailExtendedDeliveryReportProperties
	{
		/// <summary>
		/// The ID that uniquely identifies the request.
		/// </summary>
		string? BulkId { get; set; }
		/// <summary>
		/// The ID that uniquely identifies the sent email.
		/// </summary>
		string? MessageId { get; set; }
		/// <summary>
		/// The recipient's email address.
		/// </summary>
		string? To { get; set; }
		/// <summary>
		/// Send date and time.
		/// </summary>
		DateTimeOffset? SentAt { get; set; }
		/// <summary>
		/// Delivery date and time.
		/// </summary>
		DateTimeOffset? DoneAt { get; set; }
		/// <summary>
		/// The number of emails sent. Infobip reports it as <c>smsCount</c>.
		/// </summary>
		int? SmsCount { get; set; }
		/// <summary>
		/// Callback data sent in the <c>callbackData</c> field of the email.
		/// </summary>
		string? CallbackData { get; set; }
		/// <summary>
		/// Price of the sent email.
		/// </summary>
		IEmailPrice? Price { get; set; }
		/// <summary>
		/// Delivery status of the email.
		/// </summary>
		ICallbackStatus? Status { get; set; }
		/// <summary>
		/// Error details.
		/// </summary>
		IErrorStatus? Error { get; set; }
		/// <summary>
		/// Link to the HTML sent to the recipient.
		/// </summary>
		string? BrowserLink { get; set; }
		/// <summary>
		/// The IP address used to send the email.
		/// </summary>
		string? SendingIp { get; set; }
	}
}
