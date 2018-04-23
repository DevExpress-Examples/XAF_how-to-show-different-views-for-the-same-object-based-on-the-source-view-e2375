﻿using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Base;

namespace WinWebSolution.Module {
    [DefaultClassOptions]
    public class Producer : BaseObject {
        public Producer(Session s) : base(s) { }

        public string Name {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue<string>("Name", value); }
        }

        [Aggregated]
        [Association("Producer-Transactions")]
        public XPCollection<Transaction> Transactions {
            get { return GetCollection<Transaction>("Transactions"); }
        }
    }

    [DefaultClassOptions]
    public class Consumer : BaseObject {
        public Consumer(Session s) : base(s) { }

        public string Name {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue<string>("Name", value); }
        }

        [Aggregated]
        [Association("Consumer-Transactions")]
        public XPCollection<Transaction> Transactions {
            get { return GetCollection<Transaction>("Transactions"); }
        }
    }

    public class Transaction : BaseObject {
        public Transaction(Session s) : base(s) { }

        public string Product {
            get { return GetPropertyValue<string>("Product"); }
            set { SetPropertyValue<string>("Product", value); }
        }

        public decimal Amount {
            get { return GetPropertyValue<decimal>("Amount"); }
            set { SetPropertyValue<decimal>("Amount", value); }
        }

        [Association("Producer-Transactions")]
        public Producer Producer {
            get { return GetPropertyValue<Producer>("Producer"); }
            set { SetPropertyValue<Producer>("Producer", value); }
        }

        [Association("Consumer-Transactions")]
        public Consumer Consumer {
            get { return GetPropertyValue<Consumer>("Consumer"); }
            set { SetPropertyValue<Consumer>("Consumer", value); }
        }
    }
}
