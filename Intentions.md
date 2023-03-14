**Intentions:**

![Intentions](diagram/Intentions.svg)

```
Intentions
         ::= Transacting '.' EndOfLine
```

**Transacting:**

![Transacting](diagram/Transacting.svg)

```
Transacting
         ::= Actors Actions Signature
```

referenced by:

* Intentions

**Actors:**

![Actors](diagram/Actors.svg)

```
Actors   ::= User
           | Auto
```

referenced by:

* Transacting

**Actions:**

![Actions](diagram/Actions.svg)

```
Actions  ::= Ordering
           | Invoicing
           | Delivering
           | Confirming
```

referenced by:

* Transacting

**Signature:**

![Signature](diagram/Signature.svg)

```
Signature
         ::= ' commiting by signature ' AlfaNumeric
```

referenced by:

* Transacting

**User:**

![User](diagram/User.svg)

```
User     ::= 'I am'
```

referenced by:

* Actors

**Auto:**

![Auto](diagram/Auto.svg)

```
Auto     ::= 'We are'
```

referenced by:

* Actors

**Ordering:**

![Ordering](diagram/Ordering.svg)

```
Ordering ::= ( Bidding | Asking ) Reservation
```

referenced by:

* Actions

**Invoicing:**

![Invoicing](diagram/Invoicing.svg)

```
Invoicing
         ::= ( Buying | Selling ) Expiration
```

referenced by:

* Actions

**Delivering:**

![Delivering](diagram/Delivering.svg)

```
Delivering
         ::= ( Paying | Cashing ) Execution
```

referenced by:

* Actions

**Confirming:**

![Confirming](diagram/Confirming.svg)

```
Confirming
         ::= ( Expensing | Receipting ) Confirmation
```

referenced by:

* Actions

**Bidding:**

![Bidding](diagram/Bidding.svg)

```
Bidding  ::= ' bidding' Offer ' with reservation to buy in' MarketItem
```

referenced by:

* Ordering

**Asking:**

![Asking](diagram/Asking.svg)

```
Asking   ::= ' asking' MarketOffer ' with reservation to sell out' Item
```

referenced by:

* Ordering

**Reservation:**

![Reservation](diagram/Reservation.svg)

```
Reservation
         ::= ' and the order is good when the market volume reaches' Volume
```

referenced by:

* Ordering

**Buying:**

![Buying](diagram/Buying.svg)

```
Buying   ::= ' buying' Item ' with expiration to pay out' Offer
```

referenced by:

* Invoicing

**Selling:**

![Selling](diagram/Selling.svg)

```
Selling  ::= ' selling' Item ' with expiration to cash in' Offer
```

referenced by:

* Invoicing

**Expiration:**

![Expiration](diagram/Expiration.svg)

```
Expiration
         ::= ' and the invoice is good when the market volume reaches' Volume
```

referenced by:

* Invoicing

**Paying:**

![Paying](diagram/Paying.svg)

```
Paying   ::= ' paying' Offer ' with execution to receipt in' Item
```

referenced by:

* Delivering

**Cashing:**

![Cashing](diagram/Cashing.svg)

```
Cashing  ::= ' cashing' Item ' with execution to expense out' Offer
```

referenced by:

* Delivering

**Execution:**

![Execution](diagram/Execution.svg)

```
Execution
         ::= ' and the delivery is good when the market volume reaches' Volume
```

referenced by:

* Delivering

**Expensing:**

![Expensing](diagram/Expensing.svg)

```
Expensing
         ::= ' expensing' Offer ' with confirmation of receipt of' Item
```

referenced by:

* Confirming

**Receipting:**

![Receipting](diagram/Receipting.svg)

```
Receipting
         ::= ' receipting' Item ' with confirmation of expense of' Offer
```

referenced by:

* Confirming

**Confirmation:**

![Confirmation](diagram/Confirmation.svg)

```
Confirmation
         ::= ' and the confirmation is good at the market' MarketVolume ', ' MarketAccount ' and' MarketInventory
```

referenced by:

* Confirming

**MarketVolume:**

![MarketVolume](diagram/MarketVolume.svg)

```
MarketVolume
         ::= ' volume of' Exactly ' SWOBL'
```

referenced by:

* Confirmation

**MarketAccount:**

![MarketAccount](diagram/MarketAccount.svg)

```
MarketAccount
         ::= ' account of' Exactly ' SWOBL'
```

referenced by:

* Confirmation

**MarketInventory:**

![MarketInventory](diagram/MarketInventory.svg)

```
MarketInventory
         ::= ' inventory of' Exactly KindOfItem
```

referenced by:

* Confirmation

**Offer:**

![Offer](diagram/Offer.svg)

```
Offer    ::= Amounts KindOfOffer Address
```

referenced by:

* Bidding
* Buying
* Cashing
* Expensing
* Paying
* Receipting
* Selling

**MarketOffer:**

![MarketOffer](diagram/MarketOffer.svg)

```
MarketOffer
         ::= Amounts KindOfOffer ' from the market'
```

referenced by:

* Asking

**Item:**

![Item](diagram/Item.svg)

```
Item     ::= Amounts KindOfItem Address
```

referenced by:

* Asking
* Buying
* Cashing
* Expensing
* Paying
* Receipting
* Selling

**MarketItem:**

![MarketItem](diagram/MarketItem.svg)

```
MarketItem
         ::= Amounts KindOfItem ' from the market'
```

referenced by:

* Bidding

**Amounts:**

![Amounts](diagram/Amounts.svg)

```
Amounts  ::= Any
           | Exactly
           | AtLeast
           | AtMost
           | Range
```

referenced by:

* Item
* MarketItem
* MarketOffer
* Offer

**KindOf:**

![KindOf](diagram/KindOf.svg)

```
KindOf   ::= KindOfOffer
           | KindOfItem
```

**KindOfOffer:**

![KindOfOffer](diagram/KindOfOffer.svg)

```
KindOfOffer
         ::= ' SWOBL'
```

referenced by:

* KindOf
* MarketOffer
* Offer

**KindOfItem:**

![KindOfItem](diagram/KindOfItem.svg)

```
KindOfItem
         ::= ' BTC'
           | ' ETH'
```

referenced by:

* Item
* KindOf
* MarketInventory
* MarketItem

**Address:**

![Address](diagram/Address.svg)

```
Address  ::= ' from the address ' AlfaNumeric
```

referenced by:

* Item
* Offer

**Any:**

![Any](diagram/Any.svg)

```
Any      ::= ' any amount of'
```

referenced by:

* Amounts

**Exactly:**

![Exactly](diagram/Exactly.svg)

```
Exactly  ::= ' exactly ' Number
```

referenced by:

* Amounts
* MarketAccount
* MarketInventory
* MarketVolume

**AtLeast:**

![AtLeast](diagram/AtLeast.svg)

```
AtLeast  ::= ' at least ' Number
```

referenced by:

* Amounts

**AtMost:**

![AtMost](diagram/AtMost.svg)

```
AtMost   ::= ' at most ' Number
```

referenced by:

* Amounts

**Range:**

![Range](diagram/Range.svg)

```
Range    ::= ' at least ' Number ' and at most ' Number
```

referenced by:

* Amounts

## 
![rr-2.0](diagram/rr-2.0.svg) <sup>generated by [RR - Railroad Diagram Generator][RR]</sup>

[RR]: http://bottlecaps.de/rr/ui
