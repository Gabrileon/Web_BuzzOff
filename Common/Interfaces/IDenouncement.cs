using Common.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IDenouncement
    {
        public int Id { get; }
        public string cep { get; }
        public int number { get;  }
        public string uf { get;  }
        public string address { get;  }
        public string city { get;  }
        public string comment { get;  }
        //public byte[] media { get;  }
        //public DateTime createdAt { get;  }
        //public IUser user { get;  }
    }
}
