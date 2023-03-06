**Intentions:**

![Intentions](diagram/Intentions.svg)

```
Intentions
         ::= User Ordering
           | Auto ( Invoicing | Delivering | Confirming ) '.'
```

**Auto:**

![Auto](diagram/Auto.svg)

```
Auto     ::= 'We are '
```

referenced by:

* Intentions

**Invoicing:**

![Invoicing](diagram/Invoicing.svg)

```
Invoicing
         ::= ( Buying | Selling ) Delivery Signature
```

referenced by:

* Intentions

**Buying:**

![Buying](diagram/Buying.svg)

```
Buying   ::= 'buying ' Asset ' in order for ' Cash
```

referenced by:

* Invoicing

**Selling:**

![Selling](diagram/Selling.svg)

```
Selling  ::= 'selling ' Asset ' in order for ' Cash
```

referenced by:

* Invoicing

**Delivery:**

![Delivery](diagram/Delivery.svg)

```
Delivery ::= ' and delivery is good until the market volume reaches ' ExactAmount
```

referenced by:

* Invoicing

**Signature:**

![Signature](diagram/Signature.svg)

```
Signature
         ::= ' using the signature ' AlphaNumeric
```

referenced by:

* Invoicing

**Asset:**

![Asset](diagram/Asset.svg)

```
Asset    ::= ExactAmount ' using ' AssetAddress
```

referenced by:

* Buying
* Selling

**Cash:**

![Cash](diagram/Cash.svg)

```
Cash     ::= ExactAmount ' using ' CashAddress
```

referenced by:

* Buying
* Selling

**ExactAmount:**

![ExactAmount](diagram/ExactAmount.svg)

```
ExactAmount
         ::= ' exactly ' Numeric Units
```

referenced by:

* Asset
* Cash
* Delivery

**AssetAddress:**

![AssetAddress](diagram/AssetAddress.svg)

```
AssetAddress
         ::= ' the ' AssetUnits ' address ' AlphaNumeric
```

referenced by:

* Asset

**CashAddress:**

![CashAddress](diagram/CashAddress.svg)

```
CashAddress
         ::= ' the SWOBL address ' AlphaNumeric
```

referenced by:

* Cash

**AssetUnits:**

![AssetUnits](diagram/AssetUnits.svg)

```
AssetUnits
         ::= 'BTC'
           | 'ETH'
```

referenced by:

* AssetAddress

## 
![rr-2.0](diagram/rr-2.0.svg) <sup>generated by [RR - Railroad Diagram Generator][RR]</sup>

[RR]: http://bottlecaps.de/rr/ui