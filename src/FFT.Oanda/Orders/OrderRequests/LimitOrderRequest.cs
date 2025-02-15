﻿// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using FFT.Oanda.JsonConverters;

namespace FFT.Oanda.Orders.OrderRequests;

/// <summary>
/// A LimitOrderRequest specifies the parameters that may be set when creating
/// a Limit Order.
/// </summary>
public sealed record LimitOrderRequest : OpenTradeOrderRequest
{
  /// <inheritdoc />
  public override OrderType Type => OrderType.LIMIT;

  /// <summary>
  /// The quantity requested to be filled by the Limit Order. A positive
  /// number of units results in a long Order, and a negative number of units
  /// results in a short Order.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]  // order request is rejected without
  public decimal Units { get; init; }

  /// <summary>
  /// The price threshold specified for the Limit Order. The Limit Order will
  /// only be filled by a market price that is equal to or better than this
  /// price.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]  // order request is rejected without
  public decimal Price { get; init; }

  private protected override void CustomValidate2()
  {
  }
}
