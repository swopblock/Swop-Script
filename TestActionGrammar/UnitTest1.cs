using ActionGrammar;
using System.Net.Sockets;

namespace TestActionGrammar
{
    public class UnitTestActionsAndItems
    {
        [Fact]
        public void TestActionEndsWith()
        {
            var action = new ActionsOld();

            string message = action.Text;

            Assert.True(message.EndsWith("."));
        }

        [Fact]
        public void TestOfferItem()
        {
            var offer = new OfferItem();

            Assert.Equal("", offer.Text);
        }

        [Fact]
        public void TestOrderItem() 
        {
            var order = new OrderItem();

            Assert.Equal("", order.Text);
        }
    }

    public class UnitTestUserActions
    {
        [Fact]
        public void TestStartsWith()
        {
            var userAction = new UserActions();

            string message = userAction.Text;

            Assert.True(message.StartsWith("I am "));
        }

        [Fact]
        public void TestEndsWith()
        {
            var userAction = new UserActions();

            string message = userAction.Text;

            Assert.True(message.EndsWith("."));
        }
    }

    public class UnitTestBiddingActions
    {

        [Fact]
        public void TestBiddingStartsWith()
        {
            var biddingAction = new BiddingActions();

            string message = biddingAction.Text;

            Assert.True(message.StartsWith("I am bidding "));
        }

        [Fact]
        public void TestBiddingMiddelText()
        {
            var biddingAction = new BiddingActions();

            string Render = biddingAction.Text;

            Assert.True(Render.Contains(" in order to buy "));
        }

        [Fact]
        public void TestBiddingEndWith()
        {
            var biddingAction = new BiddingActions();

            string message = biddingAction.Text;

            Assert.True(message.EndsWith("."));
        }

        [Fact]
        public void TestBiddingText()
        {
            var offer = new OfferItem();

            var order = new OrderItem();
            
            var biddingAction = new BiddingActions(offer, order);

            Assert.Equal($"I am bidding {order.Text} in order to buy {offer.Text}.", biddingAction.Text);
        }
    }

    public class UnitTestAskingActions
    { 
        [Fact]
        public void TestAskingStartsWith()
        {
            var askingAction = new AskingActions();

            string message = askingAction.Text;

            Assert.True(message.StartsWith("I am asking "));
        }

        [Fact]
        public void TestAskingMiddelText()
        {
            var askingAction = new AskingActions();

            string message = askingAction.Text;

            Assert.True(message.Contains(" in order to sell "));
        }

        [Fact]
        public void TestAskingEndWith()
        {
            var askingAction = new AskingActions();

            string message = askingAction.Text;

            Assert.True(message.EndsWith("."));
        }
    }

    public class UnitTestAutoActions
    {
        [Fact]
        public void TestAutoActionsStartsWith()
        {
            var autoAction = new AutoActions();

            string message = autoAction.Text;

            Assert.True(message.StartsWith("We are "));
        }

        [Fact]
        public void TestAutoActionsEndsWith()
        {

            var autoAction = new AutoActions();

            string message = autoAction.Text;

            Assert.True(message.EndsWith("."));
        }
    }


    public class Test
    {
        [Fact]
        public void TestIntentions()
        {
            var intentions = new Intentions();

            var text = intentions.Text;

            Assert.NotNull(intentions);
        }
    }

    public class TestIntentions
    {
        //IAMHERE
        public class TestAmounts
        { 

            [Fact]
            public void TestAny() 
            {
                var any = Any.New();

                Assert.Equal("any amount of", any.Text);
            }

            [Fact]
            public void TestExactly()
            {
                var exactly = Exactly.New(1234567);

                Assert.Equal("exactly 1234567", exactly.Text);
            }

            [Fact]
            public void TestAtLeast()
            {
                var atLeast = AtLeast.New(2345678);

                Assert.Equal("at least 2345678", atLeast.Text);

            }

            [Fact]
            public void TestAtMost()
            {
                var atMost = AtMost.New(3456789);

                Assert.Equal("at most 3456789", atMost.Text);
            }

            [Fact]
            public void TestRange()
            {
                var range = Range.New(1, 2);

                Assert.Equal("at least 1 and at most 2", range.Text);
            }
        }


    }

    public class Intentions
    {
        public Transacting Transacting = new Transacting();

        public string Text
        {
            get
            {
                return $"{Transacting.Text}.\n";
            }
        }
    }


    public class Transacting
    {
        public Actors Actor = new User();

        public Actions Action = new Bidding();

        public Signature Signature = new Signature();

        public string Text
        {
            get
            {
                return $"{Actor.Text} {Action.Text} {Signature.Text}";
            }
        }
    }

    public abstract class Actors
    {
        public abstract string Text { get; }
    }

    public class User : Actors
    {
        public override string Text
        {
            get
            {
                return "I am";
            }
        }
    }

    public class Auto : Actors
    {
        public override string Text
        {
            get
            {
                return "We are";
            }
        }
    }

    public abstract class Actions
    {
        public abstract string Text { get; }
    }

    public abstract class Ordering : Actions
    {
        public Reservation Reservation = new Reservation();

        public override string Text
        {
            get
            {
                return $" {Reservation.Text}";
            }
        }
    }

    public class Reservation
    {
        public Volume Volume = new Volume();

        public string Text
        {
            get
            {
                return $" and the order is good when the market volume reaches {Volume.Text}";
            }
        }
    }

    public abstract class Invoicing : Actions
    {
        public Expiration Expiration = new Expiration();

        public override string Text
        {
            get
            {
                return $" {Expiration.Text}";
            }
        }
    }

    public class Expiration
    {
        public Volume Volume = new Volume();

        public string Text { get { return $" and the invoice is good for the market volume of {Volume.Text}"; } }

    }

    public abstract class Delivering : Actions
    {
        public Execution Execution = new Execution();

        public override string Text
        {
            get
            {
                return $"";// {Execution.Text}";
            }
        }
    }

    public class Execution
    {
        public Volume Volume = new Volume();

        public string Text
        {
            get
            {
                return $" and the delivery is good when the market volume reaches {Volume.Text}";
            }
        }

    }

    public abstract class Confirming : Actions
    {
        public Confirmation Confirmation;

        public override string Text
        {
            get
            {
                return $"";// {Confirmation.Text}";
            }
        }
    }

    public class Confirmation
    {
        public MarketVolume MarketVolume;

        public MarketAccount MarketAccount;

        public MarketInventory MarketInventory;

        public string Text
        {
            get
            {
                return $" and the confirmation is good at the market {MarketVolume}, {MarketAccount} and {MarketInventory}";
            }
        }
    }

    public class MarketVolume
    {
        public Exactly Exactly;

        public string Text
        {
            get
            {
                    return $"volume of {Exactly.Text} SWOBL";
            }
        }
    }

    public class MarketAccount
        {
            public Exactly Exactly;

            public string Text
            {
                get
                {
                    return $"account of {Exactly.Text} SWOBL";
                }
            }
        }

    public class MarketInventory
    {
        public Exactly Exactly;

        public KindOfItem KindOfItem;

        public string Text
        {
            get
            {
                return $"inventory of {Exactly.Text} {KindOfItem.Text}";
            }
        }
    }

    public class Signature
    {
        public string Text = " commiting by signature ";

        public string AlfaNumeric;
    }

    public class Bidding : Ordering
    {
        public Offer Offer = new Offer();

        public MarketItem MarketItem = new MarketItem();

        public override string Text
        {
            get
            {
                return $"bidding {Offer.Text} with reservation to buy in {MarketItem.Text}";
            }
        }

        public static Bidding New(Offer offer, MarketItem marketItem)
        {
            var NEW = new Bidding();

            NEW.Offer = offer;

            NEW.MarketItem = marketItem;

            return NEW;
        }
    }

    public class Asking : Ordering
    {
        public MarketOffer MarketOffer = new MarketOffer();

        public Item Item = new Item();

        public string Text
        {
            get
            {
                return $" asking {MarketOffer.Text} with reservation to sell out {Item.Text}";
            }
        }
    }

    public class Buying : Invoicing
    {
        public Item Item = new Item();

        public Offer Offer = new Offer();

        public string Text
        {
            get
            {
                return $" buying {Item.Text} with expiration to pay out {Offer.Text}";
            }
        }
    }

    public class Selling : Invoicing
    {
        public Item Item = new Item();

        public Offer Offer = new Offer();

        public string Text
        {
            get
            {
                return $" selling {Item.Text} with expiration to cash in {Offer.Text}";
            }
        }
    }


    public class Paying : Delivering
    {
        public Offer Offer = new Offer();

        public Item Item = new Item();

        public string Text
        {
            get
            {
                return $"paying {Offer.Text} with execution to receipt in {Item.Text}";
            }
        }
    }

    public class Cashing : Delivering
    {
        public Offer Offer = new Offer();

        public Item Item = new Item();

        public string Text
        {
            get
            {
                return $"cashing {Item.Text} with execution to expense out {Offer.Text}";
            }
        }
    }

    public class Expensing : Confirming
    {
        public Offer Offer = new Offer();

        public Item Item = new Item();

        public string Text
        {
            get
            {
                return $"expensing {Offer.Text} with confirmation of receipt of {Item.Text}";
            }
        }
    }

    public class Receipting : Confirming
    {
        public Offer Offer = new Offer();

        public Item Item = new Item();

        public string Text
        {
            get
            {
                return $"receipting {Item.Text} with confirmation of expense of {Offer.Text}";
            }
        }
    }

    public class Volume
    {
        public Int64 Number;

        public string Text = $" TODO";
    }





 

 
 

 

    public class Offer //::= Amounts KindOfOffer Address
    {
        public Amounts Amount = new Range();

        public KindOfOffer KindOfOffer = new KindOfOffer();

        public Address Address = new Address();

        public string Text 
        { 
            get 
            { 
                return $"{Amount.Text} {KindOfOffer.Text} {Address.Text}"; 
            } 
        }

        public static Offer New(Amounts amount, KindOfOffer kindOfOffer, Address address)
        {
            var NEW = new Offer();

            NEW.Amount = amount;
            NEW.KindOfOffer = kindOfOffer;
            NEW.Address = address;

            return NEW;
        }
    }

    public class MarketOffer
    {
        public Amounts Amount = new Range();

        public KindOfOffer KindOfOffer = new KindOfOffer();
        public string Text
        {
            get
            {
                return $" {Amount} {KindOfOffer} from the market";
            }
        }
    }

    public class Item
    {
        public Amounts Amount = new Range();

        public KindOfItem KindOfItem = new KindOfItem();

        public Address Address;

        public string Text { get { return $"{Amount.Text} {KindOfItem.Text} {Address.Text}"; } }
    }

    public class MarketItem : Item
    {
        public Int64 Number;

        public string Text
        {
            get
            {
                return "";// $"{Amount} {KindOfItem}";
            }
        }
    }//::= Amounts KindOfItem ' from the market'


    public abstract class Amounts
    {
        public abstract string Text { get; }
    }

    public class KindOf
    {

    }

    public class KindOfOffer
    {
        public string Text { get { return "SWOBL"; } }

    }
        
    public class KindOfItem
    {
        public string Text { get { return " BTC";/* | " ETH"*/} }

    }

    public class BtcItem : KindOfItem
    {

    }

    public class EthItem : KindOfItem
    {

    }
    
    public class Address
    {
        public Int64 AlfaNumeric;
        public string Text { get { return $"from the address {AlfaNumeric}"; } }
    }

    public class Any : Amounts
    {
        public override string Text { get { return "any amount of"; } }

        public static Any New()
        { 
            return new Any(); 
        }
    }

    public class Exactly : Amounts
    {
        public Int64 Number;

        public override string Text { get { return $"exactly {Number}"; } }

        public static Exactly New(Int64 number)
        {
            var NEW = new Exactly();

            NEW.Number = number;

            return NEW;
        }
    }

    public class AtLeast : Amounts
    {
        public Int64 Number;

        public override string Text { get { return $"at least {Number}"; } }

        public static AtLeast New(Int64 number)
        {
            var NEW = new AtLeast();

            NEW.Number = number;

            return NEW;
        }
    }

    public class AtMost : Amounts
    {
        public Int64 Number;

        public override string Text { get { return $"at most {Number}"; } }

        public static AtMost New(Int64 number)
        {
            var NEW = new AtMost();

            NEW.Number = number;

            return NEW;
        }
    }

    public class Range : Amounts
    {
        public Int64 Least, Most;

        public override string Text { get { return $"at least {Least} and at most {Most}"; } }

        public static Range New(Int64 least, Int64 most)
        {
            var NEW = new Range();

            NEW.Least = least;
            NEW.Most = most;

            return NEW;
        }
    }
}