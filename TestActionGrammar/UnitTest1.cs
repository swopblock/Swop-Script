using ActionGrammar;

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
    public class Intentions
    {
        public Transacting Transacting;
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
        public Actors Actor;

        public Actions Action;

        public Signature Signature;

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

    public class Ordering : Actions
    {
        public Reservation Reservation;

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
        public Volume Volume;

        public string Text
        {
            get
            {
                return $" and the order is good when the market volume reaches {Volume.Text}";
            }
        }
    }

    public class Invoicing : Actions
    {
        public Expiration Expiration;

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
        public Volume Volume;

        public string Text { get { return $" and the invoice is good when the market volume reaches {Volume.Text}"; } }

    }

    public class Delivering : Actions
    {
        public Execution Execution;

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
        //public string Text = $" and the delivery is good when the market volume reaches {Volume.Text}";

    }

    public class Confirming : Actions
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
        //public Exactly Exactly;

        //public KindOf KindOf;

        //public string Text = $" and the confirmation is good at the market volume of {Exactly.Text} {KindOf.Text}";
    }



    public class Signature
    {
        public string Text = " commiting by signature ";

        public string AlfaNumeric;
    }

    public class Bidding : Ordering
    {
        //Bidding ::= ' bidding' Offer ' with reservation to buy in' MarketItem

    }

    public class Asking : Ordering
    {
        //Asking ::= ' asking' MarketOffer ' with reservation to sell out' Item

    }

    public class Buying : Invoicing
    {

    }

    public class Selling : Invoicing
    {

    }


    public class Paying : Delivering
    {

    }

    public class Cashing : Delivering
    {

    }

    public class Expensing : Confirming
    {

    }

    public class Receipting : Confirming
    {

    }

    public class Volume
    {
        public Int64 Number;

        public string Text = $" TODO";
    }




    //Buying ::= ' buying' Item ' with expiration to pay out' Offer

    //Selling ::= ' selling' Item ' with expiration to cash in' Offer


    //Paying ::= ' paying' Offer ' with execution to receipt in' Item

    //Cashing ::= ' cashing' Item ' with execution to expense out' Offer


    //Expensing ::= ' expensing' Offer ' with confirmation of receipt of' Item

    //Receipting ::= ' receipting' Item ' with confirmation of expense of' Offer


    //Offer::= Amounts KindOfOffer Address

    //MarketOffer::= Amounts KindOfOffer ' from the market'

    //Item::= Amounts KindOfItem Address

    //MarketItem::= Amounts KindOfItem ' from the market'


    //Amounts::= (Any | Exactly | AtLeast | AtMost | Range)

    //KindOf::= KindOfOffer | KindOfItem

    //KindOfOffer::= ' SWOBL'

    //KindOfItem::= ' BTC' | ' ETH'

    //Address::= ' from the address ' AlfaNumeric

    //Any ::= ' any amount of'

    //Exactly::= ' exactly ' Number

    //AtLeast ::= ' at least ' Number

    //AtMost ::= ' at most ' Number

    public class Range
    {
        public Int64 Least, Most;

        public string Text { get { return $" at least {Least} and at most {Most}"; } }
    }
}