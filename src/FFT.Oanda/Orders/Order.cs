﻿// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

using System;
using System.Collections.Immutable;
using System.Text.Json.Serialization;
using FFT.Oanda.JsonConverters;

/// <summary>
/// The base Order definition specifies the properties that are common to all
/// orders. Implemented by: MarketOrder, FixedPriceOrder, LimitOrder,
/// StopOrder, MarketIfTouchedOrder, TakeProfitOrder, StopLossOrder,
/// GuaranteedStopLossOrder, TrailingStopLossOrder.
/// </summary>
[JsonConverter(typeof(OrderConverter))]
public abstract record Order
{

// due to order derived classes are used in the trade object as properties with only partial information
// most of the properties arent allowed to be set required
// these properties doesnt exists in the trades object json stream
// seems that only six of them will be send by oanda every time ... 
// Id, CreateTime, State, Type, TimeInForce and TriggerCondition

 /// <summary>
 /// The Order’s identifier, unique within the Order’s Account.
 /// </summary>
 public required int Id { get; init; }

 /// <summary>
 /// The time when the Order was created.
 /// </summary>
 public required DateTime CreateTime { get; init; }

 /// <summary>
 /// The current state of the Order.
 /// </summary>
 public required OrderState State { get; init; }

 /// <summary>
 /// The client extensions of the Order. Do not set, modify, or delete
 /// clientExtensions if your account is associated with MT4.
 /// </summary>
 public ClientExtensions? ClientExtensions { get; init; }

 /// <summary>
 /// The type of the Order.
 /// </summary>
 public required OrderType Type { get; init; }

 /// <summary>
 /// The Order’s Instrument.
 /// </summary>
 public string Instrument { get; init; }

 /// <summary>
 /// The time-in-force requested for the Order.
 /// </summary>
 public required TimeInForce TimeInForce { get; init; }

 /// <summary>
 /// The date/time when the Order will be cancelled if its timeInForce
 /// is “GTD”.
 /// </summary>
 public DateTime? GtdTime { get; init; }

 /// <summary>
 /// Specification of how Positions in the Account are modified when the
 /// Order is filled.
 /// </summary>
 public OrderPositionFill PositionFill { get; init; }

 /// <summary>
 /// Specification of which price component should be used when determining
 /// if an Order should be triggered and filled. This allows Orders to be
 /// triggered based on the bid, ask, mid, default (ask for buy, bid for
 /// sell) or inverse (ask for sell, bid for buy) price depending on the
 /// desired behaviour. Orders are always filled using their default price
 /// component. This feature is only provided through the REST API. Clients
 /// who choose to specify a non-default trigger condition will not see it
 /// reflected in any of OANDA’s proprietary or partner trading platforms,
 /// their transaction history or their account statements. OANDA platforms
 /// always assume that an Order’s trigger condition is set to the default
 /// value when indicating the distance from an Order’s trigger price, and
 /// will always provide the default trigger condition when creating or
 /// modifying an Order. A special restriction applies when creating a
 /// Guaranteed Stop Loss Order. In this case the TriggerCondition value must
 /// either be “DEFAULT”, or the“natural” trigger side “DEFAULT” results in.
 /// So for a Guaranteed Stop Loss Order for a long trade valid values are
 /// “DEFAULT” and “BID”, and for short trades “DEFAULT” and “ASK” are valid.
 /// </summary>
 public required OrderTriggerCondition TriggerCondition { get; init; }

 /// <summary>
 /// TakeProfitDetails specifies the details of a Take Profit Order to be
 /// created on behalf of a client. This may happen when an Order is filled
 /// that opens a Trade requiring a Take Profit, or when a Trade’s dependent
 /// Take Profit Order is modified directly through the Trade.
 /// </summary>
 public TakeProfitDetails? TakeProfitOnFill { get; init; }

 /// <summary>
 /// StopLossDetails specifies the details of a Stop Loss Order to be created
 /// on behalf of a client. This may happen when an Order is filled that
 /// opens a Trade requiring a Stop Loss, or when a Trade’s dependent Stop
 /// Loss Order is modified directly through the Trade.
 /// </summary>
 public StopLossDetails? StopLossOnFill { get; init; }

 /// <summary>
 /// GuaranteedStopLossDetails specifies the details of a Guaranteed Stop
 /// Loss Order to be created on behalf of a client. This may happen when an
 /// Order is filled that opens a Trade requiring a Guaranteed Stop Loss, or
 /// when a Trade’s dependent Guaranteed Stop Loss Order is modified directly
 /// through the Trade.
 /// </summary>
 public GuaranteedStopLossDetails? GuaranteedStopLossOnFill { get; init; }

 /// <summary>
 /// TrailingStopLossDetails specifies the details of a Trailing Stop Loss
 /// Order to be created on behalf of a client. This may happen when an Order
 /// is filled that opens a Trade requiring a Trailing Stop Loss, or when a
 /// Trade’s dependent Trailing Stop Loss Order is modified directly through
 /// the Trade.
 /// </summary>
 public TrailingStopLossDetails? TrailingStopLossOnFill { get; init; }

 /// <summary>
 /// Client Extensions to add to the Trade created when the Order is filled
 /// (if such a Trade is created). Do not set, modify, or delete
 /// tradeClientExtensions if your account is associated with MT4.
 /// </summary>
 public ClientExtensions? TradeClientExtensions { get; init; }

 /// <summary>
 /// ID of the Transaction that filled this Order (only provided when the
 /// Order’s state is FILLED).
 /// </summary>
 public int? FillingTransactionID { get; init; }

 /// <summary>
 /// Date/time when the Order was filled (only provided when the Order’s
 /// state is FILLED).
 /// </summary>
 public DateTime? FilledTime { get; init; }

 /// <summary>
 /// Trade ID of Trade opened when the Order was filled (only provided when
 /// the Order’s state is FILLED and a Trade was opened as a result of the
 /// fill).
 /// </summary>
 public int? TradeOpenedID { get; init; }

 /// <summary>
 /// Trade ID of Trade reduced when the Order was filled (Only provided when
 /// the Order’s state is FILLED and a Trade was reduced as a result of the
 /// fill).
 /// </summary>
 public int? TradeReducedID { get; init; }

 /// <summary>
 /// Trade IDs of Trades closed when the Order was filled (Only provided when
 /// the Order’s state is FILLED and one or more Trades were closed as a
 /// result of the fill).
 /// </summary>
 public ImmutableList<int>? TradeClosedIDs { get; init; }

 /// <summary>
 /// ID of the Transaction that cancelled the Order (Only provided when the
 /// Order’s state is CANCELLED).
 /// </summary>
 public int? CancellingTransactionID { get; init; }

 /// <summary>
 /// Date/time when the Order was cancelled (only provided when the state of
 /// the Order is CANCELLED).
 /// </summary>
 public DateTime? CancelledTime { get; init; }

 /// <summary>
 /// The ID of the Order that was replaced by this Order (only provided if
 /// this Order was created as part of a cancel/replace).
 /// </summary>
 public int? ReplacesOrderID { get; init; }

 /// <summary>
 /// The ID of the Order that replaced this Order (only provided if this
 /// Order was cancelled as part of a cancel/replace).
 /// </summary>
 public int? ReplacedByOrderID { get; init; }}
