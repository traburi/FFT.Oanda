﻿// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
/// <summary>
/// A MarketIfTouchedOrderRejectTransaction represents the rejection of the
/// creation of a MarketIfTouched Order.
/// </summary>
public sealed record MarketIfTouchedOrderRejectTransaction : MarketIfTouchedOrderTransaction
{
  /// <summary>
  /// The reason that the Reject Transaction was created.
  /// </summary>
  public TransactionRejectReason RejectReason { get; init; }
}
